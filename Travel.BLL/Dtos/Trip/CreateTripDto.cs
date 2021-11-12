using System;

namespace Travel.BLL.Dtos.Trip
{
    public class CreateTripDto
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
