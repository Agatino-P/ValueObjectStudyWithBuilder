using ExternalLib;
using System;

namespace Core
{
    public partial class PrgParam
    {
        public class Builder
        {
            private PrgParam _prgParam = new PrgParam();

            public Builder WithNumber(int number)
            {
                _prgParam.Number= number;
                return this;
            }

            public Builder WithName(string name)
            {
                if (!String.IsNullOrWhiteSpace(name) &&name.Length > 1 &&
                    Int32.TryParse(name.Substring(1), out int number)
                    )
                {
                    _prgParam.Number = number;
                }
                return this;
            }

            public Builder WithDesc(string desc)
            {
                _prgParam.Desc = desc;
                return this;
            }
            public Builder WithVal(double val)
            {
                _prgParam.Val = val;
                return this;
            }

            public Builder WithProperties(int number, string desc, double val) =>
                WithNumber(number).WithDesc(desc).WithVal(val);

            public Builder WithProgramParam(ProgramParam programParam) =>
                WithName(programParam.ParamName).WithDesc(programParam.ParamDesc).WithVal(programParam.ParamVal);

            public Builder WithPrgParam(PrgParam prgParam) =>
                WithNumber(prgParam.Number).WithDesc(prgParam.Desc).WithVal(prgParam.Val);

            public PrgParam Build()
            {
                return new PrgParam.Validator().Validate(_prgParam).IsValid ?
                    _prgParam :
                    null;
            }
        }
    }
}
