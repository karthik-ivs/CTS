// Exercise25 - FileStream and MemoryStream
// FileStream works with files; MemoryStream works with bytes in memory.

using System.Text;

string filePath = Path.Combine(AppContext.BaseDirectory, "sample.txt");
string sampleText = "FileStream wrote this line to disk.";
await File.WriteAllTextAsync(filePath, sampleText);

await using FileStream fileStream = File.OpenRead(filePath);
using StreamReader reader = new(fileStream, Encoding.UTF8);
string content = await reader.ReadToEndAsync();
Console.WriteLine($"Read from file: {content}");

byte[] bytes = Encoding.UTF8.GetBytes("MemoryStream stores this text as bytes.");
using MemoryStream memoryStream = new();
await memoryStream.WriteAsync(bytes);
Console.WriteLine($"Bytes written to MemoryStream: {memoryStream.Length}");
