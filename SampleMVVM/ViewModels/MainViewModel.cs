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
            var todoData = (from Task in dbContext.Tasks
                           where Task.Status == Statuses.TODO
                           select Task).ToList();
            List<TaskViewModel> todoList = new List<TaskViewModel>();
            foreach (var t in todoData)
            {
                todoList.Add(new TaskViewModel(t,dbContext));
            }
            TasksList = new ObservableCollection<TaskViewModel>(todoList);

            var activeData = (from Task in dbContext.Tasks
                            where Task.Status == Statuses.Active
                            select Task).ToList();
            List<TaskViewModel> activeList = new List<TaskViewModel>();
            foreach (var t in activeData)
            {
                activeList.Add(new TaskViewModel(t, dbContext));
            }
            ActiveTasksList = new ObservableCollection<TaskViewModel>(activeList);

            var doneData = (from Task in dbContext.Tasks
                              where Task.Status == Statuses.Done
                              select Task).ToList();
            List<TaskViewModel> doneList = new List<TaskViewModel>();
            foreach (var t in doneData)
            {
                doneList.Add(new TaskViewModel(t, dbContext));
            }
            DoneTasksList = new ObservableCollection<TaskViewModel>(doneList);
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
