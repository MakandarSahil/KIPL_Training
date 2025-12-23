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
        private FileSystemWatcher? _fileWatcher;

        public AssetRepository(IEnumerable<IDataParser> parsers, string dataFilePath)
        {
            _parsers = parsers ?? throw new ArgumentNullException(nameof(parsers));
            _dataFilePath = dataFilePath ?? throw new ArgumentNullException(nameof(dataFilePath));

            SetupFileWatcher();
        }

        private void SetupFileWatcher()
        {
            var directory = Path.GetDirectoryName(_dataFilePath);
            var fileName = Path.GetFileName(_dataFilePath);

            if (directory == null || fileName == null)
                return;

            _fileWatcher = new FileSystemWatcher(directory, fileName)
            {
                NotifyFilter = NotifyFilters.LastWrite
                             | NotifyFilters.Size
                             | NotifyFilters.FileName
            };

            _fileWatcher.Changed += OnFileChanged;
            _fileWatcher.Renamed += OnFileChanged;
            _fileWatcher.EnableRaisingEvents = true;
        }
        private void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            // Invalidate cache
            _cachedMappings = null;
        }



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
            //return mappings
            //    .Select(m => m.MachineType)
            //    .Distinct(StringComparer.OrdinalIgnoreCase)
            //    .OrderBy(a => a);

            return mappings
                .GroupBy(m => m.MachineType, StringComparer.OrdinalIgnoreCase)
                .Select(g => g.Key)
                .OrderBy(a => a);
        }

        public async Task<IEnumerable<string>> GetAllAssetNamesAsync()
        {
            var mappings = await GetAllMappingAsync();
            //return mappings
            //    .Select(m => m.AssetName)
            //    .Distinct(StringComparer.OrdinalIgnoreCase)
            //    .OrderBy(a => a);
            return mappings
                .GroupBy(m => m.AssetName, StringComparer.OrdinalIgnoreCase)
                .Select(g => g.Key)
                .OrderBy(a => a);
        }

        public void ClearCache()
        {
            _cachedMappings = null;
        }
    }
}
