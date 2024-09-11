using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("31.597099,-84.176122,Taco Bell Albany..." , -84.176122)]
        [InlineData("32.465342,-84.919767,Taco Bell Columbus...", -84.919767)]
        [InlineData("30.22841,-85.649286,Taco Bell Lynn Have...", -85.649286 )]
        [InlineData("32.326279,-86.325015,Taco Bell Montgomery...",-86.325015)]
        
        
        //TODO // DONE/ Add additional inline data. Refer to your CSV file.
        public void ShouldParseLongitude(string line, double expected)
        {
            // TODO: Complete the test with Arrange, Act, Assert steps below.
            //       Note: "line" string represents input data we will Parse 
            //       to extract the Longitude.  
            //       Each "line" from your .csv file
            //       represents a TacoBell location

            //Arrange
            var tacoLongitude = new TacoParser();

            //Act
            var actual = tacoLongitude.Parse(line);

            //Assert
            Assert.Equal(expected, actual.Location.Longitude);
        }
        
        [Theory]
           [InlineData("34.073638, -84.677017, Taco Bell Acwort...",34.073638 )]
           [InlineData("31.597099,-84.176122,Taco Bell Albany...", 31.597099)]
           [InlineData("32.465342,-84.919767,Taco Bell Columbus..." , 32.465342)]
           [InlineData("30.22841,-85.649286,Taco Bell Lynn Have...",30.22841)]
           [InlineData("32.326279,-86.325015,Taco Bell Montgomery...", 32.326279)]

        //TODO: Create a test called ShouldParseLatitude
        public void ShouldParseLatitude(string line, double expected)
        {
            var tacoLatitude = new TacoParser();
            //Act
            var actual = tacoLatitude.Parse(line);
            
            //Assert
            Assert.Equal(expected, actual.Location.Latitude);

        }
    }
}
