using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RuleEngineConsole.Models
{
    public enum DataTypes
    {
        String = 1,
        Number,
        Integer,
        Datetime,
        Boolean
    }

    public enum Operator
    {
        [Description("!=")]
        NotEqual =1,
        [Description("==")]
        Equal,
        [Description(">")]
        Greater,
        [Description("<")]
        Less,
        [Description(">=")]
        GreterEqual,
        [Description("<=")]
        LessEqual
    }
}
