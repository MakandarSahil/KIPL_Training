using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using KlingelnbergService.Models;
using KlingelnbergService.Helpers;

namespace KlingelnbergService.DataAccess
{

    // to read data from comma seprated text file
    public class TextFileDataReader : IDataReader
    {
        private readonly string _filePath;
        public TextFileDataReader(string filePath)
        {
            if(string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("File path cannot be emppty", nameof(filePath));

            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found: {filePath}");

            _filePath = filePath;
        }

        public List<MachineAssestMapping> ReadData()
        {
            /* 
            1 - List to store mappings 
            2 - read all lines from file
            3 - check if null or empty line then skip / continue
            4 - seprate required part -> with , 
            5 - there must be equal to 3 
            6 - store machine name , assest name series name from parts arr 
            7 - validate each feild 
            8 - add into mapping 
            9 - return mapping 
             */
            var mappings = new List<MachineAssestMapping>();
            var lineNumber = 0;

            try
            {
                var lines = File.ReadAllLines(_filePath);
                foreach (var line in lines)
                {
                    lineNumber++;
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    var parts = line.Split(',')
                        .Select(p => p.Trim())
                        .ToArray();

                    if (parts.Length != 3)
                        throw new InvalidDataException($"Line {lineNumber} : expected 3 values found {parts.Length}");

                    var machineName = parts[0];
                    var assetName = parts[1];
                    var seriesNumber = parts[2];

                    Console.WriteLine($"Machine Name - {machineName}, Assest Name - {assetName}, Series Number - {seriesNumber}");

                    // validate fields 
                    if (string.IsNullOrWhiteSpace(machineName))
                        throw new InvalidDataException($"Line {lineNumber} : Machine name cannot be empty");
                    if (string.IsNullOrWhiteSpace(assetName))
                        throw new InvalidDataException($"Line {lineNumber} : Asset name cannot be empty");

                    if (!SeriesHelper.IsValidSeriesFormat(seriesNumber))
                        throw new InvalidDataException($"Line {lineNumber} : Invalid series format {seriesNumber}. Expected S<digit>");



                    mappings.Add(new MachineAssestMapping(machineName, assetName, seriesNumber));
                }
                //foreach(var v in mappings)
                //{
                //    Console.WriteLine(v);
                //}
                return mappings;
            }
            catch (Exception ex) when (!(ex is InvalidDataException))
            {
                throw new Exception($"Error reading file {_filePath} : {ex.Message}", ex);
            }
        }
    }
}
