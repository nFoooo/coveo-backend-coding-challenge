using CsvHelper.Configuration.Attributes;
using System;

namespace CitySuggestionsAPI.Entities
{
    public class City
    {
        [Name("id")]
        public int Id { get; set; }
        [Name("name")]
        public string Name { get; set; }
        [Name("admin1")]
        public string AdministrativeRegion { get; set; }
        [Name("country")]
        public string Country { get; set; }
        [Name("lat")]
        public double Latitude { get; set; }
        [Name("long")]
        public double Longitude { get; set; }
        [Name("population")]
        public int Population { get; set; }
        [Name("dem")]
        public int DigitalEvaluationModel { get; set; }
        [Name("tz")]
        public string TimeZone { get; set; }
        [Name("modified_at")]
        public DateTime LastModified { get; set; }
        [Ignore]
        public double Score { get; set; }
    }
}