using FluentAssertions;
using System.Linq;
using Xunit;

namespace ExampleApplication.UiTests
{
    public class Test_4846 : BaseTest
    {
        [Fact]
        public void EditPersonTest()
        {
            Step1_RunApplication();
            Step2_SelectFirst();
            Step3_LoadTextBoxes();
            Step4_AddsXSuffix();
            Step5_SelectNextAndBack();
            Step6_CheckSuffixes();
            Step7_ChecksMenu();
            Step8_CloseApplication();
        }

        private string firstName;
        private string lastName;
        private string description;

        private void Step1_RunApplication()
        {
            Run();
        }

        private void Step2_SelectFirst()
        {
            Application.MainWindow.PersonList.NothingSelected.Should().Be(true, "Nothing should be selected");
            Application.MainWindow.PersonList.Select(0);
        }

        private void Step3_LoadTextBoxes()
        {
            firstName = Application.MainWindow.FirstName.Text;
            lastName = Application.MainWindow.LastName.Text;
            description = Application.MainWindow.Description.Text;
        }
        private void Step4_AddsXSuffix()
        {
            Application.MainWindow.FirstName.Text = AddSuffix(Application.MainWindow.FirstName.Text, "x");
            Application.MainWindow.LastName.Text = AddSuffix(Application.MainWindow.LastName.Text, "x");
            Application.MainWindow.Description.Text = AddSuffix(Application.MainWindow.Description.Text, "x");
        }

        private void Step5_SelectNextAndBack()
        {
            Application.MainWindow.PersonList.Select(1);
            Application.MainWindow.PersonList.Select(0);
        }

        private void Step6_CheckSuffixes()
        {
            Application.MainWindow.FirstName.Text.Should().Be(AddSuffix(firstName, "x"), "x should be added at end of the first name");
            Application.MainWindow.LastName.Text.Should().Be(AddSuffix(lastName, "x"), "x should be added at end of the last name");
            Application.MainWindow.Description.Text.Should().Be(AddSuffix(description, "x"), "x should be added at end of the description");
        }

        private void Step7_ChecksMenu()
        {
            Application.MainWindow.Menu.Items.ChildMenus.ElementAt(0).Name.Should().Be(AddWholeNameWithX(firstName, lastName), "Person's name in menu Items should have suffixes x");
            Application.MainWindow.Menu.Items.Click();
            Application.MainWindow.PersonList.SelectedItemText.Should().Be(AddWholeNameWithX(firstName, lastName), "Person's name in ListBox should have suffixes x");
        }

        private void Step8_CloseApplication()
        {
            Close();
        }

        private string AddSuffix(string text, string suffix)
        {
            return text + suffix;
        }

        private string AddWholeNameWithX(string firstName, string lastName)
        {
            return firstName + "x " + lastName + "x";
        }
    }
}
