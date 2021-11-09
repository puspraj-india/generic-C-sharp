using System.Collections.Generic;
using WiredBarinCoffee.StorageApp.Entities;

namespace WiredBarinCoffee.StorageApp.Repositories
{

    //By default generic type is Invariant.
    public interface IRepository<T>: IReadRepository<T>, IWriteRepository<T>
    where T :/* class,*/ IEntity//, new()
    {
        
    } 


//  Making below class covariant
    public interface IReadRepository<out T>
    {
        IEnumerable<T> GetAll();
        //T CreateItem();
        T GetById(int id);
    }
    public interface IWriteRepository<in T>
    {
        void Add(T item);
        void remove(T item);
        void Save();
    }

}