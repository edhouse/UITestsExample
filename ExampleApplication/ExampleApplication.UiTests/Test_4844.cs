using System.Linq;
using Xunit;
using FluentAssertions;

namespace ExampleApplication.UiTests
{
    public class Test_4844 : BaseTest
    {
        [Fact]
        public void SelectedPersonTest()
        {
            Step1_RunApplication();
            Step2_SelectFirst();
            Step3_CheckListAndTextBoxes();
            Step4_CheckIfChecked();
            Step5_CloseApplication();
        }

        private void Step1_RunApplication()
        {
            Run();
        }

        private void Step2_SelectFirst()
        {
            Application.MainWindow.PersonList.Select(0);
        }

        private void Step3_CheckListAndTextBoxes()
        {
            Application.MainWindow.PersonList.SelectedItemText.Should().Be(Application.MainWindow.FirstName.Text + " " + Application.MainWindow.LastName.Text, "Name in list and in textboxes should be the same");
        }
        private void Step4_CheckIfChecked()
        {
            Application.MainWindow.Menu.Items.ChildMenus.ElementAt(0).HelpText.Should().Be(true.ToString(), "Item in menu should be checked");
            Application.MainWindow.Menu.Items.Click();
        }

        private void Step5_CloseApplication()
        {
            Close();
        }
    }
}
