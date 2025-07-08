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
        public void TestNextSunday()
        {
            var result = Sut.GetSeasonStartDate("2025");
            Assert.AreEqual(
                new DateTime(2025, 9, 4, 0, 0, 0, DateTimeKind.Unspecified), 
                result);  
        }

        public static string NflConnectionString()
        {
            var connections = ConfigurationManager.ConnectionStrings;
            var connStr = connections["NflConnectionString"].ConnectionString;
            return connStr;
        }

        public static string TflConnectionString()
        {
            var connections = ConfigurationManager.ConnectionStrings;
            return connections["TflConnectionString"].ConnectionString;
        }

        public static string CtlConnectionString()
        {
            var connections = ConfigurationManager.ConnectionStrings;
            return connections["CtlConnectionString"].ConnectionString;
        }
    }
}
