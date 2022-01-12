namespace MortenRoemer.Tools.Sync;

public class RwLocked<T> : IDisposable
{
    public RwLocked(Func<T> initializer)
    {
        Inner = new Lazy<T>(initializer);
    }

    private Lazy<T> Inner { get; }

    private ReaderWriterLockSlim Lock { get; } = new(LockRecursionPolicy.NoRecursion);

    public ReadHandle Read()
    {
        Lock.EnterReadLock();
        return new ReadHandle(Inner.Value, this);
    }

    public WriteHandle Write()
    {
        Lock.EnterWriteLock();
        return new WriteHandle(Inner.Value, this);
    }

    public class ReadHandle : IDisposable
    {
        internal ReadHandle(T inner, RwLocked<T> parent)
        {
            Inner = inner;
            Parent = parent;
        }
        
        public T Inner { get; }
        
        private RwLocked<T> Parent { get; }
        
        public void Dispose()
        {
            Parent.Lock.ExitReadLock();
        }
    }
    
    public class WriteHandle : IDisposable
    {
        internal WriteHandle(T inner, RwLocked<T> parent)
        {
            Inner = inner;
            Parent = parent;
        }
        
        public T Inner { get; }
        
        private RwLocked<T> Parent { get; }
        
        public void Dispose()
        {
            Parent.Lock.ExitWriteLock();
        }
    }

    private void Dispose(bool disposing)
    {
        if (disposing)
        {
            Lock.Dispose();
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    
    ~RwLocked()
    {
        Dispose(false);
    }
}