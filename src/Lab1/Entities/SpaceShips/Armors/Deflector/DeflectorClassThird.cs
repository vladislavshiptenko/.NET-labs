namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Armors.Deflector;

public class DeflectorClassThird : DeflectorBase
{
    public DeflectorClassThird(DeflectorPhotonic deflectorPhotonic)
        : base(deflectorPhotonic)
    {
        Hp = DeflectorClassThirdHp;
    }
}