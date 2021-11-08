using System.Collections.Generic;
using System.Linq;
using WiredBarinCoffee.StorageApp.Entities;

namespace WiredBarinCoffee.StorageApp.Repositories
{
    public class ListRepository<T> : IRepository<T>
    where T : /*class,*/ IEntity//, new()
    {
        private readonly List<T> _items= new List<T>();

        // public T CreateItem()
        // {
        //     return new T();
        // }

        public void Add(T item)
        {
            item.Id=_items.Count+1;
            _items.Add(item);
        }
          public void remove(T item)
        {
            _items.Remove(item);
        }

        public T GetById(int id)
        {
            return _items.Single(item=>item.Id==id);
            //return null; // return default(T)
        }
        public void Save()
        {
            foreach(T item in _items)
            {
                System.Console.WriteLine(item);
            }
        }


    }

}