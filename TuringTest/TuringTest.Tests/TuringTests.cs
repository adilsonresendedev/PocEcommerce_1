using NUnit.Framework;
using System.Collections.Generic;
using TuringBusiness;

namespace TuringTest.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Turing turingSubset = new Turing();
            IList<IList<int>> result = turingSubset.SubSet(new int[] { 0 });
            Assert.Pass();
        }
    }
}