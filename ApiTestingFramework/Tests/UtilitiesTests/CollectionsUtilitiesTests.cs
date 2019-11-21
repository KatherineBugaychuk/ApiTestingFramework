using ApiTestingFramework.Utilities;
using NUnit.Framework;
using System.Collections.Generic;

namespace ApiTestingFramework.Tests.UtilitiesTests
{
    [TestFixture]
    class CollectionsUtilitiesTests
    {
        [Test]
        public void TestAddRangeForDictionary()
        {
            Dictionary<string, string> dict1 = new Dictionary<string, string>()
            {
                { "1", "one" },
                { "2", "two" },
                { "3", "three" }
            };
            Dictionary<string, string> dict2 = new Dictionary<string, string>()
            {
                { "4", "four" },
                { "5", "five" }
            };
            Dictionary<string, string> expectedResultDict = new Dictionary<string, string>()
            {
                { "1", "one" },
                { "2", "two" },
                { "3", "three" },
                { "4", "four" },
                { "5", "five" }
            };
            dict1.AddRange(dict2);
            CollectionAssert.AreEquivalent(dict1, expectedResultDict);
        }
    }
}
