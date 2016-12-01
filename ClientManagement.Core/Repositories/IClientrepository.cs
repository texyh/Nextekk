using System;
using ClientManagement.Core.Models;
using System.Collections.Generic;

namespace ClientManagement.Core.Repositories.FileSystem
{
    interface IClientrepository
    {

        void CreateClient(ClientEntity client);
        void EditClient(ClientEntity client);
        List<ClientEntity> GetAllClients();
        ClientEntity GetClient(Guid Id);
        void PersistClient();
    }
}