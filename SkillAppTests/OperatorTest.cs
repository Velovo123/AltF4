
namespace SkillAppTests
{
    [TestClass]
    public class OperatorTest
    {
        private static readonly string roadmapDirectory = Path.Combine(AppContext.BaseDirectory, "Roadmaps");

        [TestMethod]
        public async Task GenerateRoadMap_ValidInput_ReturnsRoadMap()
        {
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
        public void ReadRoadMapFromFile_FileFound_ReturnsRootObject()
        {
            //Act
            var obj = Operator.ReadRoadMapFromFile("Learn the Basics of Advanced Machine Learning");
            
            //Assert
            Assert.IsNotNull(obj);
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
            CollectionAssert.AreEquivalent(new List<string> { "MachineLearning", "DataScience", "Programming",
        "Learn the Basics of Data Science","Learn the Basics of Advanced Machine Learning"}, roadmapNames);

        }

        private static void CreateSampleRoadmapFile(string fileName)
        {
            string filePath = Path.Combine(roadmapDirectory, fileName);
            File.WriteAllText(filePath, "{}");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (Directory.Exists(roadmapDirectory))
            {
                string[] files = Directory.GetFiles(roadmapDirectory, "*.json");

                foreach (string file in files)
                {
                    if (!file.EndsWith("Learn the Basics of Data Science_20231228_124805.json",
                        StringComparison.OrdinalIgnoreCase)
                        && !file.EndsWith("Learn the Basics of Advanced Machine Learning_20231228_015012.json",
                        StringComparison.OrdinalIgnoreCase))
                    {
                        File.Delete(file);
                    }
                }
            }
        }



    }
}