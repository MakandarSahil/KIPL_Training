using KlingelnbergService.Models;
using System;
using System.Collections.Generic;

namespace KlingelnbergService.DataAccess
{
    // interface for reading machine asset mapping data from various sources
    // interface will help to not change other files rather than I/O files 
    public interface IDataReader
    {
        List<MachineAssestMapping> ReadData();
    }
}

// if data source changes we can add new readers 
// as of now we have TextFile data reader