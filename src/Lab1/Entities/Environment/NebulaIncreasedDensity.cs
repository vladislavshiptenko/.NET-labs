using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;

public class NebulaIncreasedDensity : Nebula
{
    public NebulaIncreasedDensity(int distance)
        : base(distance)
    {
    }

    public override void AddObstacle(ObstacleBase obstacle)
    {
        if (obstacle is null)
        {
            throw new ArgumentNullException(nameof(obstacle));
        }

        if (obstacle is not AntimatterFlares)
        {
            throw new ArgumentInvalidObstacleException(nameof(obstacle));
        }

        base.AddObstacle(obstacle);
    }
}