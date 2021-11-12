using System;

namespace Travel.BLL.Dtos.City
{
    public class CreateCityDto
    {
        public int TripId { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
