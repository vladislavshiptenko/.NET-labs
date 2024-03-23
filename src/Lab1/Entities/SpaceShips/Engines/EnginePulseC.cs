using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Engines;

public class EnginePulseC : EnginePulse
{
    public EnginePulseC()
        : base(FuelConsumptionSpeedC, SpeedStartC)
    {
    }

    public override double FlyingTime(EnvironmentBase environment)
    {
        if (environment is null)
        {
            throw new ArgumentNullException(nameof(environment));
        }

        return environment.Distance / SpeedStart;
    }
}