// Exercise27 - Deadlock Prevention
// The first part describes the risky lock order; TryEnter avoids waiting forever.

object firstLock = new();
object secondLock = new();

Console.WriteLine("Potential deadlock pattern:");
Console.WriteLine("Thread A locks firstLock then waits for secondLock.");
Console.WriteLine("Thread B locks secondLock then waits for firstLock.");
Console.WriteLine("The demo below uses Monitor.TryEnter with timeouts to prevent a real deadlock.\n");

Thread threadA = new(() => TryWork("Thread A", firstLock, secondLock));
Thread threadB = new(() => TryWork("Thread B", secondLock, firstLock));

threadA.Start();
threadB.Start();
threadA.Join();
threadB.Join();

static void TryWork(string name, object primaryLock, object secondaryLock)
{
    bool primaryTaken = false;
    bool secondaryTaken = false;

    try
    {
        Monitor.TryEnter(primaryLock, TimeSpan.FromMilliseconds(500), ref primaryTaken);
        if (!primaryTaken)
        {
            Console.WriteLine($"{name} could not get the first lock.");
            return;
        }

        Thread.Sleep(100);
        Monitor.TryEnter(secondaryLock, TimeSpan.FromMilliseconds(500), ref secondaryTaken);
        if (!secondaryTaken)
        {
            Console.WriteLine($"{name} avoided deadlock by giving up the second lock.");
            return;
        }

        Console.WriteLine($"{name} acquired both locks and completed work.");
    }
    finally
    {
        if (secondaryTaken)
        {
            Monitor.Exit(secondaryLock);
        }

        if (primaryTaken)
        {
            Monitor.Exit(primaryLock);
        }
    }
}
