using System.Collections.Generic;
using WiredBarinCoffee.StorageApp.Entities;

namespace WiredBarinCoffee.StorageApp.Repositories
{
    public class EmployeeRepository
    {
        private readonly List<Employee> _employees = new();
        public void Add(Employee employee)
        {
            _employees.Add(employee);
        }
        public void Save()
        {
            foreach(Employee employee in _employees)
            {
                System.Console.WriteLine(employee);
            }
        }
    }
}