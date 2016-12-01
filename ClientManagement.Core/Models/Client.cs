using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Core.Exceptions;


namespace ClientManagement.Core.Models
{
    public class Client
    {
        public Client()
        {
            Projects = new List<ProjectEntity>();
        }
        public Guid Id { get; set; }
        public string  ClientName{get;set;}
        public string Address { get; set; }
        public List<ProjectEntity> Projects { get; set; }


        public void AddProject(ProjectEntity project)
        {
            var cantAddProject = CantAddProject(project);
            if (cantAddProject)
                throw new ProjectExistException();

            Projects.Add(project);
        }

        public int NumberOfProjects()
        {
            return Projects.Count;
        }

        public bool CantAddProject(ProjectEntity project)
        {
            return Projects.Contains(project);

        }



    }

    
}
