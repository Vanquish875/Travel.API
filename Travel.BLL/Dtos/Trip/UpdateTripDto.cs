using System;

namespace Travel.BLL.Dtos.Trip
{
    public class UpdateTripDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
