using SQLite;
using TaskReminder.Abstract;
using SQLiteNetExtensions.Attributes;

namespace TaskReminder.MVVM.Model
{
    public class Tasks : DbBaseClassStringId //DbBaseClass
    {
        //SHA512 Id => title + datetime + category + username
        //[MaxLength(64)]
        //[Indexed(Name = "StringIdIDX")]
        //public string? StringId { get; set; }
        [MaxLength(24)]
        public string? Title { get; set; }

        [Indexed(Name = "CreatedDateTimeIDX")]
        public long CreatedDateTime { get; set; } = new DateTimeOffset(DateTime.Today).ToUnixTimeSeconds();

        [Indexed(Name = "DeadlineIDX")]
        public long DeadlineDateTime { get; set; } = new DateTimeOffset(DateTime.Today).ToUnixTimeSeconds();

        public Priority? PriorityTitle { get; set; }

        [Indexed(Name = "ProgressIDX")]
        public byte Progress { get; set; }

        public string? Description { get; set; }


    }
}
