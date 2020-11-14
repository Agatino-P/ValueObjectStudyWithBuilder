using System;
using System.Collections.Generic;

namespace Shared
{
    public class KeyDict<T, K>
    {
        private Func<T, K> _keyGetFunc;
        private Dictionary<K, T> _tdic = new Dictionary<K, T>();
        public KeyDict(Func<T, K> getKeyFunc)
        {
            _keyGetFunc = getKeyFunc;
        }

        public T this[K k]
        {
            get => (k != null && _tdic.ContainsKey(k)) ? _tdic[k] : default(T);
            set => _tdic[k] = value;
        }

        public void Add(T t)
        {
            if (_keyGetFunc != null)
            {
                _tdic[_keyGetFunc(t)] = t;
            }
        }

        public Dictionary<K, T>.KeyCollection Keys => _tdic.Keys;
        public Dictionary<K, T>.ValueCollection Values => _tdic.Values;

    }
}
