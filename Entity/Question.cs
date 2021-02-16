using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareTraining.Entity
{
    [Table("question")]
    public class Question : BaseEntity
    {
        public long categoryId { get; set; }
        public string title { get; set; }
        public string optionA { get; set; }
        public string optionB { get; set; }
        public string optionC { get; set; }
        public string optionD { get; set; }
        public int answer { get; set; }
    }
}
