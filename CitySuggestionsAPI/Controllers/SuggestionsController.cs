using CitySuggestionsAPI.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CitySuggestionsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuggestionsController : ControllerBase
    {
        public SuggestionsController()
        {
        }

        [HttpGet]
        public IEnumerable<ViewModels.CityDropDownViewModel> Get(string q, double? latitude = null, double? longitude = null)
        {
            var suggestions = CityUtilities.GetCities(q, latitude, longitude);
            return suggestions;
        }
    }
}
