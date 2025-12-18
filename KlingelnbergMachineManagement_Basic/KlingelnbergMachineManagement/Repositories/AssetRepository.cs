using KlingelnbergMachineManagement.Domain.Interfaces;
using KlingelnbergMachineManagement.Domain.Models;
using KlingelnbergMachineManagement.Infrastructure.DataParsers;

namespace KlingelnbergMachineManagement.Infrastructure.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        private readonly IEnumerable<IDataParser> _parsers;
        private readonly string _dataFilePath;
        private IEnumerable<MachineAssetMapping>? _cachedMappings;

        public AssetRepository(IEnumerable<IDataParser> parsers, string dataFilePath)
        {
            _parsers = parsers ?? throw new ArgumentNullException(nameof(parsers));
            _dataFilePath = dataFilePath ?? throw new ArgumentNullException(nameof(dataFilePath));
        }

        /* 
        1 - checks if file data is already readed or not 
        2 - if not then checks which parser cam handle that data 
        3 - read data from the file 
        */
        public async Task<IEnumerable<MachineAssetMapping>> GetAllMappingAsync()
        {
            if(_cachedMappings != null)
                return _cachedMappings;

            var parser = _parsers.FirstOrDefault(p => p.CanParse(_dataFilePath));
            if (parser == null)
                throw new NotSupportedException($"No parser available for the file: {_dataFilePath}");

            _cachedMappings = await parser.ParseAsync(_dataFilePath);
            return _cachedMappings;
        }

        public async Task<IEnumerable<string>> GetAllMachineTypesAsync()
        {
            var mappings = await GetAllMappingAsync();
            return mappings
                .Select(m => m.MachineType)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(a => a);
        }

        public async Task<IEnumerable<string>> GetAllAssetNamesAsync()
        {
            var mappings = await GetAllMappingAsync();
            return mappings
                .Select(m => m.AssetName)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .OrderBy(a => a);
        }

        public void ClearCache()
        {
            _cachedMappings = null;
        }
    }
}
