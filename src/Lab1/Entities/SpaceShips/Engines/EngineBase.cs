using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Engines;

public abstract class EngineBase
{
    protected EngineBase(double fuelConsumptionSpeed, double speedStart)
    {
        if (fuelConsumptionSpeed <= 0)
        {
            throw new ArgumentLessThanZeroException(nameof(fuelConsumptionSpeed));
        }

        if (speedStart <= 0)
        {
            throw new ArgumentLessThanZeroException(nameof(speedStart));
        }

        FuelConsumptionSpeed = fuelConsumptionSpeed;
        SpeedStart = speedStart;
    }

    public bool IsEngineBroken { get; protected set; }
    protected double FuelConsumptionSpeed { get; }
    protected double SpeedStart { get; }
    public virtual void Fly(EnvironmentBase environment)
    {
        if (!IsCompatibleEnvironment(environment))
        {
            IsEngineBroken = true;
        }
    }

    public abstract double FlyingTime(EnvironmentBase environment);
    public abstract double FuelConsumption(EnvironmentBase environment);
    protected abstract bool IsCompatibleEnvironment(EnvironmentBase environment);
}