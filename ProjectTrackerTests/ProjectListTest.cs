using ProjectIdeaTracker;

namespace ProjectTrackerTests
{
    [TestClass]
    public class ProjectListTest
    {
        [TestMethod]
        public void TestAddProject()
        {
            ProjectList.AddProject("Test1", "TestProject1");
            ProjectList.AddProject("Test2", "TestProject2");
            ProjectList.AddProject("Test3", "TestProject3");

            CollectionAssert.AreEqual(new[] { "Test1", "Test2", "Test3" },
                ProjectList.listOfProjects.Keys);

            var projectDescriptions = ProjectList.listOfProjects.Values
                .Select(project => project.Description);

            CollectionAssert.AreEqual(new[] { "TestProject1", "TestProject2", "TestProject3" }, 
                projectDescriptions.ToList());
        }

        [TestMethod]
        public void TestRemoveProject()
        {
            ProjectList.AddProject("Test4", "TestProject4");
            ProjectList.AddProject("Test5", "TestProject5");
            ProjectList.AddProject("Test6", "TestProject6");

            Assert.AreEqual("Successfully removed project Test6",ProjectList.RemoveProject("Test6"));
            CollectionAssert.AreEqual(new[] {"Test1","Test2","Test3","Test4","Test5"}, 
                ProjectList.listOfProjects.Keys);

            Assert.AreEqual("Project Jeff does not exist, you may have mistyped the name", 
                ProjectList.RemoveProject("Jeff"));
        }
    }
}