using CitySuggestionsAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CitySuggestionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : Controller
    {
        public CitiesController()
        {
        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            var city = CityUtilities.GetCity(id);
            return Json(city);
        }
    }
}
