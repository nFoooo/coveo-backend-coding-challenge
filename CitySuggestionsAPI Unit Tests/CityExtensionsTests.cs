using CitySuggestionsAPI.Entities;
using CitySuggestionsAPI.Entities.Extensions;
using Xunit;

namespace CitySuggestionsAPI_Unit_Tests
{
    public class CityExtensionsTests
    {
        public City montreal = new City
        {
            Latitude = 45.50884,
            Longitude = -73.58781
        };
        public City locustGrove = new City
        {
            Latitude = 33.34595,
            Longitude = -84.10908
        };

        [Fact]
        public void CalculateScore()
        {
            montreal.CalculateScore(locustGrove.Latitude, locustGrove.Longitude);
            Assert.Equal(0.8727, montreal.Score);
        }
    }
}
