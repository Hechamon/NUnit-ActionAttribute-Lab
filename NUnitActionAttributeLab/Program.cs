using System;
using Repository;

namespace NUnitActionAttributeLab
{
    class Program
    {
        static void Main(string[] args)
        {
            var webService = new SpaceXDb();
            webService.Initialize();
            var someService = new SomeService(webService);
            Console.WriteLine($"Most amount of stages: {someService.GetMostAmountOfStages()}");
            Console.ReadKey();
        }
    }
}
