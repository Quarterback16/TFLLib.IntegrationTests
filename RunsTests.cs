using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TFLLib.IntegrationTests
{
	[TestClass]
	public class RunsTests : IntegrationTestsBase
	{
		[TestInitialize]
		public void Setup()
		{
			Initialise();
		}

		[TestMethod]
		public void CanInsertAnErrorMessage()
		{
			try
			{
				var badText = "Job failed to complete: Could not load file or assembly 'System.Configuration.ConfigurationManager, Version=10.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51' or one of its dependencies. The system cannot find the file specified.";
				var fixedText = badText.Replace("'", "-");
				Sut.InsertRun(
					stepName: "Player Remover",
					result: fixedText,
					ts: new TimeSpan(2000),
					category: "Job");
			}
			catch (Exception ex)
			{
				Assert.Fail($"Expected no exception, but got: {ex.Message}");
			}
		}
	}
}
