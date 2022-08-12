using Application.DTOs;
using Application.Helpers;
using Application.Interfaces;
using CoreLog.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Attributes;

namespace WebApi.Controllers
{
    [Route("api/distance")]
    public class DistanceController : ControllerBase
    {
        private readonly IDistanceService _distanceService;
        private readonly ICoreLogger _coreLogger;

        public DistanceController(IDistanceService distanceService, ICoreLogger coreLogger)
        {
            _distanceService = distanceService;
            _coreLogger = coreLogger;
        }

        [HttpGet]
        [ValidateModel]
        public async Task<IActionResult> GetDistanceBetweenCoordinates(DistanceCalculatorRequest request)
        {
            try
            {
                var result = await _distanceService.GetDistanceBetweenCoordinates(request);

                if (!result.Succeeded)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorHandler<ErrorResponse>(_coreLogger).LogError("Unexpected exception on GetDistanceBetweenCoordinates", ex, null));
            }
        }
    }
}
