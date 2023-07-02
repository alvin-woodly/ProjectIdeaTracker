using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIdeaTracker
{
    public static class ProjectList
    {
        //make private after tests:
        public static Dictionary<string,Project> listOfProjects = new Dictionary<string,Project>();

        public static void AddProject(string title, string description)
        {
            listOfProjects.Add(title, new Project(title,description));
        }

        public static string RemoveProject(string projectname)
        {
            if(listOfProjects.ContainsKey(projectname))
            {
                listOfProjects.Remove(projectname);
                return $"Successfully removed project {projectname}";
            }
            else
            {
                return $"Project {projectname} does not exist, you may have mistyped the name";
            }
        }

        public static Project GetProject(string projectname) 
        { 
            if(listOfProjects.ContainsKey(projectname))
            {
                return listOfProjects[projectname];
            }
            else
            {
                return null;
            }
        }

        public static void RemoveAllProjects()
        {
            Console.WriteLine("Are you sure you want to remove all projects?");
            var answer = Console.ReadLine() switch
            {
                "yes" => true,
                "Yes" => true,
                "no" => false,
                "No" => false,
                _ => false
            };
           
            if(answer)
            {
                listOfProjects.Clear();
            }
            else
            {
                return;
            }
        }

        public static void ShowListOfProjects()
        {
            foreach( Project project in listOfProjects.Values)
            {
                Console.WriteLine($"\n{project}");
            }
        }

        public static List<Project> SortProjects(string input)
        {
       
            Console.WriteLine($"project states are : {string.Join(" ",Enum.GetNames(typeof(ProjectState)))}");
            if (Enum.TryParse(input, out ProjectState projectstate))
            {
                var groupedProjects =
                    listOfProjects.Values
                    .GroupBy(project => project.CurrentState)
                    .Where(projectgroup => projectgroup.Key == projectstate)
                    .Select(project => project);

                List<Project> SortedProjects = new List<Project>();
                
                foreach(Project project in groupedProjects)
                {
                    SortedProjects.Add(project);
                }

                return SortedProjects;
            }
            else
            {
                Console.WriteLine("not a valid state for a project, showing all projects:");
                return listOfProjects.Values.ToList();
            }
        
        }

        // method for changing project state
    }
}
