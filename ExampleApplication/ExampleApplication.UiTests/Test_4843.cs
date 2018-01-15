using System.Linq;
using Xunit;
using ExampleApplication.Resources;
using FluentAssertions;

namespace ExampleApplication.UiTests
{
    public class Test_4843 : BaseTest
    {
        [Fact]
        public void AddPersonTest()
        {
            Step1_RunApplication();
            Step2_NothingSelected();
            Step3_CountPeople();
            Step4_AddPerson();
            Step5_CheckHumanIncreasing();
            Step6_CheckIfListDefault();
            Step7_CheckIfMenuDefault();
            Step8_CloseApplication();
        }

        private int numberOfPeople;

        private void Step1_RunApplication()
        {
            Run();
        }

        private void Step2_NothingSelected()
        {
            Application.MainWindow.PersonList.NothingSelected.Should().Be(true, "Nothing should be selected");
        }

        private void Step3_CountPeople()
        {
            numberOfPeople = Application.MainWindow.PersonList.Items.Count;
        }

        private void Step4_AddPerson()
        {
            Application.MainWindow.Add.Click();
            numberOfPeople++;
        }

        private void Step5_CheckHumanIncreasing()
        {
            Application.MainWindow.PersonList.Items.Count.Should().Be(numberOfPeople, "Number of people in list should increase by 1");
            Application.MainWindow.Menu.Items.ChildMenus.Count.Should().Be(numberOfPeople, "Number of people in menu items should increase by 1");
        }

        private void Step6_CheckIfListDefault()
        {
            string wholeName = Resource.NewPerson_FirstName + " " + Resource.NewPerson_LastName;

            Application.MainWindow.PersonList.SelectedItemText.Should().Be(wholeName, "Selected name in the list should be default");
            var menuHuman = Application.MainWindow.Menu.Items.ChildMenus.ElementAt(numberOfPeople - 1);
            menuHuman.Name.Should().Be(wholeName, "Name of last human in items menu should be default");
            Application.MainWindow.Menu.Items.Click();
        }

        private void Step7_CheckIfMenuDefault()
        {
            Application.MainWindow.FirstName.Text.Should().Be(Resource.NewPerson_FirstName, "FirstName in textbox should be default");
            Application.MainWindow.LastName.Text.Should().Be(Resource.NewPerson_LastName, "LastName in textbox should be default");
            Application.MainWindow.Description.Text.Should().Be(Resource.NewPerson_Description, "Description in textbox should be default");
        }

        private void Step8_CloseApplication()
        {
            Close();
        }
    }
}
