// Exercise28 - Trace Logging
// Trace can write the same log event to multiple listeners.

using System.Diagnostics;

string logPath = Path.Combine(AppContext.BaseDirectory, "application.log");

Trace.Listeners.Clear();
Trace.Listeners.Add(new ConsoleTraceListener());
Trace.Listeners.Add(new TextWriterTraceListener(logPath));
Trace.AutoFlush = true;

Trace.WriteLine("Application started.");
Trace.WriteLine($"Log file path: {logPath}");
Trace.WriteLine("Application completed.");

Console.WriteLine("Trace messages were written to the console and log file.");
