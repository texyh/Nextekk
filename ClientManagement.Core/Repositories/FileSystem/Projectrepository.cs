using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static Newtonsoft.Json.JsonConvert;
using System.Configuration;
using System.Threading;
using ClientManagement.Core.Models;
using System.IO;

namespace ClientManagement.Core.Repositories.FileSystem
{
    class Projectrepository : IProjectrepository
    {
        private readonly string File_Path = ConfigurationManager.AppSettings["ProjectFilePath"];
        private static ReaderWriterLockSlim _readerWriterLock = new ReaderWriterLockSlim();
        private List<ProjectEntity> _projects;


        public List<ProjectEntity> GetAllProjects()
        {
            if (_projects != null)
                return _projects;

           var ProjectJson = default(string);
            _readerWriterLock.EnterReadLock();
            try
            {
                ProjectJson = File.ReadAllText(File_Path);
            }
            finally
            {
                _readerWriterLock.ExitReadLock();
            }

            _projects = DeserializeObject<List<ProjectEntity>>(ProjectJson)
                ?? new List<ProjectEntity>();
            return _projects;
        }

        public ProjectEntity GetProject(Guid Id)
        {
            var Projects = GetAllProjects();
            var Project = Projects.FirstOrDefault(p => p.Id == Id);
            return Project;
        }

        public void EditProject(ProjectEntity projectEntity)
        {
            var project = GetProject(projectEntity.Id);
            if (project == null)
                throw new InvalidOperationException("Invalid Project");

            project.Description = projectEntity.Description;
            project.Title = projectEntity.Title;
            project.Status = projectEntity.Status;

            PersistProject();
        }

        public void CreateProject(ProjectEntity projectEntity)
        {
            var projects = GetAllProjects();
            projectEntity.Id = Guid.NewGuid();
            projects.Add(projectEntity);

            PersistProject();
        }

        public void PersistProject()
        {
            var projects = GetAllProjects();
            var ProjectJson = SerializeObject(projects, Formatting.Indented);
            _readerWriterLock.EnterWriteLock();
            try
            {
                File.WriteAllText(ProjectJson, File_Path);
            }
            finally
            {
                _readerWriterLock.ExitWriteLock();
            }
        }
    }
}
