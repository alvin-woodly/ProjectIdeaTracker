﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIdeaTracker
{
    public class Project
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public ProjectState CurrentState { get; set; } = ProjectState.Uncommenced;
               
        public Project(string title, string description) 
        {
            Title = title;
            Description = description;
        }

        public override string ToString() => $"{Title}: \n{Description}";
    }

   
}
