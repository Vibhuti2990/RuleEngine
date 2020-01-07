using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RuleEngineConsole.Models;

namespace RuleEngineConsole
{
    public static class UTIL
    {
        #region Internal methods to the application

        /// <summary>
        /// Enhancement- When we want user to add Rules from UI
        /// </summary>
        /// <param name="model"></param>
        internal static void AddToTextFile(RuleModel model)
        {
            string path = ConfigurationManager.AppSettings["RuleTextFilePath"];
            string modelString = JsonConvert.SerializeObject(model);
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(modelString);
                }
            }
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(modelString);
            }
        }

        /// <summary>
        /// Get the json file in which all actions that needs to be checked against the rule is there.
        /// </summary>
        /// <returns></returns>
        internal static List<RuleRunModel> GetRuleRunModel()
        {
            string path = ConfigurationManager.AppSettings["RuleCheckFilePath"];
            var jsonText = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<RuleRunModel>>(jsonText);
        }

        /// <summary>
        /// Run the rule 
        /// </summary>
        /// <param name="check">List of actions on which the rule will run</param>
        /// <param name="list">Dictionnary of signal as a key and list of rules as its values</param>
        internal static void RunRule(List<RuleRunModel> check, KeyValuePair<string, List<RuleModel>> list)
        {
            foreach (RuleModel rule in list.Value.ToArray())
            {
                rule.CheckRule(check);
            }
        }

        /// <summary>
        /// Get Rules.txt file from the system
        /// </summary>
        /// <returns></returns>
        internal static List<RuleModel> GetRuleModels()
        {
            List<RuleModel> models = new List<RuleModel>();

            //Get the file path from the app config
            string path = @ConfigurationManager.AppSettings["RuleTextFilePath"];
            using (StreamReader sr = File.OpenText(path))
            {
                string s = string.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    try
                    {
                        models.Add(JsonConvert.DeserializeObject<RuleModel>(s));
                    }
                    catch
                    {
                        //do nothing, fetch next row
                    }
                }
            }
            return models;
        }
        #endregion

        #region Publicly exposed method
        /// <summary>
        /// Checks rule by fetching rules from text file and json files
        /// </summary>
        public static void CheckRules()
        {
            //Read all the rules from the text file           
            List<RuleModel> ruleModels = UTIL.GetRuleModels();

            //Read all the data that needs to get checked
            List<RuleRunModel> ruleRunModels = UTIL.GetRuleRunModel();

            List<KeyValuePair<string, List<RuleRunModel>>> checkFor = ruleRunModels.GroupBy(c => c.Signal).ToDictionary(c => c.Key, c => c.ToList()).ToList();
            List<KeyValuePair<string, List<RuleModel>>> rulesinPlace = ruleModels.GroupBy(c => c.Signal).ToDictionary(c => c.Key, c => c.ToList()).ToList();

            Parallel.ForEach(checkFor, item => 
            {
                if (rulesinPlace.Any(c => c.Key.Equals(item.Key)))
                {
                    UTIL.RunRule(item.Value, rulesinPlace.FirstOrDefault(c => c.Key.Equals(item.Key)));
                }

            });
        } 
        #endregion
    }
}
