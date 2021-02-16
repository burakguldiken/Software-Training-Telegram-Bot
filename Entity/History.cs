using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareTraining.Entity
{
    [Table("history")]
    public class History : BaseEntity
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public long userId { get; set; }
        public string text { get; set; }
    }
}
