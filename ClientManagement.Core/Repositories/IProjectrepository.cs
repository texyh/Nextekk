using System;
using System.Collections.Generic;
using ClientManagement.Core.Models;


namespace ClientManagement.Core.Repositories
{
    public interface IProjectRepository
    {
        void Create(Project projectEntity);
        void EditProject(Project projectEntity);
        List<Project> GetAllProjects();
        Project GetProject(Guid Id);
        void PersistProject();
    }
}