using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core
{
    public class PrgParams
    {
        private Dictionary<string, PrgParam> _prgParams = new Dictionary<string , PrgParam>();

        public IEnumerable<PrgParam> Params => _prgParams.Values;

        public PrgParam this[string key]
        {
            get
            {
                return (_prgParams.ContainsKey(key)) ?
                    _prgParams[key] :
                    null;
            }
            set
            {
                _prgParams[key] = value;
            }
        }

        public void Add(PrgParam prgParam)
        {
            _prgParams[prgParam.Name] = prgParam;
        }

        public void Clear()
        {
            _prgParams.Clear();
        }

    }
}
