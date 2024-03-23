using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Engines;

public abstract class EnginePulse : EngineBase
{
    protected const double FuelConsumptionSpeedC = 8;
    protected const double SpeedStartC = 14;
    protected const double FuelConsumptionSpeedE = 20;
    protected const double SpeedStartE = 12;
    protected EnginePulse(double fuelConsumptionSpeed, double speedStart)
        : base(fuelConsumptionSpeed, speedStart)
    {
    }

    public override double FuelConsumption(EnvironmentBase environment)
    {
        if (environment is null)
        {
            throw new ArgumentNullException(nameof(environment));
        }

        return FuelConsumptionSpeed * FlyingTime(environment);
    }

    protected override bool IsCompatibleEnvironment(EnvironmentBase environment)
    {
        return environment is Space;
    }
}