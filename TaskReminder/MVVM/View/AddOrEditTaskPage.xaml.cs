using TaskReminder.MVVM.Model;
using TaskReminder.ViewModel;

namespace TaskReminder.MVVM.View;

public partial class AddOrEditTaskPage : ContentPage
{
    private TaskViewModel? _taskViewModel;
    public AddOrEditTaskPage(TaskViewModel? taskViewModel)
    {
        InitializeComponent();
        _taskViewModel = taskViewModel;
        BindingContext = _taskViewModel;

    }

    public AddOrEditTaskPage()
    {
        InitializeComponent();
    }

    private void OnPriorityPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        switch (((Picker)sender).SelectedIndex)
        {
            case 0:
                _taskViewModel.Task.PriorityTitle = Priority.Low;
                break;
            case 1:
                _taskViewModel.Task.PriorityTitle = Priority.Medium;
                break;
            case 2:
                _taskViewModel.Task.PriorityTitle = Priority.High;
                break;
            case 3:
                _taskViewModel.Task.PriorityTitle = Priority.Critical;
                break;
        }
    }

}