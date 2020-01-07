using System;
using System.Collections.Generic;
using System.Text;

namespace RuleEngineConsole.Models
{
    interface IRuleDataType
    {
        bool ApplyRule(RuleModel ruleModel, RuleRunModel ruleRunModel);
    }
}
