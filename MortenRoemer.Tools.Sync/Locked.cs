namespace MortenRoemer.Tools.Sync;

public class Locked<T>
{
    public Locked(Func<T> initializer, int timeout = -1)
    {
        Inner = new Lazy<T>(initializer, LazyThreadSafetyMode.None);
        TimeOut = timeout;
    }

    private Lazy<T> Inner { get; }

    private Mutex Lock { get; } = new();
    
    private int TimeOut { get; }

    public Handle Open()
    {
        Lock.WaitOne(TimeOut);
        return new Handle(Inner.Value, this);
    }

    public class Handle : IDisposable
    {
        internal Handle(T inner, Locked<T> parent)
        {
            Inner = inner;
            Parent = parent;
        }
        
        public T Inner { get; }
        
        private Locked<T> Parent { get; }
        
        public void Dispose()
        {
            Parent.Lock.ReleaseMutex();
        }
    }
}