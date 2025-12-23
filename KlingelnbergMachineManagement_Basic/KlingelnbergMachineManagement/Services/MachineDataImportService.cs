using KlingelnbergMachineManagement.Domain.Models;
using KlingelnbergMachineManagement.Infrastructure.DataParsers;
namespace KlingelnbergMachineManagement.Application.Services
{
    public class MachineDataImportService : IMachineDataImportService
    {
        private readonly IEnumerable<IDataParser> _parsers;
        private readonly string _dataFilePath;

        public MachineDataImportService(
            IEnumerable<IDataParser> parsers,
            string dataFilePath)
        {
            _parsers = parsers;
            _dataFilePath = dataFilePath;

            if (string.IsNullOrWhiteSpace(_dataFilePath))
                throw new InvalidOperationException("Data file path is not configured");
        }

        public async Task ImportAsync(Stream fileStream, string fileName, ImportMode mode)
        {
            if (fileStream == null || fileStream.Length == 0)
                throw new ArgumentException("File is empty");

            var tempFilePath = Path.Combine(
                Path.GetTempPath(),
                $"{Guid.NewGuid()}_{fileName}"
            );

            await using (var fs = new FileStream(tempFilePath, FileMode.Create))
            {
                await fileStream.CopyToAsync(fs);
            }

            try
            {
                var parser = _parsers.FirstOrDefault(p => p.CanParse(tempFilePath))
                    ?? throw new NotSupportedException("Unsupported file format");

                var newMappings = (await parser.ParseAsync(tempFilePath)).ToList();

                List<MachineAssetMapping> finalMappings;

                if (mode == ImportMode.Replace || !File.Exists(_dataFilePath))
                {
                    finalMappings = newMappings;
                }
                else
                {
                    var existingParser = _parsers.First(p => p.CanParse(_dataFilePath));
                    var existingMappings =
                        (await existingParser.ParseAsync(_dataFilePath)).ToList();

                    finalMappings = existingMappings
                        .Concat(newMappings)
                        .Distinct()
                        .ToList();
                }

                var lines = finalMappings.Select(m =>
                    $"{m.MachineType},{m.AssetName},{m.SeriesNumber}");

                await File.WriteAllLinesAsync(_dataFilePath, lines);
            }
            finally
            {
                if (File.Exists(tempFilePath))
                    File.Delete(tempFilePath);
            }
        }
    }
}
