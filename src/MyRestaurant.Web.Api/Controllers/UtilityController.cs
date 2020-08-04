using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyRestaurant.Services.Interfaces;

namespace MyRestaurant.Web.Api.Controllers
{
    [Route("api/utility")]
    public class UtilityController : ControllerBase
    {
        private IUtilityService _service;
        public UtilityController(IUtilityService service) {
            _service = service;
        }

        [Route("Countries")]
        public async Task<IActionResult> GetCountries()
        {
            var result = _service.GetCountries();

            return Ok(result);
        }

        [Route("States/{countryId}")]
        public async Task<IActionResult> GetStates(long countryId)
        {
            var result = _service.GetStates(countryId);

            return Ok(result);
        }

        [Route("Cities/{stateId}")]
        public async Task<IActionResult> GetCities(long stateId)
        {
            var result = _service.GetCities(stateId);

            return Ok(result);
        }
    }
}
