using System;

namespace Travel.DAL.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
        public int TripId { get; set; }
        public int FlightNumber { get; set; }
        public string AirlineName { get; set; }
        public string DepartureAirportName { get; set; }
        public string ArrivalAirportName { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string ConfirmationCode { get; set; }
        public string Notes { get; set; }

        //I will need to adjust this for timezones. Just adding this as a bookmark for now.
        public double GetFlightDuration()
        {
            var FlightDuration = ArrivalTime - DepartureTime;

            return FlightDuration.TotalMinutes;
        }
    }
}
