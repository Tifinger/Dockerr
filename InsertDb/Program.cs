

using Npgsql;
using System;

var connString = "Host=db;Database=persondb;Username=myuser;Password=asdf";

using (var conn = new NpgsqlConnection(connString))
{
    Console.WriteLine("Hello, betoltunk az adatbazisba nehany rekordot!");

    conn.Open();

    Console.WriteLine("Connection opened successfully");

    var random = new Random();
    string[] firstNames = { "John", "Jane", "Alex", "Emily", "Mike" };
    string[] comments = { "Great person", "Very helpful", "Friendly", "Professional", "Energetic" };

    string name = firstNames[random.Next(firstNames.Length)];
    string comment = comments[random.Next(comments.Length)];
    DateTime dob = DateTime.Now.AddYears(-random.Next(18, 50));

    string sql = "INSERT INTO person (name, comment, dob) VALUES (@name, @comment, @dob)";
    using (var cmd = new NpgsqlCommand(sql, conn))
    {
        cmd.Parameters.AddWithValue("name", name);
        cmd.Parameters.AddWithValue("comment", comment);
        cmd.Parameters.AddWithValue("dob", dob);

        cmd.ExecuteNonQuery();
    }

    Console.WriteLine("Random person inserted successfully: {0}", name);
}
