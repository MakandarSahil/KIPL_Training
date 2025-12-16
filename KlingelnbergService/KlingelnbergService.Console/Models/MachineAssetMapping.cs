using System;

namespace KlingelnbergService.Models
{
    // class to init values of machine assests 
    public class MachineAssestMapping
    {
        public string MachineName { get; set; }
        public string AssestName { get; set; }
        public string SeriesNumber { get; set; }

        public MachineAssestMapping(string machineName, string assestName, string seriesNumber)
        {
            MachineName = machineName;
            AssestName = assestName;
            SeriesNumber = seriesNumber;
        }

        public override string ToString()
        {
            return $"{MachineName}, {AssestName}, {SeriesNumber}";
        }
    }
}
