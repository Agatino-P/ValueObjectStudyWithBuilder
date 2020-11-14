using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExternalLib
{
    public class ProgramParamList : Dictionary<string, ProgramParam>
    {
        public void Add(string paramName, string paramDesc, double paramVal)
            => base.Add(paramName, new ProgramParam(paramName, paramDesc, paramVal));
    }
}
