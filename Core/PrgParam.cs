using ExternalLib;
using Shared;
using System.Collections.Generic;

namespace Core
{
    public partial class PrgParam : ValueObject
    {
        public int Number { get; private set; }
        public string Name => $"L{Number}";
        public string Desc { get; private set; } = string.Empty;
        public double Val { get; private set; }

        public static implicit operator ProgramParam(PrgParam vo) 
            =>new ProgramParam(vo.Name, vo.Desc, vo.Val);

        public static implicit operator PrgParam (ProgramParam pp)
            => new PrgParam.Builder().WithProgramParam(pp).Build();
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Number;
            yield return Desc;
            yield return Val;
        }
    }
}
