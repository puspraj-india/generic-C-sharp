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

            ItemAdded<Employee> item = new ItemAdded<Employee>(EmployeeMethod);
            SqlRepository<Employee> repo1 = new(new StorageAppDbContext(), item);
            AddEmployees(repo1);
            AddManagers(repo1);

            IWriteRepository<Manager> repo = new SqlRepository<Employee>(new StorageAppDbContext());

            GetEmployeeId(repo1);

            WriteToConsole(repo1);
            ListRepository<Organisation> repo2 = new();
            AddOrganisations(repo2);
            GetOrganisations(repo2);
            WriteToConsole(repo2);
        }

        private static void EmployeeMethod(Employee employee)
        {

            Console.WriteLine(employee.FirstName);
        }

        private static void AddManagers(IWriteRepository<Manager> managerRepository)
        {
            Manager item = new Manager() { FirstName = "Sara" };
            var itemCopy=item.Copy();
            managerRepository.Add(item);
            if(itemCopy is not null)
            {
                itemCopy.FirstName+="_Copy";
                managerRepository.Add(itemCopy);
            }
            managerRepository.Add(new Manager(){FirstName="Henry"});
            managerRepository.Save();
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
            //repo2.Add(new Organisation() { Name = "Pankaj" });
            Organisation[] organisations= new Organisation[]
            {new Organisation{Name="Microsoft"},
            new Organisation{Name="Google"}};
            repo2.AddBatch(organisations);
            
        }

        

        private static void AddEmployees(IRepository<Employee> repo1)
        {
            // repo1.Add(new Employee() { FirstName = "Puspraj" });
            // var obj = new Employee() { FirstName = "Neeraj" };
            // repo1.Add(obj);
            var employees = new[]
            {
                new Employee(){FirstName="Puspraj"},
                new Employee(){FirstName="Neeraj"}
            };
            repo1.AddBatch(employees);
            //repo1.remove(obj);
            // repo1.Save();
        }
    }
}
