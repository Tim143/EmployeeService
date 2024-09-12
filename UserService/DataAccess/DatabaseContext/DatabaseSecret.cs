using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DatabaseContext
{
    public interface IDatabaseSecret
    {
        string GetConnectionString();
    }

    public class DatabaseSecret : IDatabaseSecret
    {
        private string host = "";
        private string port = "";
        private string username = "";
        private string password = "";
        private string database = "";
        private string minPool = "";

        public string GetConnectionString()
        {
            return $"Host={host};Port={port};Username={username};Password={password};Database={database};MinPoolSize={minPool}";
        }
    }
}
