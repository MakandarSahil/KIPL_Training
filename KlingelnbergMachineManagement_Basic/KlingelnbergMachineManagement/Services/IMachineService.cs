
using KlingelnbergMachineManagement.Application.DTOs;

namespace KlingelnbergMachineManagement.Application.Services
{
    // service interface defining operations
    // UI and Api layers will depend on this 
    public interface IMachineService
    {
        // A - Get the list of Asset names for given machine type 
        Task<IEnumerable<string>> GetAssetsByMachineTypeAsync(string machineType);

        // B - Get the list of all machine types in which given asset is used 
        Task<IEnumerable<string>> GetMachinesByAssetNameAsync(string assetName);

        // C - Get machine types using the latest series of all assets 
        Task<IEnumerable<string>> GetMachinesWithLatestServicesAsync();

        //// Helpers for dropdowns , filters , validations
        //// Get all machine types 
        Task<IEnumerable<string>> GetAllMachineTypesAsync();

        ////Get all asset names available
        Task<IEnumerable<string>> GetAllAssetNamesAsync();

        //// Get all information about all machines and there assets 
        Task<IEnumerable<MachineDetailDto>> GetAllMachineDetailsAsync();
    }
}
