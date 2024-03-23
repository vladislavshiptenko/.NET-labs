using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Engines;

public class EngineJumpingAlpha : EngineJumping
{
    public EngineJumpingAlpha()
        : base(FuelConsumptionSpeedAlpha, SpeedStartAlpha, CruisingRangeAlpha)
    {
    }

    public override double FuelConsumption(EnvironmentBase environment)
    {
        if (environment is null)
        {
            throw new ArgumentNullException(nameof(environment));
        }

        return environment.Distance * FlyingTime(environment);
    }
}