using System;

namespace ReversiKata.Tests
{
    class ReversiTestCaseGenerator
    {
        internal static ReversiGridCoordinate[] GetTenRandomGridCoordinates()
        {
            var random = new Random();
            var pairCount = 0;
            var generatedCoordinates = new ReversiGridCoordinate[10]; 
            while (pairCount < 10)
            {
                generatedCoordinates[pairCount] = new ReversiGridCoordinate(random.Next(5), random.Next(5));
                pairCount++;
            }
            return generatedCoordinates;
        }
    }
}
