using System;

namespace Travel.DAL.Models
{
    public class BaseModel
    {
        public bool IsDeleted { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
