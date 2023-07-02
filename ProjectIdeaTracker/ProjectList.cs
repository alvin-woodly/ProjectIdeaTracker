using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIdeaTracker
{
    static class ProjectList
    {
        private static Dictionary<string,Project> listOfProjects = new Dictionary<string,Project>();

        public static void AddProject(string title, string description)
        {
            listOfProjects.Add(title, new Project(title,description));
        }

        public static void RemoveProject(string projectname)
        {
            listOfProjects.Remove(projectname);
        }
    }
}
