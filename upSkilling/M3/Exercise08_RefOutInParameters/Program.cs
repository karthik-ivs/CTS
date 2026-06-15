// Exercise08 - ref, out, and in
// ref can read/write, out must assign, and in passes a readonly reference.

int refValue = 10;
Console.WriteLine($"Before ref method: {refValue}");
DoubleWithRef(ref refValue);
Console.WriteLine($"After ref method: {refValue}\n");

CreateMessage(out string message);
Console.WriteLine($"Value assigned by out method: {message}\n");

int readonlyValue = 50;
Console.WriteLine($"Before in method: {readonlyValue}");
PrintUsingIn(in readonlyValue);
Console.WriteLine($"After in method: {readonlyValue}");

static void DoubleWithRef(ref int value)
{
    value *= 2;
}

static void CreateMessage(out string message)
{
    message = "The out parameter was assigned inside the method.";
}

static void PrintUsingIn(in int value)
{
    Console.WriteLine($"The in parameter is readable here: {value}");
}
