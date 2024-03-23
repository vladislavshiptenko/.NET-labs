namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Armors.Deflector;

public abstract class DeflectorBase : ArmorBase
{
    protected DeflectorBase(DeflectorPhotonic deflectorPhotonic)
    {
        DeflectorPhotonic = deflectorPhotonic;
    }

    public DeflectorPhotonic? DeflectorPhotonic { get; }
    public override void TakeDamage(double damage)
    {
        base.TakeDamage(damage);
        DeflectorPhotonic?.Use();
    }
}