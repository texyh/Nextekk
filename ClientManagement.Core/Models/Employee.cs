using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Core.Exceptions;

namespace ClientManagement.Core.Models
{
    public class Employee
    {
        public Employee()
        {
            Projects = new List<ProjectEntity>();
        }
        public Guid Id { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Gender { get; set; }
        private List<ProjectEntity> Projects { get; set; }

        public void AssignProject(ProjectEntity project)
        {
            var cantAssignProject = CantAssignProject(project);
            if (cantAssignProject)
               throw new ProjectExistException();

            Projects.Add(project);
        }

        public int NumberOfProjects()
        {
            return Projects.Count;
        }

        public bool CantAssignProject(ProjectEntity project)
        {
            return Projects.Contains(project);
            
        }

        public void RemoveProject(ProjectEntity projectEntity)
        {
            var project = Projects.Contains(projectEntity);
            if (project)
            {
                Projects.Remove(projectEntity);

            }
            else
            {
                throw new InvalidOperationException("Project not found");

            }


        }
    }
}
