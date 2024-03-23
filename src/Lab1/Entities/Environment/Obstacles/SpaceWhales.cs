using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles;

public class SpaceWhales : ObstacleBase
{
    public SpaceWhales()
    {
        Damage = SpaceWhalesDamage;
    }

    public override void Attack(SpaceShip ship)
    {
        if (ship is null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        if (ship.AntinitrineEmitter is not null && ship.AntinitrineEmitter.LimitUse != 0)
        {
            ship.AntinitrineEmitter.Use();
            Damage = 0;
            return;
        }

        base.Attack(ship);
    }
}