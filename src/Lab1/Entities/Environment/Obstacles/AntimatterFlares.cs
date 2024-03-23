using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles;

public class AntimatterFlares : ObstacleBase
{
    public AntimatterFlares()
    {
        Damage = AntimatterFlaresDamage;
    }

    public override void Attack(SpaceShip ship)
    {
        if (ship is null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        if (ship.Deflector is null || ship.Deflector.DeflectorPhotonic is null || !ship.Deflector.DeflectorPhotonic.CanUse())
        {
            ship.KillCrew();
            return;
        }

        ship.Deflector.TakeDamage(Damage);
    }
}