using System.Collections.ObjectModel;
using TaskReminder.MVVM.Model;

namespace TaskReminder.Repository
{
    public class TaskRepository<T> : BaseRepository<T> where T : Tasks, new()
    {

        public override T? GetItem(object id)
        {
            string? _id = id as string;
            if (_id != null)
            {
                try
                {
                    return connection.Table<T>().Where(i => i.Id == _id).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    OkMessage =
                         $"Error: {ex.Message}";
                }
            }
            return null;
        }

        public override List<T>? GetAll(DateTimeOffset? startDate)
        {
            long? start = startDate?.ToUnixTimeSeconds() ?? new DateTimeOffset().ToUnixTimeSeconds();

            try
            {
                return [.. connection.Table<T>().Where(s => s.CreatedDateTime == start || s.DeadlineDateTime == start)];
            }
            catch (Exception ex)
            {
                OkMessage =
                     $"Error: {ex.Message}";
            }
            return null;
        }

        public override ObservableCollection<T>? GetAllObservable(DateTimeOffset? startDate = null)
        {
            long? start = startDate?.ToUnixTimeSeconds() ?? new DateTimeOffset().ToUnixTimeSeconds();

            try
            {
                return [.. connection.Table<T>().Where(s => s.CreatedDateTime == start || s.DeadlineDateTime == start)];
            }
            catch (Exception ex)
            {
                OkMessage =
                     $"Error: {ex.Message}";
            }
            return null;
        }

        public override ObservableCollection<T>? GetAllUnixObservable(long? startDate = null)
        {
            
            try
            {
                return [.. connection.Table<T>().Where(s => s.CreatedDateTime == startDate || s.DeadlineDateTime == startDate)];
            }
            catch (Exception ex)
            {
                OkMessage =
                     $"Error: {ex.Message}";
            }
            return null;
        }
    }
}
