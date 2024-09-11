using System;
using System.Linq;
using System.IO;
using System.Runtime.ExceptionServices;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // Objective: Find the two Taco Bells that are the farthest apart from one another.
            // Some of the TODO's are done for you to get you started. 

            logger.LogInfo("Log initialized");

            // Use File.ReadAllLines(path) to grab all the lines from your csv file. 
            // Optional: Log an error if you get 0 lines and a warning if you get 1 line
            var lines = File.ReadAllLines(csvPath);
            if (lines.Length == 0)
            {

            }

            // This will display the first item in your lines array
            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Use the Select LINQ method to parse every line in lines collection
            var locations = lines.Select(parser.Parse).ToArray();


            // Complete the Parse method in TacoParser class first and then START BELOW ----------

            // TODO: Create two `ITrackable` variables with initial values of `null`. 
            // These will be used to store your two Taco Bells that are the farthest from each other.

            ITrackable tacoBellOne = null;
            ITrackable tacoBellTwo = null;

            // TODO: Create a `double` variable to store the distance
            double distance = 0;


            // TODO// DONE: Add the Geolocation library to enable location comparisons: using GeoCoordinatePortable;
            // Look up what methods you have access to within this library.


            // NESTED LOOPS SECTION----------------------------

            // FIRST FOR LOOP -
            // TODO: Create a loop to go through each item in your collection of locations.
            // This loop will let you select one location at a time to act as the "starting point" or "origin" location.
            // Naming suggestion for variable: `locA`

            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var corA = new GeoCoordinate(locA.Location.Latitude, locA.Location.Longitude);
                //
                // var corA = new Point()
                // {
                //   
                // };
                for (int i2 = 0; i2 < locations.Length; i2++)
                {
                    var locB = locations[i2];
                    var corB = new GeoCoordinate(locB.Location.Latitude, locB.Location.Longitude);



                    if (corA.GetDistanceTo(corB) > distance)
                    {
                        distance = corA.GetDistanceTo(corB);
                        tacoBellOne = locA;
                        tacoBellTwo = locB;
                       
                    }
                    
                    


                }


            }

            var kilos = distance / 1000;
            Console.WriteLine($"These are the two furthest Taco Bells: {tacoBellOne.Name} and {tacoBellTwo.Name} are {kilos} kilometers away from one another.");

        }
    }
}
