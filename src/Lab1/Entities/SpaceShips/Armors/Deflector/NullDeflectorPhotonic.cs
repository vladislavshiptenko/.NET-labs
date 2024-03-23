namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Armors.Deflector;

public class NullDeflectorPhotonic : DeflectorPhotonic
{
    public override bool CanUse()
    {
        return false;
    }

    public override void Use()
    {
    }
}