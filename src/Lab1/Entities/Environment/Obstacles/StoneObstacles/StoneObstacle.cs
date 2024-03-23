using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles.StoneObstacles;

public abstract class StoneObstacle : ObstacleBase
{
    public override void Attack(SpaceShip ship)
    {
        if (ship is null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        if (ship.Deflector != null)
        {
            double deflectorDamage = Math.Min(Damage / ship.Weight, ship.Deflector.Hp);
            ship.Deflector.TakeDamage(deflectorDamage);
            Damage -= deflectorDamage * ship.Weight;
        }

        if (ship.Armor != null)
        {
            double armorDamage = Math.Min(Damage / ship.Weight, ship.Armor.Hp);
            ship.Armor.TakeDamage(armorDamage);
            Damage -= armorDamage * ship.Weight;
        }
    }
}