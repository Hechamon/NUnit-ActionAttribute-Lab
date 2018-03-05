using Repository;
using System.Linq;

namespace NUnitActionAttributeLab
{
    public class SomeService : ISomeService
    {
        private readonly ISpaceXDb spaceXDb;
        public SomeService(ISpaceXDb spaceXDb)
        {
            this.spaceXDb = spaceXDb;
        }

        public int GetMostAmountOfStages()
        {
            return spaceXDb.OrderByDescending(rocket => rocket.Stages).First().Stages;
        }
    }
}
