using KlingelnbergMachineManagement.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace KlingelnbergMachineManagement.Controllers
{
    [ApiController]
    [Route("api")]
    public class MachineAssetController : ControllerBase
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
        public MachineAssetController(
            IMachineService service,
            ILogger<MachineAssetController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // ----------------------------------------------------
        // MACHINES
        // ----------------------------------------------------

        // GET /api/machines
        [HttpGet("machines")]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllMachineTypes()
        {
            try
            {
                return Ok(await _service.GetAllMachineTypesAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all machines");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET /api/machines/latest-series
        [HttpGet("machines/latest-series")]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMachinesWithLatestSeries()
        {
            try
            {
                return Ok(await _service.GetMachinesWithLatestServicesAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting machines with latest series");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET /api/machines/details
        [HttpGet("machines/details")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllMachineDetails()
        {
            try
            {
                return Ok(await _service.GetAllMachineDetailsAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting machine details");
                return StatusCode(500, "Internal server error");
            }
        }

        // ----------------------------------------------------
        // FILTERED QUERIES (SEPARATE ROUTES)
        // ----------------------------------------------------

        // GET /api/machines/by-asset?assetName=Blade%20safety%20cover
        [HttpGet("machines/by-asset")]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMachinesByAsset(
            [FromQuery] string assetName)
        {
            if (string.IsNullOrWhiteSpace(assetName))
                return BadRequest("assetName is required");

            try
            {
                var machines = await _service.GetMachinesByAssetNameAsync(assetName);

                if (!machines.Any())
                    return NotFound($"No machines found using asset '{assetName}'");

                return Ok(machines);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting machines by asset {AssetName}", assetName);
                return StatusCode(500, "Internal server error");
            }
        }

        // GET /api/assets/by-machine?machineType=C300
        [HttpGet("assets/by-machine")]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAssetsByMachine(
            [FromQuery] string machineType)
        {
            if (string.IsNullOrWhiteSpace(machineType))
                return BadRequest("machineType is required");

            try
            {
                var assets = await _service.GetAssetsByMachineTypeAsync(machineType);

                if (!assets.Any())
                    return NotFound($"No assets found for machine '{machineType}'");

                return Ok(assets);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting assets for machine {MachineType}", machineType);
                return StatusCode(500, "Internal server error");
            }
        }

        // ----------------------------------------------------
        // ASSETS
        // ----------------------------------------------------

        // GET /api/assets
        [HttpGet("assets")]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllAssets()
        {
            try
            {
                return Ok(await _service.GetAllAssetNamesAsync());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all assets");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
