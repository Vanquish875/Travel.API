using System;

namespace Travel.DAL.Models
{
    public class Activity : BaseModel
    {
        public int CityId { get; set; }
        public string ActivityName { get; set; }
        public string Address1 { get; set; }
        public DateTime ActivityDateTime { get; set; }
        public enum ActivityType { Food, Indoors, Outdoors };
        private ActivityType _activity;
        public ActivityType CurrentActivityType
        {
            get { return _activity; }
            set { _activity = value; }
        }
    }
}
