using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskReminder.Repository
{
    public static class DbSettings
    {
        private const string DBFILENAME = "TSKRM.db3";

        public const SQLiteOpenFlags FLAGS = SQLiteOpenFlags.Create
            | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache;

        public static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, DBFILENAME);
    }
}
