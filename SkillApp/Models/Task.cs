
using Newtonsoft.Json;

namespace Models.SkillApp
{
    public class Task
    {
        [JsonProperty("task")]
        public string TaskDescription { get; set; }
        [JsonProperty("subtasks")]
        public List<string> Subtasks { get; set; }
        [JsonProperty("resources")]
        public List<string> Resources { get; set; }
    }


}
