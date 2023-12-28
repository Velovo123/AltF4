
using System;

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
            Assert.IsTrue(roadmap.Roadmap.Intermediate.Tasks[0].Resources.Any());
            Assert.IsTrue(roadmap.Roadmap.Intermediate.Tasks[1].Resources.Any());
            Assert.IsTrue(roadmap.Roadmap.Intermediate.Tasks[2].Resources.Any());
            Assert.IsTrue(roadmap.Roadmap.Advanced.Tasks[0].Resources.Any());
            Assert.IsTrue(roadmap.Roadmap.Advanced.Tasks[1].Resources.Any());
            Assert.IsTrue(roadmap.Roadmap.Advanced.Tasks[2].Resources.Any());
            Assert.IsTrue(roadmap.Roadmap.Beginner.Tasks[0].Resources.Any());
            Assert.IsTrue(roadmap.Roadmap.Beginner.Tasks[1].Resources.Any());
            Assert.IsTrue(roadmap.Roadmap.Beginner.Tasks[2].Resources.Any());
            Assert.IsFalse(roadmap.Roadmap.Advanced.Tasks[0].Resources[0].Contains(' '));
            Assert.IsTrue(roadmap.Roadmap.Advanced.Tasks[0].Resources[0].Contains("https://"));
        }

        //[TestCleanup]
        //public void TestCleanup()
        //{
        //    if (Directory.Exists(roadmapDirectory))
        //    {
        //        string[] files = Directory.GetFiles(roadmapDirectory, "*.json");

        //        foreach (string file in files)
        //        {
        //            File.Delete(file);
        //        }
        //    }
        //}



    }
}