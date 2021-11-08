using WiredBarinCoffee.StorageApp.Entities;

namespace WiredBarinCoffee.StorageApp.Repositories
{
    public interface IRepository<T> where T :/* class,*/ IEntity//, new()
    {
        void Add(T item);
        //T CreateItem();
        T GetById(int id);
        void remove(T item);
        void Save();
    } 

}