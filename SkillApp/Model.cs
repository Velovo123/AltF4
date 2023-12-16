
namespace SkillApp
{

    public class Task
    {
        public string task { get; set; }
        public List<string> subtasks { get; set; }
        public List<Resource> resources { get; set; }
    }

    public class Roadmap
    {
        public TaskGroup beginner { get; set; }
        public TaskGroup intermediate { get; set; }
        public TaskGroup advanced { get; set; }
    }

    public class RootObject
    {
        public string aim { get; set; }
        public Roadmap roadmap { get; set; }
        public List<string> supplementary_skills { get; set; }
        public List<string> stay_abreast_strategies { get; set; }
    }

    public class TaskGroup
    {
        public List<Task> tasks { get; set; }
        public List<string> milestones { get; set; }
    }

    public class Resource
    {
        public string resource { get; set; }
        public string url { get; set; }
    }


}
