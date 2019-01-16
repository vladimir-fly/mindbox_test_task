using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
			
public interface IFigure
{
	double GetTotalArea();
}

public class Triangle : IFigure
{
	private readonly double _adjacentСathetus;
	private readonly double _oppositeCathetus;
	private readonly double _hypotenuse;

	public Triangle(double adjacentСathetus, double oppositeCathetus, double hypotenuse)
	{
		Assert.IsTrue(adjacentСathetus >= 0, "Adjacent cathetus must be >= 0");
		Assert.IsTrue(oppositeCathetus >= 0, "Opposite cathetus must be >= 0");
		Assert.IsTrue(hypotenuse >= 0, "hypotenuse must be >= 0");

		_adjacentСathetus = adjacentСathetus;
	 	_oppositeCathetus = oppositeCathetus;  
	 	_hypotenuse = hypotenuse;
	}

	public double GetTotalArea()
	{
		var p = (_adjacentСathetus + _oppositeCathetus + _hypotenuse) / 2d;
		return Math.Round(Math.Sqrt(p * (p - _adjacentСathetus) * (p - _oppositeCathetus) * (p - _hypotenuse)), 2);
	}

	public bool IsRight => 
		Math.Abs(
			Math.Round(Math.Pow(_hypotenuse, 2), 2) - 
			Math.Round(Math.Pow(_adjacentСathetus, 2) + 
			           Math.Pow(_oppositeCathetus, 2), 2)) < 0.5;
}

public class Circle : IFigure
{
	private readonly double _radius;

	public Circle(double radius)
	{
		Assert.IsTrue(radius >= 0, "radius must be >= 0");

		_radius = radius;
	}

	public double GetTotalArea() => Math.Round(Math.PI * Math.Pow(_radius, 2), 2);
}

// Public API
public static class FigureManager
{
	public static double GetFigureTotalArea(IFigure figure) => figure.GetTotalArea();
	public static bool TriangleIsRight(Triangle triangle) => triangle.IsRight;
}

public class FigureTests
{
	public void TotalArea_1_Radius_Circle()
	{
		Assert.AreEqual(3.14, FigureManager.GetFigureTotalArea(new Circle(1)));	
	}

	public void TotalArea_2point5_Radius_Circle()
	{
		Assert.AreEqual(19.63, FigureManager.GetFigureTotalArea(new Circle(2.5)));	
	}

	public void TotalArea_78_Radius_Circle()
	{
		Assert.AreEqual(19113.45, FigureManager.GetFigureTotalArea(new Circle(78)));	
	}

	public void TotalArea_1_2_3_Edges_Triangle()
	{
		Assert.AreEqual(0, FigureManager.GetFigureTotalArea(new Triangle(1, 2, 3)));
	}

	public void TotalArea_23_32_3_Edges_Triangle()
	{
		Assert.AreEqual(349.24, FigureManager.GetFigureTotalArea(new Triangle(23, 32, 33)));
	}

	public void TotalArea_4_8_3point2_Edges_Triangle()
	{
		Assert.AreEqual(15.68, FigureManager.GetFigureTotalArea(new Triangle(4, 8, 8.2)));
	}

	public void Triangle_1_5_4_Edges_IsRight()
	{
		Assert.IsTrue(FigureManager.TriangleIsRight(new Triangle(4, 4, 5.7)));
	}

	public void Triangle_4_3_5_Edges_IsRight()
	{
		Assert.IsTrue(FigureManager.TriangleIsRight(new Triangle(4, 3, 5)));
	}
	
	public void Triangle_4_3_2_Edges_IsRight()
	{
		Assert.IsFalse(FigureManager.TriangleIsRight(new Triangle(4, 3, 2)));
	}
}

public class Program
{
	public static void Main()
	{
		Console.WriteLine("Figure tests started!");

		var figureTests = new FigureTests();
		
		figureTests.TotalArea_1_Radius_Circle();
		figureTests.TotalArea_2point5_Radius_Circle();
		figureTests.TotalArea_78_Radius_Circle();

		figureTests.TotalArea_1_2_3_Edges_Triangle();
		figureTests.TotalArea_23_32_3_Edges_Triangle();
		figureTests.TotalArea_4_8_3point2_Edges_Triangle();
		
		figureTests.Triangle_1_5_4_Edges_IsRight();
		figureTests.Triangle_4_3_5_Edges_IsRight();
		figureTests.Triangle_4_3_2_Edges_IsRight();

		Console.WriteLine("Figure tests complete!");
	}
}
