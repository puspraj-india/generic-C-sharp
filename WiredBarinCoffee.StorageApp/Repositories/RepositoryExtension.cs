namespace WiredBarinCoffee.StorageApp.Repositories
{
    public static class RepositoryExtension
    {
        //Making this function public, as we want it to be accesible from other classes as well.
        public static void AddBatch<T>(this IWriteRepository<T> repository, T[] items)
        {
            foreach( T item in items)
            {
                repository.Add(item);
            }
            repository.Save();
        }
    }
}