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
            Projects = new List<Project>();
        }
        public Guid Id { get; set; }
        public string  ClientName{get;set;}
        public string Address { get; set; }
        public virtual ICollection<Project> Projects { get; set; }



        public void AddProject(Project project)
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

        public bool CantAddProject(Project project)
        {
            return Projects.Contains(project);

        }

        public List<Project> GetProjects()
        {
            return Projects.ToList();
        }



    }

    
}
