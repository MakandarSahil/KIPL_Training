using System;
using KlingelnbergService.DataAccess;
using KlingelnbergService.Services;

namespace KlingelnbergService
{
    class Program
    {
        static void Main(string[] ars)
        {
            try
            {
                Console.WriteLine("=== Klingelnberg Machine assets service ===\n");
                //file path 
                string filePath = "matrix.txt";

                Console.WriteLine($"Reading data from file : {filePath}");
                Console.WriteLine();

                //data reader 
                IDataReader dataReader = new TextFileDataReader(filePath);

                // create service 
                IMachineAssestService service = new MachineAssetService(dataReader);

                Console.WriteLine("Data loaded successfully!\n");
                Console.WriteLine("===============================================");



                // create a menu or hard coded tests

                //Test 1 : get asset by machine 
                Console.WriteLine("\n1. GET ASSET BY MACHINE - ");
                Console.WriteLine();

                string[] TestMachines = { "C300", "C40", "C60" };
                foreach(var machine in TestMachines)
                {
                    var assets = service.GetAssetsByMachine(machine);
                    Console.WriteLine($"\nMachine : {machine}");
                    Console.WriteLine($"Assets : {assets.Count}");
                    foreach(var asset in assets)
                    {
                        Console.WriteLine($"   -{asset}");
                    }
                }


                //Test 1 : get asset by machine 
                Console.WriteLine("\n2. GET ASSET BY MACHINE - ");
                Console.WriteLine();

                string[] assests = { "Cutter head", "Blade safety cover", "Clamping fixture" };
                foreach (var asset in assests)
                {
                    var machines = service.GetMachinesByAsset(asset);
                    Console.WriteLine($"\nAsset : {asset}");
                    Console.WriteLine($"Machines : {machines.Count}");
                    foreach (var machine in machines)
                    {
                        Console.WriteLine($"   -{machine}");
                    }
                }

                // Test 3 : Get Machines with the latest series
                Console.WriteLine("\n3. GET MACHINES WITH LATEST SERIES OF ALL ASSETS");

                var latestMachine = service.GetMachinesWithLatestSeries();
                if(latestMachine.Count > 0)
                {
                    foreach(var machine in latestMachine)
                    {
                        Console.WriteLine($"    - {machine}");
                    }
                } else
                {
                    Console.WriteLine("Found none !!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.ReadLine();
        }
    }
}