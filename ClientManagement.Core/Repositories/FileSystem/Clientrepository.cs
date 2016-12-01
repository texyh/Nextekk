
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Configuration;
using ClientManagement.Core.Models;
using System.IO;
using static Newtonsoft.Json.JsonConvert;
using Newtonsoft.Json;

namespace ClientManagement.Core.Repositories.FileSystem
{
    class Clientrepository : IClientrepository
    {
        private readonly string File_Path = ConfigurationManager.AppSettings["ClientFilePath"];
        private static ReaderWriterLockSlim _readerWriterLock = new ReaderWriterLockSlim();
        private List<ClientEntity> _clients;

       
        public List<ClientEntity> GetAllClients()
        {
            if (_clients != null)
                return _clients;

            _readerWriterLock.EnterReadLock();
            var clientJson = default(string);
            try
            {
                clientJson = File.ReadAllText(File_Path);
            }
            finally
            {
                _readerWriterLock.ExitReadLock();
            }

             _clients = DeserializeObject<List<ClientEntity>>(clientJson)
                ?? new List<ClientEntity>();
            return _clients;

        }

        public ClientEntity GetClient(Guid Id)
        {
            var clients = GetAllClients();
            var client = clients.FirstOrDefault(x => x.Id == Id);
            return client;
        }



        public void CreateClient(ClientEntity client)
        {
            var clients = GetAllClients();
            client.Id = Guid.NewGuid();
            clients.Add(client);
            PersistClient();
        }

        public void EditClient(ClientEntity client)
        {
            client = GetClient(client.Id);
            if (client == null)
                throw new InvalidOperationException("invalid client");

            client.ClientName = client.ClientName;
            client.Address = client.Address;
            PersistClient();

        }

        public void PersistClient()
        {
            var clients = GetAllClients();
            var clientsJson = SerializeObject(clients, Formatting.Indented);

            _readerWriterLock.EnterWriteLock();

            try
            {
                File.WriteAllText(File_Path, clientsJson);
            }
            finally
            {
                _readerWriterLock.ExitWriteLock();
            }
        }

    }
}
