
using Newtonsoft.Json;

namespace Models.SkillApp
{
    public class RootObject
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("aim")]
        public string Aim { get; set; }
        [JsonProperty("roadmap")]
        public Roadmap Roadmap { get; set; }
        [JsonProperty("supplementary_skills")]
        public List<string> Supplementary_skills { get; set; }
        [JsonProperty("stay_abreast_strategies")]
        public List<string> Stay_abreast_strategies { get; set; }
    }


}
