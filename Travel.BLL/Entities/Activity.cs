using System;

namespace Travel.BLL.Entities
{
    public class Activity
    {
        public int ActivityId { get; set; }
        public int CityId { get; set; }
        public string ActivityName { get; set; }
        public string Address1 { get; set; }
        public DateTime OpenTime { get; set; }
        public DateTime CloseTime { get; set; }
        public enum ActivityType { Food, Indoors, Outdoors };
        private ActivityType _activity;
        public ActivityType CurrentActivityType
        {
            get { return _activity; }
            set { _activity = value; }
        }
    }
}
