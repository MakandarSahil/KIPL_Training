using System;
using System.Collections.Generic;

namespace KlingelnbergService.Services
{
    public interface IMachineAssestService
    {

        // intrerface for methods
        List<string> GetAssetsByMachine(string machineName);
        List<string> GetMachinesByAsset(string assestName);
        List<string> GetMachinesWithLatestSeries();
    }
}