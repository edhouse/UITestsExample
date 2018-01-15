using Xunit;

namespace ExampleApplication.UiTests
{
    public class Test_4848 : BaseTest
    {
        [Fact]
        public void LotOfPeopleTest()
        {
            Step1_RunApplication();
            Step2_RemovePeople();
            Step3_AddPeople();
            Step4_DeleteLast();
            Step5_CloseApplication();
        }

        private const int NumberOfPeople = 30;
        private const int StartingPeople = 2;

        private void Step1_RunApplication()
        {
            Run();
        }

        private void Step2_RemovePeople()
        {
            for (int i = 0; i < StartingPeople; i++)
            {
                Application.MainWindow.PersonList.Select(0);
                Application.MainWindow.Remove.Click();
            }
        }

        private void Step3_AddPeople()
        {
            for (int i = 1; i < NumberOfPeople + 1; i++)
            {
                Application.MainWindow.Add.Click();
                Application.MainWindow.LastName.Text = "Person" + i;
            }
        }

        private void Step4_DeleteLast()
        {
            Application.MainWindow.PersonList.ScrollLargeDown();
            Application.MainWindow.PersonList.Select(NumberOfPeople - 1);
            Application.MainWindow.Remove.Click();
        }

        private void Step5_CloseApplication()
        {
            Close();
        }
    }
}
