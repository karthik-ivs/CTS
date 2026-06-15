// Exercise23 - Async File Upload
// Task.Delay simulates a slow upload without blocking the calling thread.

try
{
    Console.WriteLine("Starting simulated upload...");
    string result = await UploadFileAsync("profile-photo.png");
    Console.WriteLine(result);
}
catch (Exception ex)
{
    Console.WriteLine($"Upload failed: {ex.Message}");
}

static async Task<string> UploadFileAsync(string fileName)
{
    await Task.Delay(3000);
    return $"{fileName} uploaded successfully.";
}
