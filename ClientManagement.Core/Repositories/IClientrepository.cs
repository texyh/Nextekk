using System;
using ClientManagement.Core.Models;
using System.Collections.Generic;

namespace ClientManagement.Core.Repositories
{
    public interface IClientRepository
    {

        void Create(Client client);
        List<Client> GetAllClients();
        Client GetClient(Guid Id);
        Client GetClientOnly(Guid Id);
        void Update(Client client);




    }
}