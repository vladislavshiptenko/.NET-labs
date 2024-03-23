using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Engines;

public class EngineJumpingOmega : EngineJumping
{
    public EngineJumpingOmega()
        : base(FuelConsumptionSpeedOmega, SpeedStartOmega, CruisingRangeOmega)
    {
    }

    public override double FuelConsumption(EnvironmentBase environment)
    {
        if (environment is null)
        {
            throw new ArgumentNullException(nameof(environment));
        }

        return environment.Distance * double.Log2(environment.Distance) * FlyingTime(environment);
    }
}