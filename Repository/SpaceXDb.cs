using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Repository
{
    public class SpaceXDb : ISpaceXDb
    {
        private static readonly string[] RocketIds = { "falcon1", "falcon9", "falconheavy" };
        private RocketWebservice rocketWebservice;
        private bool isInitialized = false;

        public void Initialize()
        {
            Thread.Sleep(3000);
            rocketWebservice = new RocketWebservice(new Uri("https://api.spacexdata.com/v2/rockets/"));
            isInitialized = true;
        }

        public IEnumerator<Rocket> GetEnumerator()
        {
            if (!isInitialized) throw new Exception("Db not initialized.");
            foreach (var rocketId in RocketIds)
            {
                yield return rocketWebservice.GetRocket(rocketId);
                Thread.Sleep(500);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
