namespace Itmo.ObjectOrientedProgramming.Lab2.Models.GeneralAttributes;

public class FormFactorDimensionsMatching
{
    public FormFactorDimensionsMatching(FormFactorType type, MillimetersDimensions dimensions)
    {
        Type = type;
        Dimensions = dimensions;
    }

    public FormFactorType Type { get; }
    public MillimetersDimensions Dimensions { get; }
}