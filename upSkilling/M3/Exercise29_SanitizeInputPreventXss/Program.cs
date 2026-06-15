// Exercise29 - XSS Prevention
// HTML encoding changes dangerous characters into safe text.

using System.Net;

string userInput = "<script>alert('xss')</script><b>Hello</b>";
string sanitized = WebUtility.HtmlEncode(userInput);

Console.WriteLine($"Original input: {userInput}");
Console.WriteLine($"Sanitized output: {sanitized}");
Console.WriteLine("The sanitized value can be displayed as text without executing script tags.");
