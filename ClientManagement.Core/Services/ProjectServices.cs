using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Core.Models;
using ClientManagement.Core.Repositories;


namespace ClientManagement.Core.Services
{
    public class ProjectServices : IProjectServices
    {
        private IProjectRepository _projectRepository;
        public ProjectServices(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public List<Project> GetAllProjects()
        {
            var projects = _projectRepository.GetAllProjects();
            return projects;
        }

        public Project GetProject(Guid Id)
        {
            var Projects = GetAllProjects();
            var Project = Projects.FirstOrDefault(p => p.Id == Id);
            return Project;
        }


        public ICollection<Employee> ProjectEmployees(Guid projectId)
        {
            var project = GetProject(projectId);
            var projectEmployees = project.Employees;
            return projectEmployees;
        }



    }
}
