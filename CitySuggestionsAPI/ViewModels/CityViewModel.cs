using System;

namespace CitySuggestionsAPI.ViewModels
{
    public class CityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Population { get; set; }
        public int DigitalEvaluationModel { get; set; }
        public string TimeZone { get; set; }
        public DateTime LastModified { get; set; }
    }
}
