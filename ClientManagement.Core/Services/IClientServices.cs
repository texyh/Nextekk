using System;
using System.Collections.Generic;
using ClientManagement.Core.Models;

namespace ClientManagement.Core.Services
{
    public interface IClientServices
    {
        ICollection<Project> GetAllClientProjects(Guid ClientId);
        List<Client> GetAllClients();
        Client GetClient(Guid Id);
    }
}