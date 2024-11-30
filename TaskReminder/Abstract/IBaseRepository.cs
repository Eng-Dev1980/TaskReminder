using System.Collections.ObjectModel;

namespace TaskReminder.Abstract
{
    public interface IBaseRepository<T> : IDisposable where T : DbBaseClass, new()
    {
        public T? GetItem(object id);
        public List<T>? GetAll(DateTimeOffset? startDate = null);
        public ObservableCollection<T>? GetAllObservable(DateTimeOffset? startDate = null);

        /// <summary>
        /// Just implemented in Interface for future override use
        /// </summary>
        /// <param name="parameters"> Search Conditions must be pass ass parameters in implementation class</param>
        /// <returns></returns>
        public List<T>? GetAll(params object[]? parameters);
        public ObservableCollection<T>? GetAllObservable(params object[]? parameters);
        public void Save(T item);
        public void Delete(T item);

    }
}
