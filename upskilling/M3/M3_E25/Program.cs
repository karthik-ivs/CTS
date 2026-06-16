using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        string fileName = "sample.txt";

        File.WriteAllText(
            fileName,
            "Welcome to C# FileStream Demo");

        using (FileStream fs =
            new FileStream(
                fileName,
                FileMode.Open,
                FileAccess.Read))
        {
            byte[] buffer = new byte[fs.Length];

            fs.Read(buffer, 0, buffer.Length);

            string content =
                Encoding.UTF8.GetString(buffer);

            Console.WriteLine("File Content:");
            Console.WriteLine(content);
        }

        Console.WriteLine();

        using (MemoryStream ms = new MemoryStream())
        {
            byte[] data =
                Encoding.UTF8.GetBytes(
                    "MemoryStream Example");

            ms.Write(data, 0, data.Length);

            Console.WriteLine(
                $"Bytes Written: {ms.Length}");
        }
    }
}