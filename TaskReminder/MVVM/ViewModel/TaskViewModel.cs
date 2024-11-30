using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TaskReminder.MVVM.Model;
using TaskReminder.MVVM.View;

namespace TaskReminder.ViewModel
{
    public partial class TaskViewModel : ObservableObject
    {
        [ObservableProperty]
        public Tasks? _task;

        public TaskViewModel()
        {
            _task = new Tasks();
        }

        public TaskViewModel(Tasks? task)
        {
            _task = task;
        }


        [RelayCommand]
        public /*async*/ void AddOrEditTask(ContentPage contentPage)
        {
            if (_task is not null && _task.Title is not null && _task.PriorityTitle is not null)
            {

                if (_task.Id is null || _task.Id.Length < 64)
                {
                    SHA512 sha512 = SHA512.Create();

                    _task.Id = BitConverter.ToString(sha512.ComputeHash(Encoding.UTF8.GetBytes($"{_task.Title}" +
                            $"{_task.CreatedDateTime.ToString()}"))).Replace("-", ""); ;

                    sha512.Dispose();
                }

                App.TaskRepository.Save(_task);

                if (App.TaskRepository.ErrorMessage != null)
                {
                    contentPage.DisplayAlert("Error", App.TaskRepository.ErrorMessage, "Ok");
                }
                else
                {
                    //await contentPage.DisplayAlert("1", contentPage.Parent.GetType().ToString(), "OK");
                    //await contentPage.DisplayAlert("2", contentPage.Parent.Parent.GetType().ToString(), "OK");
                    ((MainPage)contentPage.Parent.Parent).Refresh();
                    ((MainPage)contentPage.Parent.Parent).SendBackButtonPressed();
                }
            }
        }
    }
}
