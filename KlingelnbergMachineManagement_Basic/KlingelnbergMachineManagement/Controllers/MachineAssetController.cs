
using KlingelnbergMachineManagement.Application.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace KlingelnbergMachineManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MachineAssetController : Controller
    {
        private readonly IMachineService _service;
        private readonly ILogger<MachineAssetController> _logger;

        // contructor injection - injecting instance of other using constructor
        // we dont create instance here we use depedency injection that is we add or register services in program.cs 
        // -- which create instance that can be used

        // why we use dependecy injection -> 
        /* 
            -if we create object instance to use Imachine Services that is its implementation whihc is currently MachineService
            then it will tighly couples this controller with that implementation
            -if we want to change the implementation then it will also effect here that is we need to change each controller which
             uses it like this
            - helps in unit test?? how ??? todo
        */
        public MachineAssetController(IMachineService service, ILogger<MachineAssetController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // Get all machine types
        [HttpGet("machines")]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllMachineTypesAsync()
        {
            try
            {
                var machines = await _service.GetAllMachineTypesAsync();
                return Ok(machines);
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all machines");
                return StatusCode(500, "Internal server error");
            }
        }

        // Get all assets name 
        [HttpGet("assets")]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAssetNamesAsync()
        {
            try
            {
                var assets = await _service.GetAllAssetNamesAsync();
                return Ok(assets);
            } catch(Exception ex)
            {
                _logger.LogError(ex, "Error getting all assets");
                return StatusCode(500, "Internal server error");
            }
        }

        // 1 - Get Assets for a specific machine type 
        [HttpGet("machine/{machineType}/assets")]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAssetsByMachineTypeAsync(string machineType)
        {
            try
            {
                var assets = await _service.GetAssetsByMachineTypeAsync(machineType);
                _logger.LogDebug("HEyy therer" + assets.ToString());

                if (!assets.Any())
                    return NotFound($"No assets found for machine type '{machineType}'");

                return Ok(assets);
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting assets for machine {MachineType}", machineType);
                return StatusCode(500, "Internal server error");
            }
        }


        // 2 - Get machines that uses a specific asset 
        [HttpGet("assets/{assetName}/machines")]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMachinesByAssetNameAsync(string assetName)
        {
            try
            {
                var machines = await _service.GetMachinesByAssetNameAsync(assetName);

                if (!machines.Any())
                    return NotFound($"No machines found using asset {assetName}");

                return Ok(machines);
            } catch (Exception ex) 
            {
                _logger.LogError(ex, "Error getting machines for asset {AssetName}", assetName);
                return StatusCode(500, "Internal server error");
            }
        }

        // 3 - Get machines using the latest series of all their assets
        [HttpGet("machines/latest-series")]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMachinesWithLatestServicesAsync()
        {
            try
            {
                var machines = await _service.GetMachinesWithLatestServicesAsync();
                return Ok(machines);
            } catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting machines with latest series");
                return StatusCode(500, "Internal server error");
            }
        }

        // Get detail info of all machines
        [HttpGet("machines/details")]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllMachineDetailsAsync()
        {
            try
            {
                var machines = await _service.GetAllMachineDetailsAsync();
                return Ok(machines);
            } catch(Exception ex)
            {
                _logger.LogError(ex, "Error getting all machines details");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}