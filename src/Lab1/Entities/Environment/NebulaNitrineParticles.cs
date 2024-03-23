using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;

public class NebulaNitrineParticles : EnvironmentBase
{
    public NebulaNitrineParticles(double distance)
        : base(distance)
    {
    }

    public override void AddObstacle(ObstacleBase obstacle)
    {
        if (obstacle is null)
        {
            throw new ArgumentNullException(nameof(obstacle));
        }

        if (obstacle is not SpaceWhales)
        {
            throw new ArgumentInvalidObstacleException(nameof(obstacle));
        }

        base.AddObstacle(obstacle);
    }
}