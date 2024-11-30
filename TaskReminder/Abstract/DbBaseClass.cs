using SQLite;

namespace TaskReminder.Abstract
{
    public class DbBaseClass
    {
        [PrimaryKey]
        [AutoIncrement]
        public int? Id { get; set; }
    }


    public class DbBaseClassStringId : DbBaseClass
    {
        [PrimaryKey]
        [MaxLength(64)]
        public new string? Id { get; set; }
    }

}
