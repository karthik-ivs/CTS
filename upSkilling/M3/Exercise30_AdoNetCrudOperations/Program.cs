// Exercise30 - ADO.NET CRUD
// Configure connectionString for your SQL Server before calling the CRUD methods.
// Required table:
// CREATE TABLE Employees (Id INT PRIMARY KEY, Name NVARCHAR(100), Department NVARCHAR(100));

using System.Data;
using System.Data.SqlClient;

string connectionString = "Server=localhost;Database=TrainingDb;Trusted_Connection=True;TrustServerCertificate=True;";
AdoNetEmployeeRepository repository = new(connectionString);

Console.WriteLine("ADO.NET CRUD methods are ready.");
Console.WriteLine("Database operations are not executed automatically, so this sample is safe when SQL Server is unavailable.");
Console.WriteLine("Uncomment the calls in Program.cs after creating the database and Employees table.");

try
{
    // repository.InsertEmployee(new Employee(1, "Ravi", "Engineering"));
    // repository.GetEmployees();
    // repository.UpdateEmployee(new Employee(1, "Ravi Kumar", "Product"));
    // repository.DeleteEmployee(1);
}
catch (Exception ex)
{
    Console.WriteLine($"Database operation failed: {ex.Message}");
}

internal sealed record Employee(int Id, string Name, string Department);

internal sealed class AdoNetEmployeeRepository(string connectionString)
{
    public void InsertEmployee(Employee employee)
    {
        try
        {
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(
                "INSERT INTO Employees (Id, Name, Department) VALUES (@Id, @Name, @Department)",
                connection);

            command.Parameters.AddWithValue("@Id", employee.Id);
            command.Parameters.AddWithValue("@Name", employee.Name);
            command.Parameters.AddWithValue("@Department", employee.Department);

            connection.Open();
            int rows = command.ExecuteNonQuery();
            Console.WriteLine($"Inserted rows: {rows}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Insert failed: {ex.Message}");
        }
    }

    public List<Employee> GetEmployees()
    {
        List<Employee> employees = [];

        try
        {
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new("SELECT Id, Name, Department FROM Employees", connection);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                employees.Add(new Employee(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2)));
            }

            using SqlDataAdapter adapter = new("SELECT Id, Name, Department FROM Employees", connection);
            DataTable table = new();
            adapter.Fill(table);
            Console.WriteLine($"Rows loaded by SqlDataAdapter: {table.Rows.Count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Read failed: {ex.Message}");
        }

        foreach (Employee employee in employees)
        {
            Console.WriteLine($"{employee.Id}: {employee.Name} - {employee.Department}");
        }

        return employees;
    }

    public void UpdateEmployee(Employee employee)
    {
        try
        {
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(
                "UPDATE Employees SET Name = @Name, Department = @Department WHERE Id = @Id",
                connection);

            command.Parameters.AddWithValue("@Id", employee.Id);
            command.Parameters.AddWithValue("@Name", employee.Name);
            command.Parameters.AddWithValue("@Department", employee.Department);

            connection.Open();
            int rows = command.ExecuteNonQuery();
            Console.WriteLine($"Updated rows: {rows}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Update failed: {ex.Message}");
        }
    }

    public void DeleteEmployee(int id)
    {
        try
        {
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new("DELETE FROM Employees WHERE Id = @Id", connection);

            command.Parameters.AddWithValue("@Id", id);

            connection.Open();
            int rows = command.ExecuteNonQuery();
            Console.WriteLine($"Deleted rows: {rows}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Delete failed: {ex.Message}");
        }
    }
}

// The execution environment for this assignment may not include a SQL client package.
// These educational stand-ins keep the project buildable without installing packages.
// In a real application, remove this namespace and add Microsoft.Data.SqlClient from NuGet.
namespace System.Data.SqlClient
{
    internal sealed class SqlConnection(string connectionString) : IDisposable
    {
        public string ConnectionString { get; } = connectionString;

        public void Open()
        {
            throw new InvalidOperationException("Install Microsoft.Data.SqlClient and configure SQL Server to run this operation.");
        }

        public void Dispose()
        {
        }
    }

    internal sealed class SqlCommand(string commandText, SqlConnection connection) : IDisposable
    {
        public string CommandText { get; } = commandText;
        public SqlConnection Connection { get; } = connection;
        public SqlParameterCollection Parameters { get; } = new();

        public int ExecuteNonQuery() => throw new InvalidOperationException("SQL execution is disabled in this package-free demo.");

        public SqlDataReader ExecuteReader() => throw new InvalidOperationException("SQL execution is disabled in this package-free demo.");

        public void Dispose()
        {
        }
    }

    internal sealed class SqlParameterCollection
    {
        public void AddWithValue(string parameterName, object value)
        {
            Console.WriteLine($"Parameter prepared: {parameterName} = {value}");
        }
    }

    internal sealed class SqlDataReader : IDisposable
    {
        public bool Read() => false;

        public int GetInt32(int ordinal) => ordinal;

        public string GetString(int ordinal) => string.Empty;

        public void Dispose()
        {
        }
    }

    internal sealed class SqlDataAdapter(string selectCommandText, SqlConnection connection)
    {
        public string SelectCommandText { get; } = selectCommandText;
        public SqlConnection Connection { get; } = connection;

        public int Fill(DataTable table) => table.Rows.Count;
    }
}
