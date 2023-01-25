using NUnit.Framework;
using System.Collections.Generic;
using Business;


namespace Tests
{
    public class BairesTests
    {
        private Baires baires = new Baires();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            bool result = baires.solution("");
            Assert.That(result == false);
        }
    }
}
