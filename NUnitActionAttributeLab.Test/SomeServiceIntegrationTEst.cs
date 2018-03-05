using System.Linq;
using CommonTestTools;
using NUnit.Framework;

namespace NUnitActionAttributeLab.Test
{
    [SetupDbAction]
    public class SomeServiceIntegrationTestWithAttribute : IntegrationTestBase
    {

        [Test]
        [SetupDbAction]
        public void SomeTest()
        {
            Assert.NotNull(Db.First().Name);
        }

        [Test]
        public void SomeTestWithoutAttribute()
        {
            Assert.NotNull(Db.First().Name);
        }

    }

    public class SomeServiceIntegrationTest : IntegrationTestBase
    {

        [Test]
        [SetupDbAction]
        public void SomeTest()
        {
            Assert.NotNull(Db.First().Name);
        }

        [Test]
        public void SomeTestWithoutAttribute()
        {
            Assert.NotNull(Db.First().Name);
        }

    }

    public class SomeServiceIntegrationTestWithoutBase
    {
        [Test]
        [SetupDbAction]
        public void SomeTest()
        {
            Assert.IsTrue(true);
        }
    }
}