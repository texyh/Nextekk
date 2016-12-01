using System;
using System.Collections.Generic;
using ClientManagement.Core.Models;


namespace ClientManagement.Core.Repositories.FileSystem
{
    interface IProjectrepository
    {
        void CreateProject(ProjectEntity projectEntity);
        void EditProject(ProjectEntity projectEntity);
        List<ProjectEntity> GetAllProjects();
        ProjectEntity GetProject(Guid Id);
        void PersistProject();
    }
}