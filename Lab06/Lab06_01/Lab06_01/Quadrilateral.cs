using System;

public class Quadrilateral
{
	protected Point A, B, C, D;

	public Quadrilateral(Point a, Point b, Point c, Point d)
	{
		A = a; B = b; C = c; D = d;
	}

	public virtual void Move(double dx, double dy)
	{
		A = new Point(A.X + dx, A.Y + dy);
		B = new Point(B.X + dx, B.Y + dy);
		C = new Point(C.X + dx, C.Y + dy);
		D = new Point(D.X + dx, D.Y + dy);
	}

	public double SideLength(Point p1, Point p2) =>
		Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));

	public double[] GetSides() => new[]
	{
		SideLength(A, B),
		SideLength(B, C),
		SideLength(C, D),
		SideLength(D, A)
	};

	public virtual double Perimeter()
	{
		var s = GetSides();
		return s[0] + s[1] + s[2] + s[3];
	}

	public virtual double Area()
	{
		// Розбиваємо на 2 трикутники: ABC і CDA
		double s1 = TriangleArea(A, B, C);
		double s2 = TriangleArea(C, D, A);
		return s1 + s2;
	}

	private double TriangleArea(Point p1, Point p2, Point p3)
	{
		double a = SideLength(p1, p2);
		double b = SideLength(p2, p3);
		double c = SideLength(p3, p1);
		double s = (a + b + c) / 2;
		return Math.Sqrt(s * (s - a) * (s - b) * (s - c)); // Герон
	}

	public override string ToString() =>
		$"Чотирикутник: A{A}, B{B}, C{C}, D{D}";

	public override bool Equals(object obj) =>
		obj is Quadrilateral q &&
		A.Equals(q.A) && B.Equals(q.B) &&
		C.Equals(q.C) && D.Equals(q.D);

	public override int GetHashCode() =>
		HashCode.Combine(A, B, C, D);
}
