using System;
using Xunit;
using Tfl.Coding.Challenge;

namespace Tfl.Coding.Challenge.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            TflModel model = new TflModel { Id = "A6", RoadStstus = "", RoadStatusDescription = "" };

            Assert.Equals(model.RoadStatus, "Road Status is good");

        }
    }
}
