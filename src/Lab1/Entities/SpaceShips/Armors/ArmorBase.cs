using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Armors;

public abstract class ArmorBase
{
    protected const double DeflectorClassFirstHp = 10;
    protected const double DeflectorClassSecondHp = 50;
    protected const double DeflectorClassThirdHp = 200;
    protected const double HullClassFirstHp = 5;
    protected const double HullClassSecondHp = 25;
    protected const double HullClassThirdHp = 100;
    public double Hp { get; protected set; }

    public virtual void TakeDamage(double damage)
    {
        if (damage < 0)
        {
            throw new ArgumentLessThanZeroException(nameof(damage));
        }

        if (Hp < damage)
        {
            Hp = 0;
        }
        else
        {
            Hp -= damage;
        }
    }
}