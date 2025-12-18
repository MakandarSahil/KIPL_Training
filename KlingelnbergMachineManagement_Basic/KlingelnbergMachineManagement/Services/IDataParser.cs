using KlingelnbergMachineManagement.Domain.Models;

namespace KlingelnbergMachineManagement.Infrastructure.DataParsers
{
    public interface IDataParser
    {
        //inteface for data parsing - it allows swithing bewtween files format 

        // to read data async 
        Task<IEnumerable<MachineAssetMapping>> ParseAsync(string filePath);

        // validate path
        bool CanParse(string filePath);
    }
}

