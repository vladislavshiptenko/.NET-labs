using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;

public class MillimetersDimensions
{
    public MillimetersDimensions(int length, int width, int height)
    {
        if (length < 15 || length > 1000)
        {
            throw new ArgumentInvalidValueException(nameof(length));
        }

        if (width < 15 || width > 1000)
        {
            throw new ArgumentInvalidValueException(nameof(width));
        }

        if (height < 15 || height > 1000)
        {
            throw new ArgumentInvalidValueException(nameof(height));
        }

        Length = length;
        Width = width;
        Height = height;
    }

    public int Length { get; }
    public int Width { get; }
    public int Height { get; }
}