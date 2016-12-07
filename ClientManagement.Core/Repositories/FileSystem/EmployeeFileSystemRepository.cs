using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;
using System.IO;
using Newtonsoft.Json;
using static Newtonsoft.Json.JsonConvert;
using ClientManagement.Core.Models;

namespace ClientManagement.Core.Repositories
{

    public class EmployeeFileSystemRepository : IEmployeeRepository
    {
        private readonly string File_Path = ConfigurationManager.AppSettings["EmployeeFilePath"];
        private static ReaderWriterLockSlim _readerWriterLock = new ReaderWriterLockSlim();
        private List<Employee> _employees;

        public List<Employee> GetAllEmployees()
        {
            if (_employees!=null)
               return _employees;

            _readerWriterLock.EnterReadLock();
            var employeejson = default(string);

            try
            {
                employeejson = File.ReadAllText(File_Path);
            }
            finally
            {
                _readerWriterLock.ExitReadLock();
            }

            _employees = DeserializeObject<List<Employee>>(employeejson)
                ?? new List<Employee>();

            return _employees;

        }

        public Employee GetEmployee(Guid Id)
        {
            var employees = GetAllEmployees();
            var employee = employees.FirstOrDefault(x => x.Id == Id);
            return employee;
        }

        public void Create(Employee employeeEntity)
        {
            var employees = GetAllEmployees();
            employeeEntity.Id = Guid.NewGuid();
            employees.Add(employeeEntity);
            PersistEmployees();
        }

        public void Update(Employee employeeEntity)
        {
            var employee = GetEmployee(employeeEntity.Id);
            if (employee == null)
            {
                throw new InvalidOperationException("IvalidEmployee");
            }

            employee.Firstname = employeeEntity.Firstname;
            employee.Lastname = employeeEntity.Lastname;
            employee.Gender = employeeEntity.Gender;
            PersistEmployees();
        }

       

        public void PersistEmployees()
        {
            var employees = GetAllEmployees();
            var employeesJson = SerializeObject(employees, Formatting.Indented);

            _readerWriterLock.EnterWriteLock();

            try
            {
                File.WriteAllText(File_Path, employeesJson);
            }
            finally
            {
                _readerWriterLock.ExitWriteLock();
            }

        }
        
    }
}
