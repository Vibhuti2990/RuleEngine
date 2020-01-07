using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngineConsole.Models
{
    public class NumberRuleType : IRuleDataType
    {
        public bool ApplyRule(RuleModel ruleModel, RuleRunModel ruleRunModel)
        {
            bool result = false;
            decimal runModelValue = Convert.ToDecimal(ruleRunModel.Value);
            decimal ruleModelValue = Convert.ToDecimal(ruleModel.Value);

            switch (ruleModel.Operator)
            {
                case Operator.NotEqual:
                    result = runModelValue != ruleModelValue;
                    break;
                case Operator.Equal:
                    result = runModelValue == ruleModelValue;
                    break;
                case Operator.Greater:
                    result = runModelValue > ruleModelValue;
                    break;
                case Operator.Less:
                    result = runModelValue < ruleModelValue;
                    break;
                case Operator.GreterEqual:
                    result = runModelValue >= ruleModelValue;
                    break;
                case Operator.LessEqual:
                    result = runModelValue <= ruleModelValue;
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
