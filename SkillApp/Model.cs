
using Newtonsoft.Json;

namespace SkillApp
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

    public class Roadmap
    {
        [JsonProperty("beginner")]
        public TaskGroup Beginner { get; set; }
        [JsonProperty("intermediate")]
        public TaskGroup Intermediate { get; set; }
        [JsonProperty("advanced")]
        public TaskGroup Advanced { get; set; }
    }

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
        [JsonProperty("stay_abreast_strategie")]
        public List<string> Stay_abreast_strategies { get; set; }
    }

    public class TaskGroup
    {
        [JsonProperty("tasks")]
        public List<Task> Tasks { get; set; }
        [JsonProperty("milestones")]
        public List<string> Milestones { get; set; }
    }


}
