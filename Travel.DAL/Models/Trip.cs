using System;
using System.Collections.Generic;

namespace Travel.DAL.Models
{
    public class Trip : BaseModel
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<City> Cities { get; set; }
        public ICollection<Flight> Flights { get; set; }
    }
}
