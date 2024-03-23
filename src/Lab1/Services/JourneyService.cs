using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class JourneyService
{
    private const double FuelUnitCost = 10;
    public FlyingResult LastTravelResult { get; private set; } = new(new FlyingStatus(FlyingStatus.FlyingStatusType.Success), 0, 0, 0);

    public void Travel(SpaceShip ship, IList<EnvironmentBase> route)
    {
        if (route is null)
        {
            throw new ArgumentNullException(nameof(route));
        }

        if (ship is null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        foreach (EnvironmentBase environment in route)
        {
            ship.Fly(environment);
        }

        FormTravelResult(ship, route);
    }

    private void FormTravelResult(SpaceShip ship, IList<EnvironmentBase> route)
    {
        if (ship is null)
        {
            throw new ArgumentNullException(nameof(ship));
        }

        double flyingTime = 0;
        double fuelSpend = 0;
        foreach (EnvironmentBase environment in route)
        {
            if (ship.EngineJumping is not null)
            {
                flyingTime += ship.EngineJumping.FlyingTime(environment);
                fuelSpend += ship.EngineJumping.FuelConsumption(environment);
            }

            if (ship.EnginePulse is not null)
            {
                flyingTime += ship.EnginePulse.FlyingTime(environment);
                fuelSpend += ship.EnginePulse.FuelConsumption(environment);
            }
        }

        double fuelCost = fuelSpend * FuelUnitCost;
        var status = new FlyingStatus(FlyingStatus.FlyingStatusType.Success);
        if (route.Any(environment => environment.HasUndestroyedObstacles()))
        {
            status = new FlyingStatus(FlyingStatus.FlyingStatusType.ShipDestroying);
        }
        else if (ship.IsCrewLoss)
        {
            status = new FlyingStatus(FlyingStatus.FlyingStatusType.CrewLoss);
        }
        else if ((ship.EngineJumping is null || ship.EngineJumping.IsEngineBroken) && (ship.EnginePulse is null || ship.EnginePulse.IsEngineBroken))
        {
            status = new FlyingStatus(FlyingStatus.FlyingStatusType.ShipLoss);
        }

        LastTravelResult = new FlyingResult(status, flyingTime, fuelCost, fuelSpend);
    }
}