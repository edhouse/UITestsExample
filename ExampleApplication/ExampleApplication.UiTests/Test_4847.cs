using System.Linq;
using ExampleApplication.Model.Utils;
using Xunit;
using FluentAssertions;

namespace ExampleApplication.UiTests
{
    public class Test_4847 : BaseTest
    {
        [Fact]
        public void RemovePersonTest()
        {
            Step1_RunApplication();
            Step2_SavePeople();
            Step3_AddHuman();
            Step4_RemoveHuman();
            Step5_SavePeople2();
            Step6_CheckIfChanged();
            Step7_CloseApplication();
        }
        
        private string[] humans;
        private string[] newHumans;

        private void Step1_RunApplication()
        {
            Run();
        }

        private void Step2_SavePeople()
        {
            humans = Application.MainWindow.Menu.Items.GetChildMenus().Select(i => i.Name).ToArray();
            Application.MainWindow.Menu.Items.Click();
        }

        private void Step3_AddHuman()
        {
            Application.MainWindow.Add.Click();
        }

        private void Step4_RemoveHuman()
        {
            Application.MainWindow.Remove.Click();
        }

        private void Step5_SavePeople2()
        {
            newHumans = Application.MainWindow.Menu.Items.GetChildMenus().Select(i => i.Name).ToArray();
            Application.MainWindow.Menu.Items.Click();
        }

        private void Step6_CheckIfChanged()
        {
            newHumans.ShouldAllBeEquivalentTo(humans);
        }

        private void Step7_CloseApplication()
        {
            Close();
        }
    }
}
