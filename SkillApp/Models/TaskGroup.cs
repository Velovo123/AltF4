
using Newtonsoft.Json;

namespace Models.SkillApp
{
    public class TaskGroup
    {
        [JsonProperty("tasks")]
        public List<Task> Tasks { get; set; }
        [JsonProperty("milestones")]
        public List<string> Milestones { get; set; }
    }


}
