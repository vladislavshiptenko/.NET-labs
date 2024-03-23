namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Armors.Deflector;

public class DeflectorClassFirst : DeflectorBase
{
    public DeflectorClassFirst(DeflectorPhotonic deflectorPhotonic)
        : base(deflectorPhotonic)
    {
        Hp = DeflectorClassFirstHp;
    }
}