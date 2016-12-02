using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using SampleMVVM.Models;

namespace SampleMVVM.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public ObservableCollection<TaskViewModel> TasksList { get; set; } 

        #region Constructor

        public MainViewModel(IEnumerable<Task> tasks)
        {
            TasksList = new ObservableCollection<TaskViewModel>(tasks.Select(b => new TaskViewModel(b)));
        }

        #endregion
    }
}
