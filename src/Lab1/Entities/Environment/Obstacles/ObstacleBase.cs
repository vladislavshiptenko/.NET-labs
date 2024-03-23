using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles;

public abstract class ObstacleBase
{
    protected const double AsteroidDamage = 5;
    protected const double MeteoriteDamage = 20;
    protected const double AntimatterFlaresDamage = 0;
    protected const double SpaceWhalesDamage = 200;
    public double Damage { get; protected set; }

    public virtual void Attack(SpaceShip ship)
    {
        if (ship is null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        if (ship.Deflector != null)
        {
            double deflectorDamage = Math.Min(Damage, ship.Deflector.Hp);
            ship.Deflector.TakeDamage(deflectorDamage);
            Damage -= deflectorDamage;
        }

        if (ship.Armor != null)
        {
            double armorDamage = Math.Min(Damage, ship.Armor.Hp);
            ship.Armor.TakeDamage(armorDamage);
            Damage -= armorDamage;
        }
    }
}