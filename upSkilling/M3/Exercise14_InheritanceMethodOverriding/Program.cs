// Exercise14 - Inheritance and Method Overriding
// A base reference can call overridden methods on derived objects.

Shape[] shapes = [new Circle(), new Rectangle()];

foreach (Shape shape in shapes)
{
    shape.Draw();
}

internal class Shape
{
    public virtual void Draw() => Console.WriteLine("Drawing a generic shape.");
}

internal sealed class Circle : Shape
{
    public override void Draw() => Console.WriteLine("Drawing a circle.");
}

internal sealed class Rectangle : Shape
{
    public override void Draw() => Console.WriteLine("Drawing a rectangle.");
}
