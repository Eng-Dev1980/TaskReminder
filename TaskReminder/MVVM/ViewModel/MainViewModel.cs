using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using TaskReminder.MVVM.Model;
using TaskReminder.MVVM.View;
using TaskReminder.ViewModel;

namespace TaskReminder.MVVM.ViewModel
{
    public partial class MainViewModel : ObservableObject
    {
        public const long _24HRS = 86399;// from 00:00:00 to 23:59:59 as Seconds

        [ObservableProperty]
        public long? _startDate;

        [ObservableProperty]
        public ObservableCollection<Tasks>? _tasks;


        [ObservableProperty]
        public MonthViewModel? _monthViewModel;


        public MainViewModel(MonthViewModel? monthViewModel, long? startDate = null)
        {
            _startDate = startDate ?? new DateTimeOffset(DateTime.Today).ToUnixTimeSeconds();
            _monthViewModel = monthViewModel;
            UpdateTasks();

        }


        public ObservableCollection<Tasks>? GetTasks(long? startDate = null)
        {
            long? _startDate = startDate ?? new DateTimeOffset(DateTime.Today).ToUnixTimeSeconds();

            return App.TaskRepository.GetAllUnixObservable(_startDate);
        }

        public void UpdateTasks(long? startDate = null)
        {
            ObservableCollection<Tasks>? tasks = GetTasks(startDate);

            if (tasks is not null)
            {
                if (_tasks is not null)
                {
                    _tasks.Clear();

                    foreach (Tasks task in tasks)
                    {
                        _tasks.Add(task);
                    }
                }
                else
                {
                    _tasks = tasks;
                }
            }
        }

        [RelayCommand]

        public void DeleteTask(Tasks tasks)
        {
            App.TaskRepository.Delete(tasks);

            UpdateTasks(_startDate);
        }

        //[RelayCommand()]

        //public void UpdateTask(Tasks tasks)
        //{
        //    App.TaskRepository.Delete(tasks);

        //    UpdateTasks(_startDate);
        //}
    }
}
