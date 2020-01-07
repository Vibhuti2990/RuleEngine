
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace RuleEngineConsole.Models
{
    public class RuleModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Signal { get; set; }

        [Required]        
        public object Value { get; set; }
        [Required]
        public DataTypes ValueType { get; set; }

        [Required]
        public Operator Operator { get; set; }

        public string OpSign
        {
            get
            {
                return ((DescriptionAttribute)Operator.GetType().GetField(Operator.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false)[0]).Description;
            }
        }

        /// <summary>
        /// Check actions for a given rule
        /// </summary>
        /// <param name="check"></param>
        internal void CheckRule(List<RuleRunModel> check)
        {
            #region Get all the check run models with same value types
            List<RuleRunModel> ruleRunModels = check.Where(c => c.ValueType.ToString().Equals(ValueType.ToString())).ToList();
            #endregion

            foreach (RuleRunModel ruleRun in ruleRunModels)
            {
                if (!RuleTypeFactoy.GenrateRuleType(ValueType).ApplyRule(this,ruleRun))
                {
                    Console.WriteLine(ruleRun.Signal);
                }
            } 
        }
    }
}
