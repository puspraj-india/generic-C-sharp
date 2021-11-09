namespace WiredBarinCoffee.StorageApp.Entities
{
    public class Employee : EntityBase
    {
        public string? FirstName { get; set; }

        public override string ToString()=> $"Id: {Id}, FirstName: {FirstName}";

        // public Employee()
        // {
        //     System.Console.WriteLine("Employee cons");
        // }
    }
}