using System;
using System.Collections.Generic;

namespace Travel.BLL.Entities
{
    public class Trip
    {
        public int TripId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<City> Cities { get; set; }
        public ICollection<Flight> Flights { get; set; }
    }
}
