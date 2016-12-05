using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using SampleMVVM.Models;
using GongSolutions.Wpf.DragDrop;
using System.Windows;
using System;

namespace SampleMVVM.ViewModels
{
    class MainViewModel : ViewModelBase, IDropTarget
    {
        public ObservableCollection<TaskViewModel> TasksList { get; set; }
        public ObservableCollection<TaskViewModel> ActiveTasksList { get; set; }
        public ObservableCollection<TaskViewModel> DoneTasksList { get; set; }

        public MainViewModel()
        {


        }
        #region Constructor

        public MainViewModel(IEnumerable<Task> tasks, DataBaseContext dbContext)
        {
            var enumarable = tasks as IList<Task> ?? tasks.ToList();

            var todoData = enumarable.Where(t => t.Status == Statuses.TODO);
            TasksList = new ObservableCollection<TaskViewModel>(todoData.Select(x=>new TaskViewModel(x, dbContext)));

            var activeData = enumarable.Where(t => t.Status == Statuses.Active);
            ActiveTasksList = new ObservableCollection<TaskViewModel>(activeData.Select(x => new TaskViewModel(x, dbContext)));

            var doneData = enumarable.Where(t => t.Status == Statuses.Done);
            DoneTasksList = new ObservableCollection<TaskViewModel>(doneData.Select(x => new TaskViewModel(x, dbContext)));

            //TasksList = new ObservableCollection<TaskViewModel>(tasks.Select(b => new TaskViewModel(b, dbContext));
            //ActiveTasksList = new ObservableCollection<TaskViewModel>(tasks.Select(b => new TaskViewModel(b, dbContext)));

        }


        #endregion

        void IDropTarget.DragOver(DropInfo dropInfo)
        {
            if (dropInfo.Data is TaskViewModel )//&& dropInfo.TargetItem is TaskViewModel)
            {
                dropInfo.DropTargetAdorner = DropTargetAdorners.Highlight;
                dropInfo.Effects = DragDropEffects.Move;
            }
        }

        void IDropTarget.Drop(DropInfo dropInfo)
        {
            TaskViewModel task = (TaskViewModel)dropInfo.Data;
            if (task.Status == Statuses.TODO)
            {
                task.Status = Statuses.Active;
                task.StartDate = DateTime.Now;
                ActiveTasksList.Add(task);
                ((IList<TaskViewModel>)dropInfo.DragInfo.SourceCollection).Remove(task);
            }
            else
                if (task.Status == Statuses.Active)
                {
                    task.Status = Statuses.Done;
                    task.EndDate = DateTime.Now;
                    DoneTasksList.Add(task);
                    ((IList<TaskViewModel>)dropInfo.DragInfo.SourceCollection).Remove(task);
                }
        }

    }
}
