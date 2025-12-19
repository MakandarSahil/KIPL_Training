using KlingelnbergMachineManagement.Domain.Models;

namespace KlingelnbergMachineManagement.Domain.Interfaces
{
    // this defines how domain can access asset related data without knowing where the data come from
    // abstraction to maintain high level and low level dependency
    // this is layer to give data like all mappings all machine all assets
    public interface IAssetRepository
    {
        // to get all machine - asset mapping 
        Task<IEnumerable<MachineAssetMapping>> GetAllMappingAsync();

        // to get all machine types 
        Task<IEnumerable<string>> GetAllMachineTypesAsync();

        // to get all assets names
        Task<IEnumerable<string>> GetAllAssetNamesAsync();
    }
}
