
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Shared.Test
{
    [TestFixture]
    public class KeyDictTest
    {
        private class KeyDictItem : ValueObject
        {
            public string Key { get; set; }
            public string Val { get; set; }

            protected override IEnumerable<object> GetEqualityComponents()
            {
                yield return Key;
                yield return Val;
            }
        }
        private Func<KeyDictItem, string> _getKeyFunc = (kdi => kdi.Key);

        [Test]
        public void AddRetrieveIndexer()
        {
            KeyDict<KeyDictItem, string> keyDict = new KeyDict<KeyDictItem, string>(_getKeyFunc);
            KeyDictItem kdiAdded = new KeyDictItem() { Key = "uno", Val = "UNO" };
            keyDict["uno"] = kdiAdded;
            KeyDictItem kdiRetrieved = keyDict["uno"];

            kdiRetrieved.Should().Be(kdiAdded);

        }
        [Test]
        public void AddFuctionRetrieveIndexer()
        {
            KeyDict<KeyDictItem, string> keyDict = new KeyDict<KeyDictItem, string>(_getKeyFunc);
            KeyDictItem kdiAdded = new KeyDictItem() { Key = "uno", Val = "UNO" };
            keyDict.Add(kdiAdded);

            KeyDictItem kdiRetrieved = keyDict["uno"];

            kdiRetrieved.Should().Be(kdiAdded);

        }

    }
}
