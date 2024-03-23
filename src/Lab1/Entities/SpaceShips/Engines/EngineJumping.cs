using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Engines;

public abstract class EngineJumping : EngineBase
{
    protected const double FuelConsumptionSpeedAlpha = 10;
    protected const double SpeedStartAlpha = 5;
    protected const double CruisingRangeAlpha = 100;
    protected const double FuelConsumptionSpeedGamma = 12;
    protected const double SpeedStartGamma = 7;
    protected const double CruisingRangeGamma = 120;
    protected const double FuelConsumptionSpeedOmega = 15;
    protected const double SpeedStartOmega = 10;
    protected const double CruisingRangeOmega = 150;
    private double _cruisingRange;
    protected EngineJumping(double fuelConsumptionSpeed, double speedStart, double cruisingRange)
        : base(fuelConsumptionSpeed, speedStart)
    {
        if (cruisingRange <= 0)
        {
            throw new ArgumentLessThanZeroException(nameof(cruisingRange));
        }

        _cruisingRange = cruisingRange;
    }

    public override void Fly(EnvironmentBase environment)
    {
        if (environment is null)
        {
            throw new ArgumentNullException(nameof(environment));
        }

        if (_cruisingRange < environment.Distance)
        {
            _cruisingRange = 0;
            IsEngineBroken = true;
            return;
        }

        _cruisingRange -= environment.Distance;
        base.Fly(environment);
    }

    public override double FlyingTime(EnvironmentBase environment)
    {
        if (environment is null)
        {
            throw new ArgumentNullException(nameof(environment));
        }

        return environment.Distance / SpeedStart;
    }

    protected override bool IsCompatibleEnvironment(EnvironmentBase environment)
    {
        return environment is NebulaIncreasedDensity;
    }
}