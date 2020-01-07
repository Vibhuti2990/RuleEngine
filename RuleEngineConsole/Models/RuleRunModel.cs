using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RuleEngineConsole.Models
{
    public class RuleRunModel
    {
        [JsonProperty("signal")]
        public string Signal { get; set; }

        [JsonProperty("value")]
        public object Value { get; set; }
        [JsonProperty("value_type")]
        public DataTypes ValueType { get; set; }
    }
}
