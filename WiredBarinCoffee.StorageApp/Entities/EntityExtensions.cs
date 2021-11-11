using System.Text.Json;

namespace WiredBarinCoffee.StorageApp.Entities
{
    public static class EntitiyExtensions
    {
        public static T? Copy<T>(this T itemToCopy) where T: IEntity
        {
            var json=JsonSerializer.Serialize(itemToCopy);
            // now we want to deserialize the serialized object to T.
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}