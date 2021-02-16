using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareTraining.Entity
{
    [Table("category")]
    public class Category : BaseEntity
    {
        public string name { get; set; }
    }
}
