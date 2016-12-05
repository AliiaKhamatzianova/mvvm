using System.Collections.Generic;
using System.Windows;
using SampleMVVM.Models;
using SampleMVVM.ViewModels;
using SampleMVVM.Views;
using System.Linq;
using System.Data.Entity;

namespace SampleMVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {

            DataBaseContext ctx = new DataBaseContext();
            ctx.Tasks.Load();
            var data = (from Tasks in ctx.Tasks
                       //where Tasks.Status == Statuses.TODO
                       select Tasks).ToList();


            //select t;
            MainView view = new MainView(); // создали View
            MainViewModel viewModel = new MainViewModel(data, ctx);
            //MainViewModel viewModel = new MainViewModel(ctx.Tasks.ToList(), ctx); // Создали ViewModel

            view.DataContext = viewModel; // положили ViewModel во View в качестве DataContext
            view.Show();
        }
    }
}
