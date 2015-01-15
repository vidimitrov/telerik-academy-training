public class Size
{
    public double width, height;
    public Size(double initialWidth, double initialHeight)
    {
        this.width = initialWidth;
        this.height = initialHeight;
    }
}

public static Size GetRotatedSize(
    Size normalSize, double rotatedFigureAngle)
{
        Size result = new Size(
            Math.Abs(Math.Cos(rotatedFigureAngle)) * normalSize.width + 
                Math.Abs(Math.Sin(rotatedFigureAngle)) * normalSize.height,
            Math.Abs(Math.Sin(rotatedFigureAngle)) * normalSize.width + 
                Math.Abs(Math.Cos(rotatedFigureAngle)) * normalSize.height);
        
        return result;
}
