using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Configuration;
using TFLLib.Helpers;

namespace TFLLib.IntegrationTests
{
    [TestClass]
    public class SeasonTests
    {
        public static DataLibrarian Sut { get; private set; }

        [TestInitialize]
        public void Setup()
        {
            var drive = DriveHelper.DriveLetter();
            Sut = new DataLibrarian(drive);
        }

        [TestMethod]
        public void TestSeasonStartDate()
        {
            var result = Sut.GetSeasonStartDate("2025");
            Assert.AreEqual(
                new DateTime(2025, 9, 4, 0, 0, 0, DateTimeKind.Unspecified), 
                result);  
        }

        [TestMethod]
        public void UnitRatingsReturnsRatingForStartOfYear()
        {
            var ds = Sut.GetUnitRatings(
                new DateTime(2025, 9, 4, 0, 0, 0, DateTimeKind.Unspecified));
            Assert.IsTrue(ds.Tables[0].Rows.Count > 0);
        }

    }
}
