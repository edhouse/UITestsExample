using System.Linq;
using Xunit;
using FluentAssertions;

namespace ExampleApplication.UiTests
{
    public class Test_4845 : BaseTest
    {
        [Fact]
        public void CopyingTest()
        {
            Step1_RunApplication();
            Step2_SelectFirst();
            Step3_AddPerson();
            Step4_CheckIfCopy();
            Step5_CloseApplication();
        }

        private string selectedName;
        private int itemsCount;

        private void Step1_RunApplication()
        {
            Run();
        }

        private void Step2_SelectFirst()
        {
            Application.MainWindow.PersonList.Select(0);
            selectedName = Application.MainWindow.PersonList.SelectedItemText;
        }

        private void Step3_AddPerson()
        {
            Application.MainWindow.Add.Click();
        }

        private void Step4_CheckIfCopy()
        {
            itemsCount = Application.MainWindow.PersonList.Items.Count();
            Application.MainWindow.PersonList.Select(itemsCount - 1);
            Application.MainWindow.PersonList.SelectedItemText.Should().Be(selectedName + " Copy", "Name should be old with the copy suffix");
        }

        private void Step5_CloseApplication()
        {
            Close();
        }
    }
}
