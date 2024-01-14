
namespace SkillAppTests
{
    [TestClass]
    public class OperatorTest
    {
        private static readonly string roadmapDirectory = Path.Combine(AppContext.BaseDirectory, "Roadmaps");

        [TestMethod]
        public async Task GenerateRoadMap_ValidInput_ReturnsRoadMap()
        {
            Operator.GetApiKeyFromAzure();
            //Arrange
            var spheres = new List<string> { "Programming", "Data Science", "Web Development", "Machine Learning", "Cybersecurity" };
            var levels = new List<string> { "Beginner", "Intermediate", "Advanced" };
            var aims = new List<string> { "Learn the Basics", "Build Advanced Projects", "Master the Craft", "Specialize in a Field" };

            Random random = new Random();
            string sphere = spheres[random.Next(spheres.Count)];
            string level = levels[random.Next(levels.Count)];
            string aim = aims[random.Next(aims.Count)];

            // Act
            var roadmap = await Operator.GenerateRoadMap(sphere, level, aim);

            // Assert
            Assert.IsNotNull(roadmap);
            Assert.IsNotNull(roadmap.Roadmap);
            Assert.IsNotNull(roadmap.Title);
            Assert.IsNotNull(roadmap.Aim);
            Assert.IsNotNull(roadmap.Supplementary_skills);
            Assert.IsNotNull(roadmap.Stay_abreast_strategies);
            Assert.IsNotNull(roadmap.Roadmap.Beginner);
            Assert.IsNotNull(roadmap.Roadmap.Intermediate);
            Assert.IsNotNull(roadmap.Roadmap.Advanced);
            Assert.IsNotNull(roadmap.Roadmap.Beginner.Milestones);
            Assert.IsNotNull(roadmap.Roadmap.Intermediate.Milestones);
            Assert.IsNotNull(roadmap.Roadmap.Advanced.Milestones);
            Assert.AreEqual(3, roadmap.Roadmap.Beginner.Tasks.Count);
            Assert.AreEqual(3, roadmap.Roadmap.Intermediate.Tasks.Count);
            Assert.AreEqual(3, roadmap.Roadmap.Advanced.Tasks.Count);
            Assert.AreEqual(3, roadmap.Roadmap.Beginner.Tasks[0].Subtasks.Count);
            Assert.AreEqual(3, roadmap.Roadmap.Beginner.Tasks[1].Subtasks.Count);
            Assert.AreEqual(3, roadmap.Roadmap.Beginner.Tasks[2].Subtasks.Count);
            Assert.AreEqual(3, roadmap.Roadmap.Intermediate.Tasks[0].Subtasks.Count);
            Assert.AreEqual(3, roadmap.Roadmap.Intermediate.Tasks[1].Subtasks.Count);
            Assert.AreEqual(3, roadmap.Roadmap.Intermediate.Tasks[2].Subtasks.Count);
            Assert.AreEqual(3, roadmap.Roadmap.Advanced.Tasks[0].Subtasks.Count);
            Assert.AreEqual(3, roadmap.Roadmap.Advanced.Tasks[1].Subtasks.Count);
            Assert.AreEqual(3, roadmap.Roadmap.Advanced.Tasks[2].Subtasks.Count);
            Assert.IsTrue(roadmap.Roadmap.Intermediate.Tasks[0].Resources.Count > 0);
            Assert.IsTrue(roadmap.Roadmap.Intermediate.Tasks[1].Resources.Count > 0);
            Assert.IsTrue(roadmap.Roadmap.Intermediate.Tasks[2].Resources.Count > 0);
            Assert.IsTrue(roadmap.Roadmap.Advanced.Tasks[0].Resources.Count > 0);
            Assert.IsTrue(roadmap.Roadmap.Advanced.Tasks[1].Resources.Count > 0);
            Assert.IsTrue(roadmap.Roadmap.Advanced.Tasks[2].Resources.Count > 0);
            Assert.IsTrue(roadmap.Roadmap.Beginner.Tasks[0].Resources.Count > 0);
            Assert.IsTrue(roadmap.Roadmap.Beginner.Tasks[1].Resources.Count > 0);
            Assert.IsTrue(roadmap.Roadmap.Beginner.Tasks[2].Resources.Count > 0);
            Assert.IsFalse(roadmap.Roadmap.Advanced.Tasks[0].Resources[0].Contains(' '));
            Assert.IsTrue(roadmap.Roadmap.Advanced.Tasks[0].Resources[0].Contains("https://"));
        }

        [TestMethod]
        public async Task GenerateRoadMap_InvalidInput_ThrowsArgumentException()
        {
            //Arrange
            var sphere = "";
            string? level = null;
            var aim = " ";

            //Act and Assert
            await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await Operator.GenerateRoadMap(sphere, level, aim));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "JSON file is empty.")]
        public void ReadRoadMapFromFile_EmptyJsonFile_ThrowsInvalidOperationException()
        {
            Operator.ReadRoadMapFromFile("Learn the Basics of Data Science");
        }
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Failed to determine the latest file for prefix 'NonexistentPrefix'.")]
        public void ReadRoadMapFromFile_NoMatchingFile_ThrowsInvalidOperationException()
        {
            Operator.ReadRoadMapFromFile(" ");
        }

        [TestMethod]
        public void GetAllRoadmaps_ReturnsSortedRoadmapNames()
        {
            // Arrange
            CreateSampleRoadmapFile("Programming_20230101_120000.json");
            CreateSampleRoadmapFile("DataScience_20230102_130000.json");
            CreateSampleRoadmapFile("MachineLearning_20230103_140000.json");

            // Act
            List<string> roadmapNames = Operator.GetAllRoadmaps();

            // Assert
            CollectionAssert.AreEquivalent(new List<string> { "MachineLearning", "DataScience", "Programming" }
            , roadmapNames);

        }

        [TestMethod]
        public void MoveRoadmapToCompleted_ValidRoadmap_MovesFileToCompletedDirectory()
        {
            // Arrange
            CreateSampleRoadmapFile("Programming_20231228_120000.json");
            string roadmapPrefix = "Programming";

            // Act
            Operator.MoveRoadmapToCompleted(roadmapPrefix);

            // Assert
            string completedDirectory = Path.Combine(roadmapDirectory, "Completed");
            string completedFilePath = Path.Combine(completedDirectory, "Programming_20231228_120000.json");

            Assert.IsTrue(File.Exists(completedFilePath), "File should exist in Completed directory");
            Assert.IsFalse(File.Exists(Path.Combine(roadmapDirectory, "Programming_20231228_120000.json")),
                "File should be removed from the original directory");
        }

        private static void CreateSampleRoadmapFile(string fileName)
        {
            string filePath = Path.Combine(roadmapDirectory, fileName);
            File.WriteAllText(filePath, "{}");
        }

		[TestCleanup]
        public void TestCleanup()
        {
			string[] files = Directory.GetFiles(roadmapDirectory, "*.json");
			if (Directory.Exists(roadmapDirectory))
            {
				foreach (string file in files)
				{
					File.Delete(file);
				}
			}
			if (Directory.Exists(Path.Combine(roadmapDirectory, "Completed")))
            {
                string[] directoryFiles = Directory.GetFiles(Path.Combine(roadmapDirectory, "Completed"), "*.json");
                foreach (string file in directoryFiles)
                {
                    File.Delete(file);
                }
                Directory.Delete(Path.Combine(roadmapDirectory, "Completed"));
            }

        }



    }
}