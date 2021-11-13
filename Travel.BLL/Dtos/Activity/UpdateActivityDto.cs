using System;

namespace Travel.BLL.Dtos.Activity
{
    public class UpdateActivityDto
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string ActivityName { get; set; }
        public string Address1 { get; set; }
        public DateTime ActivityDateTime { get; set; }
        public int CurrentActivityType { get; set; }
    }
}
