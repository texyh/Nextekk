using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientManagement.Core.Models;
namespace ClientManagement.Tests.Helpers
{
    public class ProjectData
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

        public static Guid Project3Id
        {
            get
            {
                return new Guid("a40d9803-b4fc-4ddc-9fbb-6dd99c41760f");
            }
        }

        public static Guid Project4Id
        {
            get
            {
                return new Guid("a40d9803-b4fc-4ddc-9fbb-6dd99c41760f");
            }
        }
        public static List<Project> ProjectEntities
        {
            get
            {
                return new List<Project>
                {
                    new Project { Id = Project1Id, Title = "Rehabilitation of block class rooms", Description = "Rehabilitation of uyo high school",Status=ProjectStatus.InProgress},
                    new Project { Id = Project2Id, Title = "Design of an Ecommerce store", Description = "Design of Ecommerce store for students",Status=ProjectStatus.Completed}
                };
            }
        }

        public static List<Project> Projects
        {
            get
            {
                return new List<Project>
                {
                    new Project { Id = Project3Id, Title = "Rehabilation of class room", Description = "Rehabilitation of uyo high school",Status=ProjectStatus.InProgress},
                    new Project { Id = Project4Id, Title = "Design of an Ecommerce store", Description = "Design of Ecommerce store for students",Status=ProjectStatus.Completed}
                };
            }
        }


        public static Project project
        {
            get
            {
                return new Project() { Id = Project1Id, Title = "Rehabilation of class room", Description = "Rehabilitation of uyo high school", Status = ProjectStatus.InProgress };
                
            }
        }

        public static Project project2
        {
            get
            {
                return new Project() { Id = Guid.NewGuid(), Title = "Construction of hostel", Description = "Construction of hostel for ABU, Zaria", Status = ProjectStatus.InProgress };

            }
        }

    }
}
