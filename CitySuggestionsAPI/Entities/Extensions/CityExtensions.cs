using CitySuggestionsAPI.ViewModels;
using System;

namespace CitySuggestionsAPI.Entities.Extensions
{
    public static class CityExtensions
    {
        // Based on https://www.movable-type.co.uk/scripts/latlong.html
        public static void CalculateScore(this City city, double latitude, double longitude)
        {
            double score = Math.Max(1 - CalculateDistance(city.Latitude, city.Longitude, latitude, longitude) / 12756e3, 0);
            city.Score = Math.Round(score, 4, MidpointRounding.AwayFromZero);
        }
        public static CityDropDownViewModel MapToDropDownViewModel(this City city)
        {
            var vm = new CityDropDownViewModel
            {
                Name = $"{city.Name}, {city.AdministrativeRegion}, {city.Country}",
                Latitude = city.Latitude,
                Longitude = city.Longitude,
                Score = city.Score
            };
            return vm;
        }

        public static CityViewModel MapToViewModel(this City city)
        {
            var vm = new CityViewModel
            {
                Id = city.Id,
                Name = $"{city.Name}, {city.AdministrativeRegion}, {city.Country}",
                Latitude = city.Latitude,
                Longitude = city.Longitude,
                Population = city.Population,
                DigitalEvaluationModel = city.DigitalEvaluationModel,
                TimeZone = city.TimeZone,
                LastModified = city.LastModified
            };
            return vm;
        }

        public static void UpdateAdministrativeRegionAndCountry(this City city)
        {
            city.Country = GetCountryName(city.Country);
            city.AdministrativeRegion = GetProvinceName(city.AdministrativeRegion);
        }

        private static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double radius = 6371e3;
            double latDiff = Radians(lat1 - lat2);
            double lonDiff = Radians(lon1 - lon2);

            double a = Math.Sin(latDiff / 2) * Math.Sin(latDiff / 2) +
                      Math.Cos(Radians(lat1)) * Math.Cos(Radians(lat2)) *
                      Math.Sin(lonDiff / 2) * Math.Sin(lonDiff / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return radius * c; // in metres
        }

        private static string GetCountryName(string code)
        {
            switch (code)
            {
                case "CA":
                    return "Canada";
                case "US":
                    return "United States";
                default: 
                    return code;
            }
        }

        private static string GetProvinceName(string code)
        {
            switch (code)
            {
                case "01":
                    return "AB";
                case "02":
                    return "BC";
                case "03":
                    return "MB";
                case "04":
                    return "NB";
                case "05":
                    return "NL";
                case "07":
                    return "NS";
                case "08":
                    return "ON";
                case "09":
                    return "PE";
                case "10":
                    return "QC";
                case "11":
                    return "SK";
                case "12":
                    return "YT";
                case "13":
                    return "NT";
                case "14":
                    return "NU";
                default:
                    return code;
            }
        }

        private static double Radians(double x)
        {
            return x * Math.PI / 180;
        }
    }
}
