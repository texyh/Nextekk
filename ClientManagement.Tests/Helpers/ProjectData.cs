using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Core.Models;
namespace ClientManagement.Tests.Helpers
{
    class ProjectData
    {
        public static Guid Project1Id
        {
            get
            {
                return new Guid("ab0db2b1-2b62-4aef-8781-454fe93e7f85");
            }
        }

        public static Guid Project2Id
        {
            get
            {
                return new Guid("a40d9803-b4fc-4ddc-9fbb-6dd99c41760f");
            }
        }

        public static List<ProjectEntity> ProjectEntities
        {
            get
            {
                return new List<ProjectEntity>
                {
                    new ProjectEntity { Id = Project1Id, Title = "Rehabilation of class room", Description = "Rehabilitation of uyo high school",Status=ProjectStatus.InProgress},
                    new ProjectEntity { Id = Project2Id, Title = "Design of an Ecommerce store", Description = "Design of Ecommerce store for students",Status=ProjectStatus.Completed}
                };
            }
        }

        public static ProjectEntity project
        {
            get
            {
                return new ProjectEntity() { Id = Project1Id, Title = "Rehabilation of class room", Description = "Rehabilitation of uyo high school", Status = ProjectStatus.InProgress };
                
            }
        }

    }
}
