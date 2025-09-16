namespace GeometryLib.Tests;

public class Point2DTests
{
    [Theory]
    [MemberData(nameof(DistanceTestData))]
    public void Can_calculate_distance(Point2D a, Point2D b, double expected)
    {
        double result = a.DistanceTo(b);
        //TODO: Реализовать корректное сравнение результатов, если это необходимо
        Assert.Equal(expected, result);
    }

    public static TheoryData<Point2D, Point2D, double> DistanceTestData()
    {
        return new TheoryData<Point2D, Point2D, double>
        {
            { new Point2D(0, 0), new Point2D(0, 0), 0.0 },
            { new Point2D(0, 0), new Point2D(0, 2), 2.0 },
            { new Point2D(0, 0), new Point2D(5, 5), 7.071 },
            { new Point2D(0, 0), new Point2D(2, 2.236), 3.0 },
        };
    }
}