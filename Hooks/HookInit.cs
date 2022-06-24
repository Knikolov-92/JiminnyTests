using Jiminny.UITests.TestInrastructure.Drivers;
using TechTalk.SpecFlow;

namespace Jiminny.UITests.Hooks
{
    [Binding]
    public sealed class HookInit
    {
        [BeforeScenario]
        public static void BeforeScenario()
        {
            Browser.Instance.OpenBrowser();
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            Browser.Instance.CloseBrowser();
        }
    }
}
