namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Armors.Deflector;

public class DeflectorPhotonic
{
    private const int StartAntimatterFlaresLimit = 3;
    private int _antimatterFlaresLimit = StartAntimatterFlaresLimit;

    public virtual bool CanUse()
    {
        return _antimatterFlaresLimit > 0;
    }

    public virtual void Use()
    {
        _antimatterFlaresLimit--;
    }
}