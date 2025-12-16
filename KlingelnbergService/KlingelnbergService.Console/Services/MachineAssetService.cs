using System;
using System.Collections.Generic;
using System.Linq;
using KlingelnbergService.Models;
using KlingelnbergService.Helpers;
using KlingelnbergService.DataAccess;
using System.Security.Cryptography;

namespace KlingelnbergService.Services
{
    public class MachineAssetService : IMachineAssestService
    {
        private readonly List<MachineAssestMapping> _data;

        /* 
        1 - read data using datareader / textfiledatareader
        2 - get assest by machine - get the list of distinct assest names used by a specific machine 
        3 - get the list of distinct machine names that use a specific asset 
        4 - get the machine that use only latest series of all their assets
        */
        public MachineAssetService(IDataReader dataReader)
        {
            if (dataReader == null)
                throw new ArgumentNullException(nameof(dataReader));

            _data = dataReader.ReadData();


            //Console.WriteLine("Data from file : ");
            //foreach (var mapping in _data) {
            //    Console.WriteLine(mapping);
            //}

            if (_data == null || _data.Count == 0)
                throw new InvalidOperationException(nameof(dataReader));
        }
        public List<string> GetAssetsByMachine(string machineName)
        {
            if (string.IsNullOrWhiteSpace(machineName))
                throw new ArgumentException("Machine name cannot be empty", nameof(machineName));


            // without LINQ
            List<string> res = new List<string>();
            foreach(var mapping in _data)
            {
                if (mapping.MachineName.Equals(machineName))
                {
                    if (!res.Contains(mapping.AssestName))
                    {
                        res.Add(mapping.AssestName);
                    }
                }
            }

            // with LINQ
            //List<string> res = _data
            //                   .Where(x => x.MachineName == machineName)
            //                   .Select(x => x.AssestName)
            //                   .Distinct()
            //                   .ToList();

            //List<string> res = (from x in _data
            //                    where x.MachineName.Equals(machineName)
            //                    select x.AssestName).Distinct().ToList();

            return res;
        }

        public List<string> GetMachinesByAsset(string assestName) 
        {
            if (string.IsNullOrWhiteSpace(assestName))
                throw new ArgumentException("Asset name cannot be empty", nameof(assestName));

            // withou LINQ
            List<string> res = new List<string>();

            foreach(var mapping in _data)
            {
                if (mapping.AssestName.Equals(assestName))
                {
                    if (!res.Contains(mapping.MachineName))
                    {
                        res.Add(mapping.MachineName);
                    }
                }
            }

            // with LINQ

            //List<string> res = _data
            //                .Where(x => x.AssestName == assestName)
            //                .Select(x => x.MachineName)
            //                .Distinct()
            //                .ToList();

            //List<string> res = (from x in _data
            //                    where x.AssestName.Equals(assestName)
            //                    select x.MachineName).Distinct().ToList();

            return res;
        }

        public List<string> GetMachinesWithLatestSeries()
        {

            // without LINQ
            // latest series for each asset
            Dictionary<string, int> latestSeriesByAsset = new Dictionary<string, int>();

            foreach(var mapping in _data)
            {
                int seriesValue = SeriesHelper.GetSeriesValue(mapping.SeriesNumber);
                if (!latestSeriesByAsset.ContainsKey(mapping.AssestName))
                {
                    latestSeriesByAsset[mapping.AssestName] = seriesValue;
                } else if (seriesValue > latestSeriesByAsset[mapping.AssestName])
                {
                    latestSeriesByAsset[mapping.AssestName] = seriesValue;
                }
            }

            // group data by machine
            Dictionary<string, List<MachineAssestMapping>> machineGroups = new Dictionary<string, List<MachineAssestMapping>>();

            foreach(var mapping in _data)
            {
                if (!machineGroups.ContainsKey(mapping.MachineName))
                {
                    machineGroups[mapping.MachineName] = new List<MachineAssestMapping>();
                }
                machineGroups[mapping.MachineName].Add(mapping);
            }

            // validate machine which uses latest series 
            List<string> machineWithLatest = new List<string>();
            foreach(var machine in machineGroups)
            {
                bool usesOnlyLatest = true;
                foreach(var mapping in machine.Value)
                {
                    int currSeries = SeriesHelper.GetSeriesValue(mapping.SeriesNumber);
                    int latestSeries = latestSeriesByAsset[mapping.AssestName];
                    if(currSeries != latestSeries)
                    {
                        usesOnlyLatest = false;
                        break;
                    }
                }
                if (usesOnlyLatest)
                    machineWithLatest.Add(machine.Key);
            }
            machineWithLatest.Sort();


            // with LINQ

            // find the latest series number that is max number 
            //var latestSeriesByAssest = _data
            //     .GroupBy(x => x.AssestName)
            //     .ToDictionary(
            //        g => g.Key,
            //        g => g.Max(x => SeriesHelper.GetSeriesValue(x.SeriesNumber))
            //     );

            //var latestSeriesByAsset = (from x in _data
            //                           group x by x.AssestName into assetGroup
            //                           select new
            //                           {
            //                               AssetName = assetGroup.Key,
            //                               LatestSeries = assetGroup.Max(a => SeriesHelper.GetSeriesValue(a.SeriesNumber))
            //                           })
            //                           .ToDictionary(
            //                               x => x.AssetName,
            //                               x => x.LatestSeries
            //                           );

            // group data by machine and check if all assets use latest series 
            //var machineWithLatest = _data
            //    .GroupBy(x => x.MachineName)
            //    .Where(machineGroup =>
            //    {
            //        return machineGroup.All(mapping =>
            //        {
            //            var currentSeriesValue = SeriesHelper.GetSeriesValue(mapping.SeriesNumber);
            //            var latestSeriesValue = latestSeriesByAssest[mapping.AssestName];
            //            return currentSeriesValue == latestSeriesValue;
            //        });
            //    })
            //    .Select(g => g.Key)
            //    .ToList();

            //var machineWithLatest = 
            //    (from x in _data
            //     group x by x.MachineName into machineGroup
            //     where machineGroup.All(m => SeriesHelper.GetSeriesValue(m.SeriesNumber) == latestSeriesByAsset[m.AssestName])
            //     orderby machineGroup.Key
            //     select machineGroup.Key)
            //     .ToList();

            return machineWithLatest;
        }
    }
}
