using System.Collections.Generic;
using WiredBarinCoffee.StorageApp.Entities;

namespace WiredBarinCoffee.StorageApp.Repositories
{
    public interface IRepository<T>: IReadRepository<T> where T :/* class,*/ IEntity//, new()
    {
        void Add(T item);
        void remove(T item);
        void Save();
    } 

    public interface IReadRepository<out T>
    {
        IEnumerable<T> GetAll();
        //T CreateItem();
        T GetById(int id);
    }

}