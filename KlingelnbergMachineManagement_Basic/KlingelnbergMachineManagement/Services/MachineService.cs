using KlingelnbergMachineManagement.Domain.Interfaces;
using KlingelnbergMachineManagement.Domain.Models;
using KlingelnbergMachineManagement.Application.DTOs;


namespace KlingelnbergMachineManagement.Application.Services
{
    public class MachineService : IMachineService
    {
        // service implementing business logic for machine asset operations
        private readonly IAssetRepository _repository;

        public MachineService(IAssetRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // Get assets for a specific machine 
        public async Task<IEnumerable<string>> GetAssetsByMachineTypeAsync(string machineType)
        {
            if (string.IsNullOrWhiteSpace(machineType))
                throw new ArgumentException("Machine type cannot be empty", nameof(machineType));

            var mappings = await _repository.GetAllMappingAsync();
            return mappings
                .Where(m => m.MachineType.Equals(machineType, StringComparison.OrdinalIgnoreCase))
                .Select(m => m.AssetName)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(a => a)
                .ToList();
        }

        // Get Machine that use a specific asset 
        public async Task<IEnumerable<string>> GetMachinesByAssetNameAsync(string assetName)
        {
            if (string.IsNullOrWhiteSpace(assetName))
                throw new ArgumentException("Asset name cannot be empty", nameof(assetName));

            var mappings = await _repository.GetAllMappingAsync();
            return mappings
                .Where(m => m.AssetName.Equals(assetName, StringComparison.OrdinalIgnoreCase))
                .Select(m => m.MachineType)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(a => a)
                .ToList();
        }


        // Get Machines using latest series of all their assets 
        public async Task<IEnumerable<string>> GetMachinesWithLatestServicesAsync()
        {
            var mappings = await _repository.GetAllMappingAsync();

            // Step 1: Find the latest series for each asset

            var latestSeriesByAsset =
                from m in mappings
                group m by m.AssetName into assetGroup
                select new
                {
                    AssetName = assetGroup.Key,
                    LatestSeries = assetGroup.Max(x => ExtractSeriesNumber(x.SeriesNumber))
                };


            //var latestSeriesByAsset = mappings
            //    .GroupBy(m => m.AssetName, StringComparer.OrdinalIgnoreCase)
            //    .ToDictionary(
            //        g => g.Key,
            //        g => g.Max(m => ExtractSeriesNumber(m.SeriesNumber)),
            //        StringComparer.OrdinalIgnoreCase
            //    );

            // Step 2: Group by machine and check if all assets use latest series
            //var machineAssets = mappings
            //    .GroupBy(m => m.MachineType, StringComparer.OrdinalIgnoreCase);

            //var machinesWithLatestSeries = new List<string>();

            //foreach (var group in machineAssets)
            //{
            //    var machineType = group.Key;
            //    var allUseLatest = true;

            //    foreach (var mapping in group)
            //    {
            //        var currentSeries = ExtractSeriesNumber(mapping.SeriesNumber);
            //        var latestSeries = latestSeriesByAsset[mapping.AssetName];

            //        if (currentSeries < latestSeries)
            //        {
            //            allUseLatest = false;
            //            break;
            //        }
            //    }

            //    if (allUseLatest)
            //        machinesWithLatestSeries.Add(machineType);
            //}

            var machinesWithLatestSeries =
                from m in mappings
                join latest in latestSeriesByAsset
                    on m.AssetName equals latest.AssetName
                group new { m, latest } by m.MachineType into machineGroup
                where machineGroup.All(x => ExtractSeriesNumber(x.m.SeriesNumber) == x.latest.LatestSeries)
                select machineGroup.Key;

            return machinesWithLatestSeries.OrderBy(m => m);
        }


        // Get All Machine Types
        public async Task<IEnumerable<string>> GetAllMachineTypesAsync()
        {
            return await _repository.GetAllMachineTypesAsync();
        }

        // Get all Asset Names 
        public async Task<IEnumerable<string>> GetAllAssetNamesAsync()
        {
            return await _repository.GetAllAssetNamesAsync();
        }
        public async Task<IEnumerable<MachineDetailDto>> GetAllMachineDetailsAsync()
        {
            var mappings = await _repository.GetAllMappingAsync();

            // Get latest series info
            var latestSeriesByAsset = mappings
                .GroupBy(m => m.AssetName, StringComparer.OrdinalIgnoreCase)
                .ToDictionary(
                    g => g.Key,
                    g => g.Max(m => ExtractSeriesNumber(m.SeriesNumber)),
                    StringComparer.OrdinalIgnoreCase
                );

            //var latestSeriesByAsset =
            //    from m in mappings
            //    group m by m.AssetName into assetGroup
            //    select new
            //    {
            //        AssetName = assetGroup.Key,
            //        LatestSeries = assetGroup.Max(a => ExtractSeriesNumber(a.AssetName))
            //    };

            var machineGroups = mappings.GroupBy(m => m.MachineType, StringComparer.OrdinalIgnoreCase);
            var result = new List<MachineDetailDto>();

            foreach (var group in machineGroups)
            {
                var assets = group.Select(m =>
                {
                    var seriesValue = ExtractSeriesNumber(m.SeriesNumber);
                    var isLatest = seriesValue == latestSeriesByAsset[m.AssetName];

                    return new AssetDetailDto
                    {
                        AssetName = m.AssetName,
                        SeriesNumber = m.SeriesNumber,
                        SeriesNumericValue = seriesValue,
                        IsLatestSeries = isLatest
                    };
                }).ToList();

                result.Add(new MachineDetailDto
                {
                    MachineType = group.Key,
                    Assets = assets,
                    UsesLatestSeries = assets.All(a => a.IsLatestSeries)
                });
            }

            return result.OrderBy(m => m.MachineType);
        }

        private int ExtractSeriesNumber(string seriesNumber)
        {
            if (string.IsNullOrEmpty(seriesNumber) || !seriesNumber.StartsWith("S"))
                throw new InvalidOperationException($"Invalid series number: {seriesNumber}");

            var numericPart = seriesNumber.Substring(1);
            if (int.TryParse(numericPart, out int value))
                return value;

            throw new InvalidOperationException($"Cannot parse series number: {seriesNumber}");
        }
    }
}