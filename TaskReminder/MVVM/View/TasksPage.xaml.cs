
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using TaskReminder.MVVM.Model;
using TaskReminder.MVVM.ViewModel;
using TaskReminder.ViewModel;

namespace TaskReminder.MVVM.View;
public partial class TasksPage : ContentPage
{
    private MonthViewModel _monthViewModel;
    private MainViewModel _mainViewModel;
    public TasksPage(MonthViewModel monthViewModel, MainViewModel mainViewModel /*ObservableCollection<Tasks>? tasks*/)
    {
        InitializeComponent();
        _monthViewModel = monthViewModel;
        _mainViewModel = mainViewModel;
        DataCollectionView.BindingContext = _mainViewModel;
        HeaderBorder.BindingContext = _monthViewModel;
        UpdateDate(MonthRangeDatePicker);
    }

    private void OnAddTaskButtonClicked(object sender, EventArgs e)
    {
        ((MainPage)Parent).AddTask();
    }

    private void ItemBorder_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        Border border = (Border)sender;

        var grid = border?.Content?.GetVisualTreeDescendants().Where(g => g.GetType() == typeof(Grid)).FirstOrDefault() as Grid;


        if (grid != null)
        {
            if (border?.BackgroundColor == Colors.WhiteSmoke)
            {
                foreach (var item in grid.Children)
                {
                    if (item.GetType() == typeof(Label))
                    {
                        ((Label)item).TextColor = Colors.Black;
                    }
                }
            }
            else
            {
                foreach (var item in grid.Children)
                {
                    if (item.GetType() == typeof(Label))
                    {
                        ((Label)item).TextColor = Colors.White;
                    }
                }
            }
        }
    }

    private void OnMonthRangeDatePickerDateSelected(object sender, DateChangedEventArgs e)
    {
        UpdateDate(sender as DatePicker);
    }

    private void UpdateDate(DatePicker? datePicker)
    {
        if (datePicker is not null)
        {
            int year = datePicker.Date.Year;
            int month = datePicker.Date.Month;
            int day = datePicker.Date.Day - 1;
            _monthViewModel.DaysList = new MonthViewModel(year, month, day).DaysList;
            MonthDaysCollectionView.SelectedItem = _monthViewModel.DaysList?[day];

            MonthDaysCollectionView.ScrollTo(MonthDaysCollectionView.SelectedItem);
        }
    }

    private void OnMonthDaysCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        Days? selectedDay = e.CurrentSelection[0] as Days;
        if (selectedDay is not null)
        {
            _mainViewModel._startDate = selectedDay.DateTimeOffset.ToUnixTimeSeconds();
            _mainViewModel.UpdateTasks(_mainViewModel._startDate);
        }
    }

    private void OnEditTaskButtonClicked(object sender, EventArgs e)
    {
        Tasks? task = ((Button)sender).BindingContext as Tasks;
        TaskViewModel? taskViewModel = new TaskViewModel(task);
        ((MainPage)Parent).UpdateTask(taskViewModel);
    }
}