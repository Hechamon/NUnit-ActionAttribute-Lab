using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Repository;

namespace CommonTestTools
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class SetupDbActionAttribute : Attribute, ITestAction
    {
        private bool dbhasToBeCleanedUp;

        public void BeforeTest(ITest test)
        {
            if (test.Fixture is IntegrationTestBase testClass)
            {
                //Db may have been initialized in class level useDb Attribute
                if (!testClass.DbHasBeenInitialzed)
                {
                    testClass.Db = new SpaceXDb();
                    testClass.Db.Initialize();
                    dbhasToBeCleanedUp = true;
                }
            }
            else
            {
                throw new Exception($"To use this attribute please implement {nameof(IntegrationTestBase)}");
            }
        }

        public void AfterTest(ITest test)
        {
            if (test.Fixture is IntegrationTestBase testClass)
            {
                if (dbhasToBeCleanedUp)
                {
                    testClass.Db = null;
                    dbhasToBeCleanedUp = false;
                }
            }
        }

        public ActionTargets Targets => ActionTargets.Default;
    }
}
