using System;
using System.Collections.Generic;
using ClientManagement.Core.Models;


namespace ClientManagement.Core.Repositories
{
    public interface IProjectRepository
    {
        void Create(Project projectEntity);
        void UpdateProject(Project project);
        List<Project> GetAllProjects();
        Project GetProject(Guid Id);
        Project GetProjectOnly(Guid Id);

    }
}