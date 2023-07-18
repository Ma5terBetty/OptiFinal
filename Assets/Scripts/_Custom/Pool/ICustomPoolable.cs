using System;

namespace _Custom.Pool
{
    public interface ICustomPoolable<T>
    {
        public event Action<T> OnRecycle;
        public void Reset();
        public void Recycle();
    }
}