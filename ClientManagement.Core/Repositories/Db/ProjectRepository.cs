﻿using System;
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





        public void Create(Project project)
        {
            project.Id = Guid.NewGuid();
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
