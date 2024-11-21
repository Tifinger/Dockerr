using Npgsql;

Console.WriteLine("Hello, megkvirizzuk az adatbazist.");


// PostgreSQL adatbázis kapcsolati string
var connString = "Host=db;Database=persondb;Username=myuser;Password=asdf";
//var connString = "Host=localhost;Database=persondb;Username=myuser;Password=asdf";

// Kapcsolat létrehozása és megnyitása
using (var conn = new NpgsqlConnection(connString))
{
    Console.WriteLine("Megprobalok connectiont nyitni:" + connString);
    conn.Open();
    Console.WriteLine("connection megnyitva :)");

    // SQL lekérdezés futtatása a Person tábla adatainak lekérésére
    using (var cmd = new NpgsqlCommand("SELECT id, name, dob, comment FROM Person", conn))
    {
        using (var reader = cmd.ExecuteReader())
        {
            Console.WriteLine("kiirom a Person tabla tarttalmat:");

            // Adatok kiírása a konzolra
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader.GetInt32(0)}, Name: {reader.GetString(1)}, DoB: {reader.GetDateTime(2)}, Comment: {reader.GetString(3)}");
            }
        }
    }
}