using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngineConsole.Models
{
    public static class RuleTypeFactoy
    {
        public static StringRuleType stringRuleType = new StringRuleType();
        public static DateTimeRuleType dateTimeRuleType = new DateTimeRuleType();
        public static NumberRuleType numberRuleType = new NumberRuleType();
        public static BooleanRuleType booleanRuleType = new BooleanRuleType();

        internal static IRuleDataType GenrateRuleType(DataTypes valueType)
        {
            switch (valueType)
            {
                case DataTypes.String:
                    return stringRuleType;
                case DataTypes.Number:
                case DataTypes.Integer:
                    return numberRuleType;
                case DataTypes.Datetime:
                    return dateTimeRuleType;
                case DataTypes.Boolean:
                    return booleanRuleType;
            }
            return null;
        }
    }
}
