
namespace SkillApp
{
    // EXAMPLE OF USAGE DESERIALIZED OBJ FROM JSON FILE
    // using Newtonsoft.Json;
    /*
      ootobject? deserializedObject = JsonConvert.DeserializeObject<Rootobject>(json);

        if (deserializedObject?.roadmap?.beginner?.tasks?.Count > 0)  -- tasks have 3 task
        {
            var firstBeginnerTask = deserializedObject.roadmap.beginner.tasks[0];  -- get first task

            Console.WriteLine($"Beginner First Task:");
            Console.WriteLine($"  - Task: {firstBeginnerTask.task}");

            Console.WriteLine($"    Subtasks:");
            foreach (var subtask in firstBeginnerTask.subtasks)   -- every task HAVE 3 SUBTASKS
            {
                Console.WriteLine($"      - {subtask}");
            }

            Console.WriteLine($"    Resources:");
            foreach (var resource in firstBeginnerTask.resources) -- every task have RESOURCES
            {
                Console.WriteLine($"      - {resource}");
            }

            Console.WriteLine($"  Milestones:");
            foreach (var milestone in deserializedObject.roadmap.beginner.milestones)    -- every level have MILESTONES
            {
                Console.WriteLine($"    - {milestone}");
            }
        }
        var firstIntermediateTask = deserializedObject.roadmap.intermediate.tasks[0].task;
        Console.WriteLine(firstIntermediateTask);

    */
    // OUTPUT
    /*
    Beginner First Task:
  - Task: Understand Basic Programming Concepts
    Subtasks:
      - task1: Learn variables, data types, and basic operators
      - task2: Understand control flow (if statements, loops)
      - task3: Explore functions and basic code structure
    Resources:
      - https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/
      - https://www.codecademy.com/learn/learn-c-sharp
  Milestones:
    - Completed Basic Programming Concepts
    - Mastered C# Syntax  
    */
    public class Task
    {
        public string task { get; set; }
        public List<string> subtasks { get; set; }
        public List<string> resources { get; set; }
    }

    public class Roadmap
    {
        public TaskGroup beginner { get; set; }
        public TaskGroup intermediate { get; set; }
        public TaskGroup advanced { get; set; }
    }

    public class Rootobject
    {
        public Roadmap roadmap { get; set; }
        public List<string> supplementary_skills { get; set; }
        public List<string> stay_abreast_strategies { get; set; }
    }

    public class TaskGroup
    {
        public List<Task> tasks { get; set; }
        public List<string> milestones { get; set; }
    }


}
