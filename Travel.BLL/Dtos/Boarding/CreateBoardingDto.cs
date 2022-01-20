using System;

namespace Travel.BLL.Dtos.Boarding
{
    public class CreateBoardingDto
    {
        public int CityId { get; set; }
        public string BoardingName { get; set; }
        public string Address1 { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string ConfirmationCode { get; set; }
        public string Notes { get; set; }
    }
}
