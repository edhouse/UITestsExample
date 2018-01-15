using Xunit;

namespace ExampleApplication.UiTests
{
    public class Test_4842 : BaseTest
    {
        [Fact]
        public void RunWindowTest()
        {
            Step1_RunApplication();
            Step2_CloseApplication();
        }
        private void Step1_RunApplication()
        {
            Run();
        }
        private void Step2_CloseApplication()
        {
            Close();
        }
    }
}
