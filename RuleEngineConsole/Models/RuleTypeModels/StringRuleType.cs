using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngineConsole.Models
{
    public class StringRuleType : IRuleDataType
    {
        public bool ApplyRule(RuleModel ruleModel, RuleRunModel ruleRunModel)
        {
            bool result = false;
            string runModelValue = ruleRunModel.Value.ToString();
            string ruleModelValue = ruleModel.Value.ToString();

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
