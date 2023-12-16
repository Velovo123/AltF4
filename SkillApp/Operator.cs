using Newtonsoft.Json;
using OpenAI;
using OpenAI.Managers;
using OpenAI.ObjectModels.RequestModels;
using OpenAI.ObjectModels;

namespace SkillApp
{
    internal static class Operator
    {
        private const string OpenApiKey = "YOUR_OPENAI_API_KEY";
        
        private static readonly string roadmapDirectory = Path.Combine(
            Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName,"Roadmaps");

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
            

            var completionResult = await openAiService.Completions.CreateCompletion(new CompletionCreateRequest()
            {
                Prompt = prompt,
                Model = Models.Gpt_3_5_Turbo,             
                MaxTokens = 200                             //(3833min  -  4096max) ------- MODIFIED PROMPT 1785min 
            });


            if (completionResult.Successful)
            {
                var jsonString = completionResult.Choices.FirstOrDefault()?.Text; // ?? NE ZNAIU BUDE ROBUTU CHI NE

                if (!string.IsNullOrEmpty(jsonString))
                {
                    RootObject obj = DeserializeRoadMap(jsonString);
                    string fileName = $"{obj.aim}_{DateTime.Now:yyyyMMdd_HHmmss}.json";   // VRODE BOBMA 
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
        public static RootObject ReadRoadMapFromFile(string fileName)
        {
            string filePath = Path.Combine(roadmapDirectory, fileName);

            if (File.Exists(filePath))
            {
                string jsonContent = File.ReadAllText(filePath);

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
                throw new InvalidOperationException($"File not found: {filePath}");
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



    }
}
