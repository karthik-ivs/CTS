using System;
using MySql.Data.MySqlClient;

class Program
{
    static string connectionString =
    "Server=localhost;" +
    "Database=CompanyDB;" +
    "Uid=root;" +
    "Pwd=K@rthik_ivs;";

    static void InsertEmployee(string name, decimal salary)
    {
        using MySqlConnection conn =
            new MySqlConnection(connectionString);

        string query =
            "INSERT INTO Employees(Name,Salary) VALUES(@Name,@Salary)";

        MySqlCommand cmd = new MySqlCommand(query, conn);

        cmd.Parameters.AddWithValue("@Name", name);
        cmd.Parameters.AddWithValue("@Salary", salary);

        conn.Open();

        cmd.ExecuteNonQuery();

        Console.WriteLine("Employee Inserted");
    }

    static void ReadEmployees()
    {
        using MySqlConnection conn =
            new MySqlConnection(connectionString);

        string query = "SELECT * FROM Employees";

        MySqlCommand cmd =
            new MySqlCommand(query, conn);

        conn.Open();

        MySqlDataReader reader =
            cmd.ExecuteReader();

        Console.WriteLine("\nEmployees:");

        while (reader.Read())
        {
            Console.WriteLine(
                $"{reader["Id"]} " +
                $"{reader["Name"]} " +
                $"{reader["Salary"]}");
        }
    }

    static void UpdateEmployee(int id, decimal salary)
    {
        using MySqlConnection conn =
            new MySqlConnection(connectionString);

        string query =
            "UPDATE Employees SET Salary=@Salary WHERE Id=@Id";

        MySqlCommand cmd =
            new MySqlCommand(query, conn);

        cmd.Parameters.AddWithValue("@Salary", salary);
        cmd.Parameters.AddWithValue("@Id", id);

        conn.Open();

        cmd.ExecuteNonQuery();

        Console.WriteLine("Employee Updated");
    }

    static void DeleteEmployee(int id)
    {
        using MySqlConnection conn =
            new MySqlConnection(connectionString);

        string query =
            "DELETE FROM Employees WHERE Id=@Id";

        MySqlCommand cmd =
            new MySqlCommand(query, conn);

        cmd.Parameters.AddWithValue("@Id", id);

        conn.Open();

        cmd.ExecuteNonQuery();

        Console.WriteLine("Employee Deleted");
    }

    static void Main()
    {
        try
        {
            InsertEmployee("Karthik", 50000);

            ReadEmployees();

            UpdateEmployee(1, 60000);

            ReadEmployees();

            DeleteEmployee(1);

            ReadEmployees();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}