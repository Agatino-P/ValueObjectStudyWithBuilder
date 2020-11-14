using System;
using System.Collections.Generic;

namespace Shared
{
    public class KeyDict<T, K> : Dictionary<K, T>
    {
        private Func<T, K> _keyGetFunc;
        public KeyDict(Func<T, K> getKeyFunc)
        {
            _keyGetFunc = getKeyFunc;
        }

        public new T this[K k]
        {
            get => (k != null && base.ContainsKey(k)) ? base[k] : default(T);
            set => base[k] = value;
        }

        public void Add(T t)
        {
            if (_keyGetFunc != null)
            {
                base[_keyGetFunc(t)] = t;
            }
        }
    }
}
