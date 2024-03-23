using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Engines;

public class EnginePulseE : EnginePulse
{
    public EnginePulseE()
        : base(FuelConsumptionSpeedE, SpeedStartE)
    {
    }

    public override double FlyingTime(EnvironmentBase environment)
    {
        if (environment is null)
        {
            throw new ArgumentNullException(nameof(environment));
        }

        return Math.Log(environment.Distance);
    }

    protected override bool IsCompatibleEnvironment(EnvironmentBase environment)
    {
        return base.IsCompatibleEnvironment(environment) || environment is NebulaNitrineParticles;
    }
}