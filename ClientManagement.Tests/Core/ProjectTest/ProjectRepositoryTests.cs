using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientManagement.Core.Models;
using ClientManagement.Core.Repositories.Db;
using ClientManagement.Core.Repositories;
using ClientManagement.Tests.Helpers;
using static ClientManagement.Tests.Constants;

namespace ClientManagement.Tests.Core.ProjectTest
{
    [TestClass]
    public class ProjectRepositoryTests
    {
        [TestMethod, TestCategory(IntegrationTest)]
        public void Should_Be_Able_To_Add_Project_To_DB()
        {
            using (var context = new ClientManagementContext())
            using (var repo = new ProjectRepository(context))
            using (var txn = context.Database.BeginTransaction())
            {
                var project = ProjectData.project;

                //Since the ClientId is a foriegn key 
                // The name supplied will be usesd to get the client id
                project.ClientName = "Emeka EnterPrise";

                repo.Create(project);

                var dbProject = context.Set<Project>().FirstOrDefault(x => x.Title == "Rehabilation of class room");

                txn.Rollback();

                Assert.IsNotNull(dbProject);
            }
        }

        [TestMethod, TestCategory(IntegrationTest)]
        public void Should_Be_Able_To_Retrieve_All_Projects_From_DB()
        {
            using (var context = new ClientManagementContext())
            using (var repo = new ProjectRepository(context))
            using (var txn = context.Database.BeginTransaction())
            {
                context.Set<Project>().Add(ProjectData.Projects[1]);
                context.SaveChanges();

                var projects = repo.GetAllProjects();

                txn.Rollback();

                // I already have one project in the database.
                // So the number increases by one
                Assert.AreEqual(2, projects.Count);
            }
        }
    }
}
