using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles.StoneObstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;

public class Space : EnvironmentBase
{
    public Space(int distance)
        : base(distance)
    {
    }

    public override void AddObstacle(ObstacleBase obstacle)
    {
        if (obstacle is null)
        {
            throw new ArgumentNullException(nameof(obstacle));
        }

        if (obstacle is not StoneObstacle)
        {
            throw new ArgumentInvalidObstacleException(nameof(obstacle));
        }

        base.AddObstacle(obstacle);
    }
}