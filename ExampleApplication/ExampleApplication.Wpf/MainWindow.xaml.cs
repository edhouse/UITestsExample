using System.Windows;
using ExampleApplication.Logic;


namespace ExampleApplication.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            PersonsViewModel persons = new PersonsViewModel();
            DataContext = persons;

            InitializeComponent();
        }
    }
}
