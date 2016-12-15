using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Core.Models;
using System.Data.Entity;
using ClientManagement.Core.Repositories.Db;

namespace ClientManagement.Core.Repositories
{
    public class ProjectRepository : IProjectRepository, IDisposable
    {

        private readonly ClientManagementContext _context;
        private readonly bool _externalContext;

        public ProjectRepository()
        {
            _context = new ClientManagementContext();
        }

        public ProjectRepository(ClientManagementContext context)
        {
            _context = context;
            _externalContext = true;
        }

        public Guid GetClientId(string name)
        {
            var client = _context.Clients.FirstOrDefault(x => x.Name == name);
            return client.Id;
        }



        public void Create(Project project)
        {
            var ClientId = GetClientId(project.ClientName);
            project.Id = Guid.NewGuid();
            project.ClientId = ClientId;
            project.EndDate = project.EndDate.Date;
            project.StartDate = project.StartDate.Date;
            _context.Projects.Add(project);
            _context.SaveChanges();
        }

        public void UpdateProject(Project project)
        {
            var dbProject = GetProjectOnly(project.Id);
            dbProject.Description = project.Description;
            dbProject.EndDate = project.EndDate;
            dbProject.Title = project.Title;
            dbProject.Status = project.Status;
            dbProject.StartDate = project.StartDate;
            dbProject.ClientName = project.ClientName;
            _context.SaveChanges();

        }

        public List<Project> GetAllProjects()
        {
            return _context.Projects.ToList();
        }

        public Project GetProject(Guid Id)
        {
            
            var project = _context.Projects.Include(e => e.Employees).FirstOrDefault(x => x.Id == Id);
            return project;

        }

        public Project GetProjectOnly(Guid Id)
        {
            return _context.Projects.Find(Id);
        }

        

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
