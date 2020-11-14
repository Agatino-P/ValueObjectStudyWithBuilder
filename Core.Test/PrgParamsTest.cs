using ExternalLib;
using FluentAssertions;

using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Core.Test
{
    /// <summary>
    /// Summary description for ProgramParamVOTest
    /// </summary>
    [TestFixture]
    public class PrgParamsTest
    {

        [TestCase(1, "1", 1.11)]
        public void AddAndRetrieve(int number, string desc, double value)
        {
            //Arrange
            PrgParam addedPrgParam = new PrgParam.Builder().WithProperties(number, desc, value).Build();
            PrgParams prgParamDic = new PrgParams();

            //Act
            prgParamDic.Add(addedPrgParam);

            //Assert    

            PrgParam retrievedPrgParam = prgParamDic[addedPrgParam.Name];

            addedPrgParam.Should().Be(retrievedPrgParam); 
        }


        [Test]
        public void ToEnumerable()
        {
            //Arrange
            PrgParams prgParams = new PrgParams();
            List<PrgParam> paramsList = prgParams.Params.ToList();


            //Act
            const int NUMPARAMS = 79;
            List<PrgParam> prgParamList = new List<PrgParam>();
            for (int l=1; l<= NUMPARAMS; l++)
            {
                PrgParam newPrgParam = new PrgParam.Builder().WithProperties(l, $"Desc_{l}", l * 1.11).Build();
                prgParams.Add(newPrgParam);
                paramsList.Add(newPrgParam);
            }


            //Assert
            paramsList.Count.Should().Be(NUMPARAMS);
            paramsList.SequenceEqual(prgParams.Params).Should().BeTrue();
        }

    }
}
