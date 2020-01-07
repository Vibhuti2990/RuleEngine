using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngineConsole.Models
{
    public class BooleanRuleType : IRuleDataType
    {
        public bool ApplyRule(RuleModel ruleModel, RuleRunModel ruleRunModel)
        {
            bool result = false;
            bool runModelValue = Convert.ToBoolean(ruleRunModel.Value);
            bool ruleModelValue = Convert.ToBoolean(ruleModel.Value);

            switch (ruleModel.Operator)
            {
                case Operator.NotEqual:
                    result = runModelValue != ruleModelValue;
                    break;
                case Operator.Equal:
                    result = runModelValue == ruleModelValue;
                    break;
                case Operator.Greater:
                case Operator.Less:
                case Operator.GreterEqual:
                case Operator.LessEqual:
                default:
                    break;
            }
            return result;
        }
    }
}
