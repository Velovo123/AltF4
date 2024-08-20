
using Newtonsoft.Json;

namespace Models.SkillApp
{

    public class Roadmap
    {
        [JsonProperty("beginner")]
        public TaskGroup Beginner { get; set; }
        [JsonProperty("intermediate")]
        public TaskGroup Intermediate { get; set; }
        [JsonProperty("advanced")]
        public TaskGroup Advanced { get; set; }
    }


}
