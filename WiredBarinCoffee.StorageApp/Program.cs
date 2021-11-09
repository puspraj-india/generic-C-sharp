using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WiredBarinCoffee.StorageApp.Data;
using WiredBarinCoffee.StorageApp.Entities;
using WiredBarinCoffee.StorageApp.Repositories;

namespace WiredBarinCoffee.StorageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlRepository<Employee> repo1 = new(new StorageAppDbContext());
            AddEmployees(repo1);
            GetEmployeeId(repo1);
            WriteToConsole(repo1);
            ListRepository<Organisation> repo2 = new();
            AddOrganisations(repo2);
            GetOrganisations(repo2);
            WriteToConsole(repo2);
        }

        private static void WriteToConsole(IReadRepository<IEntity> repo)
        {
            var items=repo.GetAll();
            foreach(var item in items)
            {
                Console.WriteLine(item);
            }
        }

        // private static void GetAllEmployees(SqlRepository<Employee> repo1)
        // {
        //     IEnumerable<Employee> employeees= repo1.GetAll();
        //     foreach(Employee employee in employeees)
        //     {
        //         Console.WriteLine(employee);
        //     }
        // }

        private static void GetOrganisations(IRepository<Organisation> repo2)
        {
            System.Console.WriteLine(repo2.GetById(1));
        }

        private static void GetEmployeeId(IRepository<Employee> repo1)
        {
           System.Console.WriteLine(repo1.GetById(1));
        }

        private static void AddOrganisations(IRepository<Organisation> repo2)
        {
            repo2.Add(new Organisation() { Name = "Pankaj" });
            repo2.Save();
        }

        private static void AddEmployees(IRepository<Employee> repo1)
        {
            repo1.Add(new Employee() { FirstName = "Puspraj" });
            var obj = new Employee() { FirstName = "Neeraj" };
            repo1.Add(obj);
            //repo1.remove(obj);
            repo1.Save();
        }
    }
}
