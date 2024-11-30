using CommunityToolkit.Mvvm.ComponentModel;

namespace TaskReminder.View
{
    public partial class PriorityViewModel : ObservableObject
    {
        [ObservableProperty]
        public required string _priorityTitle;
    }
}
