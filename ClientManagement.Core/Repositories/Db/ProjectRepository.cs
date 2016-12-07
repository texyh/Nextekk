using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Core.Models;

namespace ClientManagement.Core.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public void Create(Project project)
        {
            throw new NotImplementedException();
        }

        public void EditProject(Project project)
        {
            throw new NotImplementedException();
        }

        public List<Project> GetAllProjects()
        {
            throw new NotImplementedException();
        }

        public Project GetProject(Guid Id)
        {
            //include  navigation properties
            throw new NotImplementedException();
        }

        public Project GetProjectOnly(Guid id)
        {
            //don't include navigation properties
            throw new NotImplementedException();
        }

        public void PersistProject()
        {
            throw new NotImplementedException();
        }
    }
}
