using CitySuggestionsAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CitySuggestionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuggestionsController : Controller
    {
        public SuggestionsController()
        {
        }

        [HttpGet]
        public JsonResult Get(string q, double? latitude = null, double? longitude = null)
        {
            var suggestions = new { suggestions = CityUtilities.GetCities(q, latitude, longitude) };
            return Json(suggestions);
        }
    }
}
