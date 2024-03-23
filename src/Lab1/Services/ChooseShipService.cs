using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public static class ChooseShipService
{
    public static SpaceShip ChooseOptimalShip(SpaceShip shipFirstCandidate, SpaceShip shipSecondCandidate, FlyingResult shipFirstFlyingResult, FlyingResult shipSecondFlyingResult)
    {
        if (shipFirstFlyingResult is null)
        {
            throw new ArgumentNullException(nameof(shipFirstFlyingResult));
        }

        if (shipSecondFlyingResult is null)
        {
            throw new ArgumentNullException(nameof(shipSecondFlyingResult));
        }

        if (shipFirstFlyingResult.Status.StatusType == FlyingStatus.FlyingStatusType.Success && shipSecondFlyingResult.Status.StatusType != FlyingStatus.FlyingStatusType.Success)
        {
            return shipFirstCandidate;
        }

        if (shipFirstFlyingResult.Status.StatusType != FlyingStatus.FlyingStatusType.Success && shipSecondFlyingResult.Status.StatusType == FlyingStatus.FlyingStatusType.Success)
        {
            return shipSecondCandidate;
        }

        if (shipFirstFlyingResult.FuelCost < shipSecondFlyingResult.FuelCost)
        {
            return shipFirstCandidate;
        }

        return shipSecondCandidate;
    }
}