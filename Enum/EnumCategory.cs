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
        SqlServer = 2,
        [Description("3")]
        Javascript = 3,
        [Description("4")]
        Html = 4,
        [Description("5")]
        Css = 5,
    }
}
