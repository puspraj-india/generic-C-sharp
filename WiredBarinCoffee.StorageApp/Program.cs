using System;
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
            ListRepository<Organisation> repo2 = new();
            AddOrganisations(repo2);
            GetOrganisations(repo2);
        }

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
