
using TaskReminder.MVVM.Model;
using TaskReminder.MVVM.View;
using TaskReminder.MVVM.ViewModel;
using TaskReminder.Resources.Templates;
using TaskReminder.ViewModel;

namespace TaskReminder.MVVM.View
{
    public partial class MainPage : FlyoutPage
    {
        private MainViewModel? _mainViewModel { get; set; }

        private TasksPage? tasksPage;

        public MainPage()
        {
            InitializeComponent();
            _mainViewModel = new MainViewModel(new MonthViewModel());

            tasksPage = new TasksPage(_mainViewModel.MonthViewModel, _mainViewModel);

            Detail = tasksPage;

        }


        //private void OnAddOrEditTaskButtonClicked(object sender, EventArgs e)
        //{
        //    Detail = new NavigationPage(new AddOrEditTaskPage(new TaskViewModel()));
        //    if (!((IFlyoutPageController)this).ShouldShowSplitMode)
        //        IsPresented = false;
        //}


        protected override bool OnBackButtonPressed()
        {
            if (Detail != tasksPage)
            {
                Detail = tasksPage;
                return true;
            }
            else
            {
                return false;
            }
        }


        public void AddTask()
        {
            Detail = new NavigationPage(new AddOrEditTaskPage(new TaskViewModel()));
            if (!((IFlyoutPageController)this).ShouldShowSplitMode)
                IsPresented = false;
        }

        public void UpdateTask(TaskViewModel? taskViewModel)
        {
            Detail = new NavigationPage(new AddOrEditTaskPage(taskViewModel));
            if (!((IFlyoutPageController)this).ShouldShowSplitMode)
                IsPresented = false;
        }

        public void Refresh()
        {
            _mainViewModel.UpdateTasks();
        }

    }

}
