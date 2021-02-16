using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SoftwareTraining.Enum
{
    public enum EnumCategory
    {
        [Description("1")]
        Csharp = 1,
        [Description("2")]
        Mvc = 2,
        [Description("3")]
        Python = 3,
        [Description("4")]
        Html = 4,
        [Description("5")]
        Css = 5,
        [Description("6")]
        Javascript = 6
    }
}
