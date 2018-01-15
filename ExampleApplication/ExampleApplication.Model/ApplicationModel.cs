using System.Diagnostics;
using TestStack.White;
using ExampleApplication.Resources.AutomationIdentifiers;
using TestStack.White.UIItems.Finders;



namespace ExampleApplication.Model
{
    public class ApplicationModel
    {
        public ApplicationModel(Application application)
        {
            Application = application;
        }

        public Process Process => Application.Process;

        private Application Application { get; }

        private MainWindowModel mainWindow;

        public MainWindowModel MainWindow
        {
            get
            {
                if (mainWindow == null)
                {
                    var window = Application.GetWindow(SearchCriteria.ByAutomationId(MainWindowIds.MainWindow), TestStack.White.Factory.InitializeOption.NoCache);
                    mainWindow = new MainWindowModel(window);
                }
                return mainWindow;
            }
        }
    }
}
