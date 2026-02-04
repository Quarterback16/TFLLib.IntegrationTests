using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TFLLib.IntegrationTests
{
	[TestClass]
	public class DataLibrarianIntegrationTests : IntegrationTestsBase
	{
		[TestInitialize]
		public void Setup()
		{
			Initialise();
		}

		[TestMethod]
		public void DataLibrarian_ContructsOk()
		{
			Assert.IsNotNull(Sut);
			Assert.IsTrue(Sut.UseCache);
			Assert.IsTrue(Sut.IsCacheEnabled);
		}

		[TestMethod]
		public void DataLibrarian_GetPlayer_LeavesDataInCache()
		{
			var result1 = Sut.GetPlayer("MONTJO01");
			var result2 = Sut.GetPlayer("MONTJO01");
			Assert.IsTrue(Sut.HitCount > 0);
		}

		[TestMethod]
		public void DataLibrarian_GetAllGames_ReturnsGames()
		{
			var result = Sut.GetAllGames(season: 2000);
			Assert.IsTrue(result.Tables["SCHED"].Rows.Count > 0);
		}

		[TestMethod]
		public void DataLibrarian_GetWeekRecord_ReturnsSuperbowlWeek()
		{
			var result = Sut.GetWeekRecord(
				new System.DateTime(
					2026,
					2,
					1,
					0,
					0,
					0,
					System.DateTimeKind.Unspecified));
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void DataLibrarian_GetCurrentPlayers_ReturnsKicker()
		{
			var ds = Sut.GetCurrentPlayers(
				teamCode: "NE",
				strCat: "4",
				sPos: "PK",
				role: "S");
			Assert.IsNotNull(ds);
			Assert.IsTrue(ds.Tables["PLAYER"].Rows.Count > 0);
			Console.WriteLine(
				ds.Tables["PLAYER"].Rows[0][0].ToString());
		}
	}
}
