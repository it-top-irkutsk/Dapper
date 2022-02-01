using System;
using Dapper.DB_Lib;
using Dapper.Model;

namespace Dapper.App
{
    class Program
    {
        static void Main()
        {
            var db = new UserDb();
            var users = db.GetAllUsers();

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Id}: {user.Name}");
            }

            var u = db.GetTable("table_persons");
            foreach (var o in u)
            {
                Console.WriteLine($"{o.id} - {o.name}");
            }
        }
    }
}