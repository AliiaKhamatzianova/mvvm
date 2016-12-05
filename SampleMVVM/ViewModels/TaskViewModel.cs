using SampleMVVM.Models;
using SampleMVVM.Commands;
using System.Windows.Input;
using System;
using GongSolutions.Wpf.DragDrop;
using System.Windows;
using System.Collections.Generic;

namespace SampleMVVM.ViewModels
{
    class TaskViewModel : ViewModelBase
    {
        public Task Task;

        protected DataBaseContext DBContext;

        public TaskViewModel()
        {

        }

        public TaskViewModel(Task task, DataBaseContext dbContext)
        {
            Task = task;
            DBContext = dbContext;
        }

        public string Name
        {
            get { return Task.Name; }
            set 
            {
                Task.Name = value;
                OnPropertyChanged("Name");
                DBContext.SaveChanges();
            }
        }

        public string Description
        {
            get { return Task.Description; }
            set
            {
                Task.Description = value;
                OnPropertyChanged("Description");
                DBContext.SaveChanges();
            }
        }

        public Priorities Priority
        {
            get { return Task.Priority; }
            set
            {
                Task.Priority = value;

                if (value >= Priorities.Low && value <= Priorities.High)
                {
                    OnPropertyChanged("Priority");
                    DBContext.SaveChanges();
                }
            }
        }

        public Statuses Status
        {
            get { return Task.Status; }
            set
            {
                Task.Status = value;
                OnPropertyChanged("Status");
                DBContext.SaveChanges();
            }
        }

        public DateTime StartDate
        {
            get { return Task.StartDate; }
            set
            {
                Task.StartDate = value;
                OnPropertyChanged("StartDate");
                DBContext.SaveChanges();
            }
        }

        public DateTime? EndDate
        {
            get { return Task.EndDate; }
            set
            {
                Task.EndDate = value;
                OnPropertyChanged("EndDate");
                DBContext.SaveChanges();
            }
        }

        #region Commands

        #region Увеличить

        private DelegateCommand _increasePriorityCommand;

        public ICommand IncreasePriorityCommand => _increasePriorityCommand ?? (_increasePriorityCommand = new DelegateCommand(GetItem));

        private void GetItem()
        {
            Priority++;
        }

        #endregion

        #region Уменьшить

        private DelegateCommand _decreasePriorityCommand;

        public ICommand DecreasePriorityCommand => _decreasePriorityCommand ?? (_decreasePriorityCommand = new DelegateCommand(GiveItem, CanGiveItem));
      //  public ICommand DecreasePriorityCommand = new DelegateCommand(GiveItem, CanGiveItem);

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
