using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Engines;

public class EngineJumpingGamma : EngineJumping
{
    public EngineJumpingGamma()
        : base(FuelConsumptionSpeedGamma, SpeedStartGamma, CruisingRangeGamma)
    {
    }

    public override double FuelConsumption(EnvironmentBase environment)
    {
        if (environment is null)
        {
            throw new ArgumentNullException(nameof(environment));
        }

        return environment.Distance * environment.Distance * FlyingTime(environment);
    }
}