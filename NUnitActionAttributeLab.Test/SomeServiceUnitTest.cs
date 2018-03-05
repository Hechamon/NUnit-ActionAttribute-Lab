using NUnit.Framework;
using Repository;
using System.Collections;
using System.Collections.Generic;

namespace NUnitActionAttributeLab.Test
{
    public class SomeServiceUnitTest
    {
        private static object[] Rockets =
        {
            new object[] {1, new[] {new Rocket("", "", 1)}},
            new object[] {3, new[] { new Rocket("", "", 1), new Rocket("", "", 3)}},
            new object[] {2, new[] {new Rocket("", "", 2), new Rocket("", "", 1)} }
        };

        [Test]
        [TestCaseSource(nameof(Rockets))]
        public void SomeService_GetMostAmountOfStages_Unittest(int expected, Rocket[] rockets)
        {

            //Arrange
            ISomeService service = new SomeService(new SpaceXDbMock(rockets));
            //Act && Assert
            Assert.That(service.GetMostAmountOfStages(), Is.EqualTo(expected));
        }

        private class SpaceXDbMock : ISpaceXDb
        {
            private readonly Rocket[] rockets;

            public SpaceXDbMock(Rocket[] rockets)
            {
                this.rockets = rockets;
            }

            public IEnumerator<Rocket> GetEnumerator()
            {
                foreach (var rocket in rockets)
                {
                    yield return rocket;
                }
            }

            public void Initialize()
            {
                // Do nothing
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
