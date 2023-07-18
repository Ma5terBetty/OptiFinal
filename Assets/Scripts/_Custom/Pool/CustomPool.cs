using System;
using System.Collections.Generic;

namespace _Custom.Pool
{
    public class CustomPool<T> where T : ICustomPoolable<T>, new()
    {
        private readonly List<T> _available;

        private readonly Func<T> _factoryMethod;
        private readonly bool _isDynamic;
        
        public CustomPool(Func<T> factoryMethod, bool isDynamic = true, int initialStock = 0)
        {
            _factoryMethod = factoryMethod;
            _isDynamic = isDynamic;

            _available = new List<T>();

            for (int i = 0; i < initialStock; i++)
            {
                var value = _factoryMethod();
                value.Recycle();
                _available.Add(value);
            }
        }

        public T GetObject()
        {
            var result = default(T);
            if (_available.Count > 0)
            {
                result = _available[0];
                _available.RemoveAt(0);
            }
            else if (_isDynamic)
            {
                result = _factoryMethod();
            }

            if (result != null)
            {
                result.OnRecycle += ReturnObject;
                result.Reset();
            }
            
            return result;
        }

        public void ReturnObject(T value)
        {
            value.OnRecycle -= ReturnObject;
            _available.Add(value);
        }

        public void Clear()
        {
            _available.Clear();
        }
    }
}