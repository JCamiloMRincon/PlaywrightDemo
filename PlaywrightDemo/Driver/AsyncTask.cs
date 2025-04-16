using System.Runtime.CompilerServices;

namespace PlaywrightDemo.Driver
{
    // Implement the factory design pattern.
    public class AsyncTask<T> : Lazy<Task<T>>
    {
        // Advanced use of delegates for creating the constructor.
        public AsyncTask(Func<Task<T>> taskFactory) :
            base(() => Task.Factory.StartNew(taskFactory).Unwrap())
        { 
        }

        public TaskAwaiter<T> GetAwaiter() 
        {
            return Value.GetAwaiter();
        }
    }
}
