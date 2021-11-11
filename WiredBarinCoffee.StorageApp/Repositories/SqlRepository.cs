using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WiredBarinCoffee.StorageApp.Entities;

namespace WiredBarinCoffee.StorageApp.Repositories
{

    public delegate void ItemAdded(object item);
    public class SqlRepository<T> : IRepository<T> where T : class, IEntity//, new()
    {
        private readonly ItemAdded _itemAddedCallback;
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        // we do not need below list anymore as we are using in-memory SQL database to store data.
        //private readonly List<T> _items= new List<T>();

        public SqlRepository(DbContext dbContext, ItemAdded? itemAddedCallback=null)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
            _itemAddedCallback=itemAddedCallback;

        }
        // public T CreateItem()
        // {
        //     return new T();
        // }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.OrderBy(item=>item.Id).ToList<T>();
        }

        
        public T GetById(int id)
        {
            //return _items.Single(item=>item.Id==id);
            //return null; // return default(T)
            return _dbSet.Find(id);
        }
        public void Add(T item)
        {
            // item.Id=_items.Count+1;
            // _items.Add(item);
            _dbSet.Add(item);
            _itemAddedCallback?.Invoke(item);
            
        }

        public void remove(T item)
        {
            // _items.Remove(item);
            _dbSet.Remove(item);
        }

        public void Save()
        {
            // foreach(T item in _items)
            // {
            //     System.Console.WriteLine(item);
            // }
            _dbContext.SaveChanges();
        }


    }

}