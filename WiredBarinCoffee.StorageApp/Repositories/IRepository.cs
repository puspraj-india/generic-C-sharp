using System.Collections.Generic;
using WiredBarinCoffee.StorageApp.Entities;

namespace WiredBarinCoffee.StorageApp.Repositories
{
    public interface IRepository<T> where T :/* class,*/ IEntity//, new()
    {
        IEnumerable<T> GetAll();
        //T CreateItem();
        T GetById(int id);
        void Add(T item);
        void remove(T item);
        void Save();
    } 

}