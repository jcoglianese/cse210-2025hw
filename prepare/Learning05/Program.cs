using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square();
        square.SetColor("Blue");
        square.SetSide(4);

        Rectangle rectangle = new Rectangle();
        rectangle.SetColor("Green");
        rectangle.SetLength(4);
        rectangle.SetWidth(5);

        Circle circle = new Circle();
        circle.SetColor("Red");
        circle.SetRadius(3);

        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape shape in shapes){
            double area = shape.GetArea();
            Console.WriteLine($"\nThe {shape.GetColor()} {shape} has an area of {area}\n");
        }
    }
}