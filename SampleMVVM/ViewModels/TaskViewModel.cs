using SampleMVVM.Models;
using SampleMVVM.Commands;
using System.Windows.Input;

namespace SampleMVVM.ViewModels
{
    class TaskViewModel : ViewModelBase
    {
        public Task Task;

        public TaskViewModel(Task task)
        {
            Task = task;
        }

        public string Name
        {
            get { return Task.Name; }
            set 
            {
                Task.Name = value;
                OnPropertyChanged("Name");
            }
        }

        public string Description
        {
            get { return Task.Description; }
            set
            {
                Task.Description = value;
                OnPropertyChanged("Description");
            }
        }

        public int Priority
        {
            get { return Task.Priority; }
            set
            {
                Task.Priority = value;
                OnPropertyChanged("Priority");
            }
        }

        #region Commands

        #region Забрать

        private DelegateCommand _increasePriorityCommand;

        public ICommand IncreasePriorityCommand => _increasePriorityCommand ?? (_increasePriorityCommand = new DelegateCommand(GetItem));

        private void GetItem()
        {
            Priority++;
        }

        #endregion

        #region Выдать

        private DelegateCommand _decreasePriorityCommand;

        public ICommand DecreasePriorityCommand => _decreasePriorityCommand ?? (_decreasePriorityCommand = new DelegateCommand(GiveItem, CanGiveItem));

        private void GiveItem()
        {
            Priority--;
        }

        private bool CanGiveItem()
        {
            return Priority > 0;
        }

        #endregion

        #endregion
    }
}
