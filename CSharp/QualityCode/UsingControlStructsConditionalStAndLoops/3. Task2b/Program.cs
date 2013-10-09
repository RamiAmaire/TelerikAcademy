using System;

public class Program
{
    public const int MaxWidth = 0;
    public const int MinWidth = 0;
    
    public const int MaxHeight = 0;
    public const int MinHeight = 0;

    public static bool IsVisitedCell { get; set; }

    private static void VisitCell()
    {
        throw new NotImplementedException();
    }

    private static bool GettingValidation(int currentWidth, int currentHeight)
    {
        if ((currentWidth >= MinWidth && currentWidth <= MaxWidth) &&
            (currentHeight >= MinHeight && currentHeight <= MaxHeight) &&
            !IsVisitedCell)
        {
            return true;
        }

        return false;
    }

    private static void Main()
    {
        int currentWidth = 5;
        int currentHeight = 3;

        if (GettingValidation(currentWidth, currentHeight))
        {
           VisitCell();
        }
    }
}
