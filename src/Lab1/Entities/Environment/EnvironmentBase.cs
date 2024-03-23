using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;

public abstract class EnvironmentBase
{
    private IList<ObstacleBase> _obstacles;
    protected EnvironmentBase(double distance)
    {
        if (distance <= 0)
        {
            throw new ArgumentException("Negative distance");
        }

        Distance = distance;
        _obstacles = new List<ObstacleBase>();
    }

    public double Distance { get; }

    public virtual void AddObstacle(ObstacleBase obstacle)
    {
        _obstacles.Add(obstacle);
    }

    public bool HasUndestroyedObstacles()
    {
        return _obstacles.Any(obstacle => obstacle.Damage > 0);
    }

    public void ObstaclesAttack(SpaceShip ship)
    {
        foreach (ObstacleBase obstacle in _obstacles)
        {
            obstacle.Attack(ship);
        }
    }
}