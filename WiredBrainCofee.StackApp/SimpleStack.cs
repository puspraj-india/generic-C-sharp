
namespace WiredBrainCofee.StackApp
{
    public class SimpleStack<T>
    {
        private readonly T[] _items;
        private int _currentIndex=-1;

        
        //expression way to use function
        public SimpleStack() => _items= new T[10];

        public void Push(T item) => _items[++_currentIndex]=item;

        public int Count => _currentIndex+1;

        public T Pop() => _items[_currentIndex--];


    }
}