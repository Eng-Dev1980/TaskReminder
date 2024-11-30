using SQLite;
using System.Collections.ObjectModel;
using TaskReminder.Abstract;

namespace TaskReminder.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : DbBaseClass, new()
    {

        protected SQLiteConnection connection;

        public string? OkMessage { get; set; }
        public string? ErrorMessage { get; set; }

        public BaseRepository()
        {
            if (connection is not null)
            {
                connection.CreateTable<T>();
                return;
            }

            connection = new SQLiteConnection(DbSettings.DatabasePath, DbSettings.FLAGS);
            connection.CreateTable<T>();
        }

        public void Delete(T item)
        {
            ErrorMessage = null;
            try
            {
                connection.Delete(item);
            }
            catch (Exception ex)
            {
                ErrorMessage =
                     $"Error: {ex.Message}";
            }
        }

        public void Dispose()
        {
            connection.Close();
        }

        public virtual List<T>? GetAll(DateTimeOffset? startDate = null)
        {
            ErrorMessage = null; try
            {
                return [.. connection.Table<T>()];
            }
            catch (Exception ex)
            {
                ErrorMessage =
                     $"Error: {ex.Message}";
            }
            return null;
        }

        public virtual List<T>? GetAll(params object[]? parameters)
        {
            // Just implemented for future override use
            return GetAll();
        }

        public virtual ObservableCollection<T>? GetAllObservable(DateTimeOffset? startDate = null)
        {
            ErrorMessage = null; try
            {
                return [.. connection.Table<T>()];
            }
            catch (Exception ex)
            {
                ErrorMessage =
                     $"Error: {ex.Message}";
            }
            return null; ;
        }

        public virtual ObservableCollection<T>? GetAllUnixObservable(long? startDate = null)
        {
            return GetAllObservable();
        }

        public virtual ObservableCollection<T>? GetAllObservable(params object[]? parameters)
        {
            return GetAllObservable();
        }

        public virtual T? GetItem(object id)
        {
            ErrorMessage = null;
            int? _id = (int)id;
            if (_id.HasValue)
            {
                try
                {
                    return
                          connection.Table<T>()
                         .FirstOrDefault(x => x.Id == _id.Value);
                }
                catch (Exception ex)
                {
                    ErrorMessage =
                         $"Error: {ex.Message}";
                }
            }
            return null;
        }

        public void Save(T item)
        {
            ErrorMessage = null;
            int result = 0;
            try
            {
                result = connection.InsertOrReplace(item);
                OkMessage = $"{result} row(s) Added/Updated";
                connection.Commit();
            }
            catch (Exception ex)
            {
                ErrorMessage =
                     $"Error: {ex.Message}";
            }
        }


    }
}


//if (item.Id is not null)
//{
//    result =
//    connection.Update(item);
//    OkMessage =
//         $"{result} row(s) updated";
//}
//else
//{
//    result = connection.Insert(item);
//    OkMessage =
//         $"{result} row(s) added";
//}