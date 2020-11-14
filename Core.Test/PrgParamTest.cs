using ExternalLib;
using FluentAssertions;

using NUnit.Framework;

namespace Core.Test
{
    /// <summary>
    /// Summary description for ProgramParamVOTest
    /// </summary>
    [TestFixture]
    public class PrgParamTest
    {
        [TestCase(1, "D", 1.2,"L1")]
        public void BuildWithProperties(int number, string desc, double val, string name)
        {
            //Arrange

            //Act
            PrgParam pp   = new PrgParam.Builder().WithProperties(number,desc,val).Build();

            pp.Number.Should().Be(number);
            pp.Desc.Should().Be(desc);
            pp.Val.Should().Be(val);
            pp.Name.Should().Be(name);
        }

        [TestCase("L1",1)]
        public void BuildWithName(string name, int number)
        {
            PrgParam pp = new PrgParam.Builder().WithName(name).Build();
            pp.Number.Should().Be(number);
        }

        [TestCase(0, "D", 1.2)]
        [TestCase(80, "D", 1.2)]
        [TestCase(0, null, 1.2)]
        public void BuildWithInvalidProperties(int number, string desc, double val)
        {
            //Arrange

            //Act
            PrgParam pp = new PrgParam.Builder().WithProperties(number, desc, val).Build();

            //Assert
            pp.Should().BeNull();
        }
        
        [TestCase("L0")]
        [TestCase("L80")]
        public void BuildWithInvalidName(string name)
        {
            //Arrange

            //Act
            PrgParam pp = new PrgParam.Builder().WithName(name).Build();

            //Assert
            pp.Should().BeNull();
        }

        [TestCase("1","D",1.2)]
        public void BuildWithPrgParam(int number, string desc, double val)
        {
            //Arrange
            PrgParam prgParam = new PrgParam.Builder().WithProperties(number, desc, val).Build();

            //Act
            PrgParam newPrgParam = new PrgParam.Builder().WithPrgParam(prgParam).Build();
            
            newPrgParam.Name.Should().Be(prgParam.Name);
            newPrgParam.Desc.Should().Be(prgParam.Desc);
            newPrgParam.Val.Should().Be(prgParam.Val);
        }

        [TestCase("L1", "D", 1.2)]
        public void ImplicitFromProgramParam(string paramName, string paramDesc, double paramVal)
        {

            ProgramParam programParam = new ProgramParam(paramName, paramDesc, paramVal);
            PrgParam prgParam = programParam;

            ProgramParamAndPrgParamMatch(programParam, prgParam);
        }

        [TestCase("L0", "D", 1.2)]
        [TestCase("L80", "D", 1.2)]
        public void ImplicitFromInvalidProgramParam(string paramName, string paramDesc, double paramVal)
        {
            //Arrange
            ProgramParam programParam = new ProgramParam(paramName, paramDesc, paramVal);
            
            //Act
            PrgParam prgParam = programParam;

            //Assert
            prgParam.Should().BeNull();
        }

        [TestCase(1, "D", 1.2)]
        public void ImplicitToProgramParam(int number, string desc, double val)
        {
            PrgParam prgParam = new PrgParam.Builder().WithProperties(number, desc, val).Build();
            ProgramParam programParam = prgParam;

            ProgramParamAndPrgParamMatch(programParam, prgParam);
        }
        
        public void ProgramParamAndPrgParamMatch(ProgramParam programParam, PrgParam prgParam )
        {
            prgParam.Name.Should().Be(programParam.ParamName);
            prgParam.Desc.Should().Be(programParam.ParamDesc);
            prgParam.Val.Should().Be(programParam.ParamVal);
        }
        
        [TestCase(1,"Uno",1.11)]
        [TestCase(2, "Due", 2.2)]
        public void StructuralEquality(int number, string desc, double val)
        {
            PrgParam prgParamA = new PrgParam.Builder().WithProperties(number, desc, val).Build();
            PrgParam prgParamB = new PrgParam.Builder().WithProperties(number, desc, val).Build();

            prgParamA.Should().Be(prgParamB);

        }

    }
}
