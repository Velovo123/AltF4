using Newtonsoft.Json;
using OpenAI;
using OpenAI.Managers;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels;

[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace SkillApp
{
    public static class Operator
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod()?.DeclaringType);

        private const string OpenApiKey = "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";

        private static readonly string roadmapDirectory = Path.Combine(AppContext.BaseDirectory, "Roadmaps");

        private static readonly string promptTemplate1 = @"Create a detailed roadmap to enhance expertise and knowledge in [{0}], specifically focusing on [{1}] aiming to [{2}]. The roadmap is structured into three levels - Beginner, Intermediate, and Advanced - each containing tasks, subtasks, milestones, and recommended resources.

The aim of this roadmap is to [{2}]. To achieve this, the roadmap outlines the following tasks:" + "\n\n";
        private static readonly string promptTemplate2 = @"-BEGINNER LEVEL-

Task: [task1]
Subtasks:

[subtask1]
[subtask2]
[subtask3]
Resources:
resource1
resource2
Task: [task2] 
Subtasks:

[subtask1]
[subtask2]
[subtask3] 
Resources:
resource1
resource2
Task: [task3] 
Subtasks:

[subtask1]
[subtask2]
[subtask3] 
Resources:
resource1
resource2
Milestones:

[milestone1]
[milestone2]
[milestone3]
-INTERMEDIATE LEVEL-

Task: [task1] 
Subtasks:

[subtask1]
[subtask2]
[subtask3] 
Resources:
resource1
resource2
Task: [task2] 
Subtasks:

[subtask1]
[subtask2]
[subtask3] 
Resources:
resource1
resource2
Task: [task3] 
Subtasks:

[subtask1]
[subtask2]
[subtask3] 
Resources:
resource1
resource2
Milestones:

[milestone1]
[milestone2]
[milestone3]
-ADVANCED LEVEL-

Task: [task1] 
Subtasks:

[subtask1]
[subtask2]
[subtask3] 
Resources:
resource1
resource2
Task: [task2] 
Subtasks:

[subtask1]
[subtask2]
[subtask3] 
Resources:
resource1
resource2
Task: [task3] 
Subtasks:

[subtask1]
[subtask2]
[subtask3] 
Resources:
resource1
resource2
Milestones:

[milestone1]
[milestone2]
[milestone3]
In addition to the roadmap, there are supplementary skills that can complement the learning journey. These skills include:

[supplementary_skill1]
[supplementary_skill2]
[supplementary_skill3]
To stay abreast of the latest advancements in the [sphere] field, the roadmap suggests the following strategies:

[stay_abreast_strategy1]
[stay_abreast_strategy2]
[stay_abreast_strategy3]
Please note that the provided roadmap is expressed in JSON format. Adjust the URLs of the resources according to your needs and preferences.
Notice that there must be 3 tasks for every level, 3 subtasks for every task,you can give any amount of URL's for recources not only 2(how many can you find in internet)(PROVIDE REAL URL'S THAT EXIST).


Roadmap format: @""{ ""aim"": ""Your_SHORT_AIM_Value_Here"", ""roadmap"": { ""beginner"": { ""tasks"": [ {""task"": """", ""subtasks"": [], ""resources"": []}, {""task"": """", ""subtasks"": [], ""resources"": []}, {""task"": """", ""subtasks"": [], ""resources"": []} ], ""milestones"": [] }, ""intermediate"": { ""tasks"": [ {""task"": """", ""subtasks"": [], ""resources"": []}, {""task"": """", ""subtasks"": [], ""resources"": []}, {""task"": """", ""subtasks"": [], ""resources"": []} ], ""milestones"": [] }, ""advanced"": { ""tasks"": [ {""task"": """", ""subtasks"": [], ""resources"": []}, {""task"": """", ""subtasks"": [], ""resources"": []}, {""task"": """", ""subtasks"": [], ""resources"": []} ], ""milestones"": [] } }, ""supplementary_skills"": [], ""stay_abreast_strategies"": [] }";

        /// <summary>
        /// Generates a roadmap based on the provided parameters using the OpenAI GPT-3.5 Turbo model.
        /// </summary>
        /// <param name="sphere">The sphere value.</param>
        /// <param name="level">The level value.</param>
        /// <param name="aim">The aim value.</param>
        /// <returns>The deserialized roadmap object.</returns>
        /// <exception cref="Exception">Thrown when an error occurs during the generation process.</exception>
        public static async Task<RootObject> GenerateRoadMap(string sphere, string level, string aim)
        {
            try
            {
                log.Info("Starting generate roadmap");
                if (string.IsNullOrWhiteSpace(sphere) || string.IsNullOrWhiteSpace(level) || string.IsNullOrWhiteSpace(aim))
                {
                    throw new ArgumentException("Invalid input parameters. Sphere, level, and aim cannot be null or empty.");
                }

                var openAiService = new OpenAIService(new OpenAiOptions()
                {
                    ApiKey = OpenApiKey,
                });

                var prompt = string.Format(promptTemplate1, sphere, level, aim) + promptTemplate2;

                var completionResult = await openAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
                {
                    Messages = new List<ChatMessage>
                {
                    ChatMessage.FromSystem("You are a helpful assistant providing a roadmap."),
                    ChatMessage.FromUser(prompt),
                },
                    Model = Models.Gpt_3_5_Turbo,
                    MaxTokens = 2000
                });


                if (completionResult.Successful)
                {
                    var jsonString = completionResult.Choices.FirstOrDefault()?.Message.Content;

                    if (!string.IsNullOrEmpty(jsonString))
                    {
                        RootObject obj = DeserializeRoadMap(jsonString);
                        EnsureDirectoryExists();
                        string fileName = $"{obj.Aim}_{DateTime.Now:yyyyMMdd_HHmmss}.json";
                        string filePath = Path.Combine(roadmapDirectory, fileName);

                        File.WriteAllText(filePath, jsonString);
                        log.Info("Roadmap was succesful generated");
                        return obj;
                    }
                    else
                    {
                        throw new InvalidOperationException();
                    }

                }
                else
                {
                    throw new InvalidOperationException($"Error: {completionResult.Error?.Message ?? "Unknown error"}");
                }
            }
            catch(Exception ex)
            {
                log.Error($"An unexpected error occurred: {ex.Message}", ex);
                throw;
            }
        }

        /// <summary>
        /// Reads a JSON file from the specified directory, deserializes it, and returns the RootObject.
        /// </summary>
        /// <param name="fileName">The name of the JSON file to read.</param>
        /// <returns>RootObject representing the contents of the JSON file.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static RootObject ReadRoadMapFromFile(string fileNamePrefix)
        {
            try
            {
                log.Info($"Reading roadmap from file for prefix '{fileNamePrefix}'");
                EnsureDirectoryExists();
                string[] matchingFiles = Directory.GetFiles(roadmapDirectory, $"{fileNamePrefix}_*.json");

                if (matchingFiles.Length > 0)
                {
                    // Take the first file as it is the latest based on creation time
                    string latestFilePath = matchingFiles[0];

                    if (!string.IsNullOrEmpty(latestFilePath))
                    {
                        string jsonContent = File.ReadAllText(latestFilePath);

                        if (!string.IsNullOrEmpty(jsonContent))
                        {
                            log.Info($"Roadmap successfully read from file with prefix: {latestFilePath}");
                            return DeserializeRoadMap(jsonContent);
                        }
                        else
                        {
                            throw new InvalidOperationException("JSON file is empty.");
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException($"Failed to determine the latest file for prefix '{fileNamePrefix}'.");
                    }
                }
                else
                {
                    throw new InvalidOperationException($"No matching file found for prefix '{fileNamePrefix}'.");
                }
            }
            catch(InvalidOperationException ex)
            {
                log.Error($"An unexpected error occurred: {ex.Message}", ex);
                throw;
            }

        }

        /// <summary>
        /// Gets a list of roadmap names by extracting the part of the file name before the first underscore
        /// from all JSON files in the "Roadmaps" directory.Sort it by creationTime by descending
        /// </summary>
        /// <returns>A list of roadmap names.</returns>
        public static List<string> GetAllRoadmaps()
        {
            try
            {
                log.Debug("Getting all roadmaps");
                EnsureDirectoryExists();

                string[] files = Directory.GetFiles(roadmapDirectory, "*.json");

                List<string> roadmapNames = new List<string>();

                var sortedFiles = from file in files orderby new FileInfo(file).CreationTime descending select file;

                foreach (string filePath in sortedFiles)
                {
                    string fileName = Path.GetFileNameWithoutExtension(filePath);

                    int indexOfUnderscore = fileName.IndexOf('_');
                    if (indexOfUnderscore != -1)
                    {
                        string roadmapName = fileName.Substring(0, indexOfUnderscore);
                        roadmapNames.Add(roadmapName);
                    }
                }
                log.Debug($"Found {roadmapNames.Count} roadmaps");
                return roadmapNames;
            }
            catch (Exception ex)
            {
                log.Error($"An unexpected error occurred: {ex.Message}", ex);
                throw;  
            }
        }

		public static void MoveRoadmapToCompleted(string roadmapPrefix)
		{
			try
			{
				EnsureDirectoryExists();

				string[] matchingFiles = Directory.GetFiles(roadmapDirectory, $"{roadmapPrefix}_*.json");

				if (matchingFiles.Length > 0)
				{
					string latestFilePath = matchingFiles[0];

					if (!string.IsNullOrEmpty(latestFilePath))
					{
						string completedDirectory = Path.Combine(AppContext.BaseDirectory, "Roadmaps", "Completed");
						EnsureDirectoryExists(completedDirectory);

						string newFilePath = Path.Combine(completedDirectory, Path.GetFileName(latestFilePath));

						File.Move(latestFilePath, newFilePath);
						log.Info($"Roadmap moved to Completed directory: {newFilePath}");
					}
					else
					{
						throw new InvalidOperationException($"Failed to determine the latest file for prefix '{roadmapPrefix}'.");
					}
				}
				else
				{
					throw new InvalidOperationException($"No matching file found for prefix '{roadmapPrefix}'.");
				}
			}
			catch (Exception ex)
			{
				log.Error($"An unexpected error occurred: {ex.Message}", ex);
				throw;
			}
		}

		private static RootObject DeserializeRoadMap(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<RootObject>(json)
                    ?? throw new JsonException("Deserialization failed");
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("Deserialization failed", ex);
            }
        }

 
        private static void EnsureDirectoryExists()
        {
            if (!Directory.Exists(roadmapDirectory))
            {
                Directory.CreateDirectory(roadmapDirectory);
            }
        }

		private static void EnsureDirectoryExists(string directoryPath)
		{
			if (!Directory.Exists(directoryPath))
			{
				Directory.CreateDirectory(directoryPath);
			}
		}

	}
}
