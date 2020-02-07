using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Datalust.Piggy.Update;
using Npgsql;

namespace ManyMans
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // docker run --name postgres -p 5432:5432 -e POSTGRES_PASSWORD=mysecretpassword -d postgres
            var connString = "Host=localhost;Username=postgres;Password=mysecretpassword;Database=postgres";

            await using var conn = new NpgsqlConnection(connString);
            await conn.OpenAsync();

            UpdateSession.ApplyChangeScripts(conn, "./db", new Dictionary<string, string>());
            
            // using (var dbConnection = conn)
            // {
            //     var team = new Team {
            //         Name = "Butt face"
            //     };
            //     dbConnection.Execute("INSERT INTO team (name) VALUES(@Name)", team);
            // }
            
            using (var dbConnection = conn)
            {
                var query = dbConnection.Query<Team>("SELECT * FROM Team");
                
                foreach (var item in query.AsList()) {
                    Console.WriteLine($"Team Name: {item.Name}");
                }
                // dbConnection.Execute("INSERT INTO team (name) VALUES(@Name)", team);
            }
        }
    }
}
