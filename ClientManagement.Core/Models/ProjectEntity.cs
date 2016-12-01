using System;

namespace ClientManagement.Core.Models
{
    public class ProjectEntity
    {

        public Guid Id { get; set; }
        public string Title { get; set; }
        public ClientEntity Client { get; set; }
        public string Description { get; set; }
        public ProjectStatus Status { get; set; }
    }
}