namespace WiredBarinCoffee.StorageApp.Entities
{
    public class Manager : Employee
    {
        public override string ToString()
        {
            return base.ToString()+" (Manager) ";
        }
    }
}