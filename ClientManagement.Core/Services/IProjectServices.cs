using System;
using System.Collections.Generic;
using ClientManagement.Core.Models;

namespace ClientManagement.Core.Services
{
    public interface IProjectServices
    {
        List<Project> GetAllProjects();
        Project GetProject(Guid Id);
        ICollection<Employee> ProjectEmployees(Guid projectId);
    }
}