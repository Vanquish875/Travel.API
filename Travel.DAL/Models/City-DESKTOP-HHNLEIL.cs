using System;
using System.Collections.Generic;

namespace Travel.DAL.Models
{
    public class City
    {
        public int CityId { get; set; }
        public int TripId { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Boarding> Boardings { get; set; }
        public ICollection<Activity> Activities { get; set; }
    }
}
