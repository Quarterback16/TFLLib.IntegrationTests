using Microsoft.VisualStudio.TestTools.UnitTesting;
using TFLLib.Helpers;

namespace TFLLib.IntegrationTests
{
    [TestClass]
    public class SeasonHelperTests
    {
        [TestMethod]
        public void SeasonHelperKnowsRegularSeasonGames()
        {
            Assert.IsTrue(
                SeasonHelper.RegularSeasonWeeks("2025") == 18);
        }


    }
}
