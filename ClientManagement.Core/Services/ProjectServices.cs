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
            var Project = _projectRepository.GetProjectOnly(Id);
            return Project;
        }

        public void Save(Project project)
        {
            var dbProject = _projectRepository.GetProjectOnly(project.Id);

            if (dbProject == null)
                _projectRepository.Create(project);
            else
                _projectRepository.UpdateProject(project);
        }

        public ICollection<Employee> ProjectEmployees(Guid projectId)
        {
            var project = GetProject(projectId);
            var projectEmployees = project.Employees.ToList();
            return projectEmployees;
        }





    }
}
