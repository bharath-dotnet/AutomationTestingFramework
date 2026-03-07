using NUnit.Framework;

namespace AutomationFramework
{
    [SetUpFixture]
    public class TestRunHook
    {
        [OneTimeSetUp]
        public void RunStart()
        {
            Utilities.SimpleReportManager.StartReport();
        }

        [OneTimeTearDown]
        public void RunEnd()
        {
            Utilities.SimpleReportManager.EndReport();
        }
    }
}