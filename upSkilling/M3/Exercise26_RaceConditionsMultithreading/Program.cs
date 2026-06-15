// Exercise26 - Race Conditions
// Multiple threads updating shared data need synchronization.

const int threadCount = 8;
const int incrementsPerThread = 100_000;

int unsafeCounter = RunWithoutLock(threadCount, incrementsPerThread);
int safeCounter = RunWithLock(threadCount, incrementsPerThread);
int expected = threadCount * incrementsPerThread;

Console.WriteLine($"Expected counter value: {expected}");
Console.WriteLine($"Without lock: {unsafeCounter}");
Console.WriteLine($"With lock: {safeCounter}");

static int RunWithoutLock(int threadCount, int incrementsPerThread)
{
    int counter = 0;
    Thread[] threads = CreateThreads(threadCount, () =>
    {
        for (int i = 0; i < incrementsPerThread; i++)
        {
            counter++;
        }
    });

    StartAndJoin(threads);
    return counter;
}

static int RunWithLock(int threadCount, int incrementsPerThread)
{
    int counter = 0;
    object gate = new();
    Thread[] threads = CreateThreads(threadCount, () =>
    {
        for (int i = 0; i < incrementsPerThread; i++)
        {
            lock (gate)
            {
                counter++;
            }
        }
    });

    StartAndJoin(threads);
    return counter;
}

static Thread[] CreateThreads(int threadCount, ThreadStart action)
{
    return Enumerable.Range(0, threadCount).Select(_ => new Thread(action)).ToArray();
}

static void StartAndJoin(Thread[] threads)
{
    foreach (Thread thread in threads)
    {
        thread.Start();
    }

    foreach (Thread thread in threads)
    {
        thread.Join();
    }
}
