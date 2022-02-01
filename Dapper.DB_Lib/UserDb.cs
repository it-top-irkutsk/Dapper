using System.Collections.Generic;
using System.IO;
using System.Linq;
using Dapper.Model;
using MySql.Data.MySqlClient;

namespace Dapper.DB_Lib
{
    public class UserDb
    {
        private readonly string _str;
        public UserDb()
        {
            _str = GetConnectionString("connection_to_db.txt");
        }

        public List<User> GetAllUsers()
        {
            using var db = new MySqlConnection(_str);
            var sql = "SELECT * FROM table_persons";
            var users = db.Query<User>(sql);
            return users.ToList();
        }

        public List<dynamic> GetTable(string table)
        {
            using var db = new MySqlConnection(_str);
            var sql = $"SELECT * FROM {table};";
            var users = db.Query(sql);
            return users.ToList();
        }

        private static string GetConnectionString(string path)
        {
            return File.ReadAllText(path);
        }
    }
}