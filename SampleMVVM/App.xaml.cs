using System.Collections.Generic;
using System.Windows;
using SampleMVVM.Models;
using SampleMVVM.ViewModels;
using SampleMVVM.Views;

namespace SampleMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {

            List<Task> books = new List<Task>()
            {
                new Task("Cделай это", null, 3),
                new Task("Сделай то", "Какое-то описание", 2),
                new Task("И про это не забудь", "Еще какое-то описание", 1)
            };

            MainView view = new MainView(); // создали View
            MainViewModel viewModel = new MainViewModel(books); // Создали ViewModel

            view.DataContext = viewModel; // положили ViewModel во View в качестве DataContext
            view.Show();
        }
    }
}
