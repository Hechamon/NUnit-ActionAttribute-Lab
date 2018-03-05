using System;
using Repository;

namespace CommonTestTools
{
    /// <summary>
    /// Abstract class which holds db reference. To set up the db, use the SetupDbActionAttribute.
    /// </summary>
    public abstract class IntegrationTestBase
    {
        private ISpaceXDb db;

        /// <summary>
        /// Get an instance of the <see cref="ISpaceXDb"/>.
        /// Throws <see cref="InvalidOperationException"/> if Db has not been initialized. To Initialize the database, add the <see cref="SetupDbActionAttribute"/> to the testMethod where the db is accessed, or the testClass if it is used in more than one test.
        /// </summary>
        /// <exception cref="InvalidOperationException">Throws InvalidOperationException if db has not been initialized.</exception>
        public ISpaceXDb Db
        {
            get
            {
                if (DbHasBeenInitialzed) return db;
                throw new InvalidOperationException($"{nameof(Db)} has not been initialized. Use the {nameof(SetupDbActionAttribute)} on your Testmethod and/or class to initialize the Database");
            }
            internal set => db = value;
        }

        internal bool DbHasBeenInitialzed => db != null;
    }
}
