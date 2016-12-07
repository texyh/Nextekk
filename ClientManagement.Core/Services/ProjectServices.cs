using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Core.Models;
using ClientManagement.Core.Repositories;


namespace ClientManagement.Core.Services
{
    public class ProjectServices
    {
        private IProjectRepository _projectRepository;
        public ProjectServices(IProjectRepository projectRepository) {
            _projectRepository = projectRepository;
        }
        
        public List<Project> GetAllProjects()
        {
            var projects = _projectRepository.GetAllProjects();
            return projects.Select(x => ToProject(x)).ToList();
        }

        public Project GetProject(Guid Id)
        {
            var Projects = GetAllProjects();
            var Project = Projects.FirstOrDefault(p => p.Id == Id);
            return Project;
        }

        public Project ToProject(Project projectEntity)
        {
            var project = new Project();
            project.Id = projectEntity.Id;
            project.Description = projectEntity.Description;
            project.Status = projectEntity.Status;

            return project;

        }

        public void AddEmployeeToProject(Employee employee,Project project)
        {
            project.AddEmploye(employee);
        }

       /* public void AssignClient(Client client,Guid projectId)
        {
            var Project = GetProject(projectId);
            Project.Client = client;
        }*/



    }
}
