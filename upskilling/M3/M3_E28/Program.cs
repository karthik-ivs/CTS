using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Trace.Listeners.Add(
            new TextWriterTraceListener("app.log"));

        Trace.AutoFlush = true;

        Trace.WriteLine("Application Started");

        Console.WriteLine("Application Started");

        Trace.WriteLine("Processing Data");

        Console.WriteLine("Processing Data");

        Trace.WriteLine("Application Ended");

        Console.WriteLine("Application Ended");

        Console.WriteLine("Logs written to app.log");
    }
}