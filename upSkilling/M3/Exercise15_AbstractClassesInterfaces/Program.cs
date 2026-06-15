// Exercise15 - Abstract Classes and Interfaces
// An abstract class can share state; an interface defines a capability.

Vehicle vehicle = new Car("Honda City");
IDrivable drivable = (IDrivable)vehicle;

drivable.Start();
vehicle.Drive();

internal abstract class Vehicle(string name)
{
    public string Name { get; } = name;

    public abstract void Drive();
}

internal interface IDrivable
{
    void Start();
}

internal sealed class Car(string name) : Vehicle(name), IDrivable
{
    public void Start() => Console.WriteLine($"{Name} started.");

    public override void Drive() => Console.WriteLine($"{Name} is driving on the road.");
}
