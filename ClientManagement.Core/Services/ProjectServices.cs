using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Core.Models;
using ClientManagement.Core.Repositories.FileSystem;


namespace ClientManagement.Core.Services
{
    class ProjectServices
    {
        private IProjectrepository _projectRepository;
        public ProjectServices(IProjectrepository projectRepository) {
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

        public Project ToProject(ProjectEntity projectEntity)
        {
            var project = new Project();
            project.Id = projectEntity.Id;
            project.Description = projectEntity.Description;
            project.Status = projectEntity.Status;

            return project;

        }

        public void AddEmployee(EmployeeEntity employee,Guid projectId)
        {
            var Project = GetProject(projectId);
            Project.AddEmploye(employee);
        }

        public void AssignClient(ClientEntity client,Guid projectId)
        {
            var Project = GetProject(projectId);
            Project.Client = client;
        }



    }
}
