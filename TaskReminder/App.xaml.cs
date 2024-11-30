using TaskReminder.MVVM.Model;
using TaskReminder.MVVM.View;
using TaskReminder.Repository;

namespace TaskReminder
{
    public partial class App : Application
    {
        public static TaskRepository<Tasks>? TaskRepository { get; private set; }
        public App(TaskRepository<Tasks> taskRepository)
        {
            InitializeComponent();

            TaskRepository = taskRepository;
            MainPage = new NavigationPage(new MainPage());
        }
    }
}
