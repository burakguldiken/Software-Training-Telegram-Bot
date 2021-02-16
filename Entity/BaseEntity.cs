using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareTraining.Entity
{
    public class BaseEntity
    {
        public long id { get; set; }
        public DateTime creationDate { get; set; }
        public int statusId { get; set; }
    }
}
