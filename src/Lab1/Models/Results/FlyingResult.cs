using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

public class FlyingResult
{
    public FlyingResult(FlyingStatus status, double flyingTime, double fuelCost, double fuelSpend)
    {
        Status = status;
        if (FlyingTime < 0 || fuelCost < 0 || fuelSpend < 0)
        {
            throw new ArgumentException(string.Empty);
        }

        FlyingTime = flyingTime;
        FuelCost = fuelCost;
        FuelSpend = fuelSpend;
    }

    public FlyingStatus Status { get; }
    public double FlyingTime { get; }
    public double FuelCost { get; }
    public double FuelSpend { get; }
}