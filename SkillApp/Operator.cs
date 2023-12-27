using Newtonsoft.Json;
using OpenAI;
using OpenAI.Managers;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels;

namespace SkillApp
{
    internal static class Operator
    {
        private const string OpenApiKey = "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";

        private static readonly string roadmapDirectory = Path.Combine(AppContext.BaseDirectory, "Roadmaps");

        /// <summary>
        /// Generates a roadmap based on the provided prompt using the OpenAI GPT-3.5 Turbo model.
        /// </summary>
        /// <param name="prompt">The prompt to generate the roadmap.</param>
        /// <returns>The deserialized roadmap object.</returns>
        /// <exception cref="InvalidOperationException">Thrown when an error occurs during the generation process.</exception>
        public static async Task<RootObject> GenerateRoadMap(string prompt)
        {

            var openAiService = new OpenAIService(new OpenAiOptions()
            {
                ApiKey = OpenApiKey,
            });


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

        /// <summary>
        /// Reads a JSON file from the specified directory, deserializes it, and returns the RootObject.
        /// </summary>
        /// <param name="fileName">The name of the JSON file to read.</param>
        /// <returns>RootObject representing the contents of the JSON file.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static RootObject ReadRoadMapFromFile(string fileNamePrefix)
        {
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

        /// <summary>
        /// Gets a list of roadmap names by extracting the part of the file name before the first underscore
        /// from all JSON files in the "Roadmaps" directory.
        /// </summary>
        /// <returns>A list of roadmap names.</returns>
        public static List<string> GetAllRoadmaps()
        {
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

            return roadmapNames;
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

    }
}
