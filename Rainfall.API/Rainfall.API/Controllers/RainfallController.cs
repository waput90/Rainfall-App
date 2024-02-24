using Microsoft.AspNetCore.Mvc;
using Rainfall.API.Services.Abstract;

namespace Rainfall.API.Controllers
{
    [ApiController]
    [Route("rainfall")]
    public class RainfallController : ControllerBase
    {
        private readonly IRainfallService _rainfallService;

        public RainfallController(IRainfallService rainfallService)
        {
            _rainfallService = rainfallService;
        }

        [HttpGet("id/{stationId}/readings")]
        public async Task<ActionResult> GetReadings(string stationId, int count = 10)
        {
            var a = await _rainfallService.GetRainfallResponse(stationId, count);
            return Ok(a);
        }
        
    }
}