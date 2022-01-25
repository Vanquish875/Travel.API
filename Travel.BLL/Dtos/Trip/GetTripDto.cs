using System;
using System.Collections.Generic;
using Travel.BLL.Dtos.City;
using Travel.BLL.Dtos.Flight;

namespace Travel.BLL.Dtos.Trip
{
    public class GetTripDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<GetCityDto> Cities { get; set; } = new List<GetCityDto>();
        public ICollection<GetFlightDto> Flights { get; set; } = new List<GetFlightDto>();
    }
}
