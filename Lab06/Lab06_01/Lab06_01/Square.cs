using System;

public class Square : Quadrilateral
{
	public double SideLength { get; private set; }

	public Square(Point origin, double sideLength)
		: base(origin,
			   new Point(origin.X + sideLength, origin.Y),
			   new Point(origin.X + sideLength, origin.Y + sideLength),
			   new Point(origin.X, origin.Y + sideLength))
	{
		SideLength = sideLength;
	}

	public override double Perimeter() => 4 * SideLength;

	public override double Area() => SideLength * SideLength;

	public override string ToString() =>
		$"Квадрат із вершини {A} зі стороною {SideLength:F2}";
}
