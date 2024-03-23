namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Armors.Deflector;

public class DeflectorClassSecond : DeflectorBase
{
    public DeflectorClassSecond(DeflectorPhotonic deflectorPhotonic)
        : base(deflectorPhotonic)
    {
        Hp = DeflectorClassSecondHp;
    }
}