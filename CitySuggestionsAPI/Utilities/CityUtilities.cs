using CitySuggestionsAPI.Entities;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CitySuggestionsAPI.Entities.Extensions;
using CitySuggestionsAPI.ViewModels;

namespace CitySuggestionsAPI.Utilities
{
    public static class CityUtilities
    {
        public static IEnumerable<CityDropDownViewModel> GetCities(string prefix, double? latitude, double? longitude)
        {
            var cities = GetCitiesFromTsv();
            if (prefix != null && prefix.Length > 0)
            {
                cities = cities.Where(x => x.Name.StartsWith(prefix, System.StringComparison.InvariantCultureIgnoreCase));
            }
            var cityViewModels = new List<CityDropDownViewModel>();
            foreach (var city in cities.ToList())
            {
                if (latitude != null && longitude != null)
                    city.CalculateScore(latitude.Value, longitude.Value);
                city.UpdateAdministrativeRegionAndCountry();
                cityViewModels.Add(city.MapToDropDownViewModel());
            }                
            return cityViewModels.OrderByDescending(x => x.Score);
        }

        public static CityViewModel GetCity(int id)
        {
            var cities = GetCitiesFromTsv();
            var city = cities.SingleOrDefault(x => x.Id == id);
            var cityViewModel = new CityViewModel();
            if (city != null)
            {
                city.UpdateAdministrativeRegionAndCountry();
                cityViewModel = city.MapToViewModel();
            }
            return cityViewModel;
        }

        private static IEnumerable<City> GetCitiesFromTsv()
        {
            using var reader = new StreamReader("StaticFiles\\cities.tsv");
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = "\t",
            };
            using var csv = new CsvReader(reader, config);
            var cities = csv.GetRecords<City>();
            return cities.ToList();            
        }
    }
}
