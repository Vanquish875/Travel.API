using System;

namespace Travel.API.Model
{
    public class Boarding
    {
        public int BoardingId { get; set; }
        public int CityId { get; set; }
        public string BoardingName { get; set; }
        public string Address1 { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string ConfirmationCode { get; set; }
        public string Notes { get; set; }

        public double GetDurationOfStay()
        {
            var stayDuration = CheckOutDate - CheckInDate;

            return stayDuration.TotalDays;
        }
    }
}
