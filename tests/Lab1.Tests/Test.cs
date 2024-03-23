using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Armors.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Results;
using Itmo.ObjectOrientedProgramming.Lab1.Services;
using Xunit;
using static Itmo.ObjectOrientedProgramming.Lab1.Tests.TestData;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;
public class Test
{
    [Theory]
    [MemberData(nameof(FirstTestShips), MemberType = typeof(TestData))]
    public void NebulaIncreasedDensityPleasureShuttleAvgurFail(SpaceShip shipFirst, SpaceShip shipSecond)
    {
        IList<EnvironmentBase> route = new List<EnvironmentBase>();
        route.Add(new NebulaIncreasedDensity(110));

        if (shipFirst is null)
        {
            throw new ArgumentNullException(nameof(shipFirst));
        }

        if (shipSecond is null)
        {
            throw new ArgumentNullException(nameof(shipSecond));
        }

        var journeyService = new JourneyService();
        journeyService.Travel(shipFirst, route);
        FlyingResult shipFirstResult = journeyService.LastTravelResult;
        journeyService.Travel(shipSecond, route);
        FlyingResult shipSecondResult = journeyService.LastTravelResult;

        Assert.Equal(FlyingStatus.FlyingStatusType.ShipLoss, shipFirstResult.Status.StatusType);
        Assert.Equal(FlyingStatus.FlyingStatusType.ShipLoss, shipSecondResult.Status.StatusType);
    }

    [Theory]
    [MemberData(nameof(SecondTestShips), MemberType = typeof(TestData))]
    public void AntimatterFlaresVaklasWithDeflectorPhotonicAndWithout(SpaceShip shipFirst, SpaceShip shipSecond)
    {
        IList<EnvironmentBase> route = new List<EnvironmentBase>();
        route.Add(new NebulaIncreasedDensity(20));
        route[0].AddObstacle(new AntimatterFlares());

        if (shipFirst is null)
        {
            throw new ArgumentNullException(nameof(shipFirst));
        }

        if (shipSecond is null)
        {
            throw new ArgumentNullException(nameof(shipSecond));
        }

        var journeyService = new JourneyService();
        journeyService.Travel(shipFirst, route);
        FlyingResult shipFirstResult = journeyService.LastTravelResult;
        journeyService.Travel(shipSecond, route);
        FlyingResult shipSecondResult = journeyService.LastTravelResult;

        Assert.Equal(FlyingStatus.FlyingStatusType.CrewLoss, shipFirstResult.Status.StatusType);
        Assert.Equal(FlyingStatus.FlyingStatusType.Success, shipSecondResult.Status.StatusType);
    }

    [Theory]
    [MemberData(nameof(ThirdTestShips), MemberType = typeof(TestData))]
    public void SpaceWhalesInNebulaShipFirstDestroyingShipSecondLossDeflector(SpaceShip shipFirst, SpaceShip shipSecond, SpaceShip shipThird)
    {
        IList<EnvironmentBase> route1 = new List<EnvironmentBase>();
        IList<EnvironmentBase> route2 = new List<EnvironmentBase>();
        IList<EnvironmentBase> route3 = new List<EnvironmentBase>();
        route1.Add(new NebulaNitrineParticles(20));
        route2.Add(new NebulaNitrineParticles(20));
        route3.Add(new NebulaNitrineParticles(20));

        route1[0].AddObstacle(new SpaceWhales());
        route2[0].AddObstacle(new SpaceWhales());
        route3[0].AddObstacle(new SpaceWhales());

        if (shipFirst is null)
        {
            throw new ArgumentNullException(nameof(shipFirst));
        }

        if (shipSecond is null)
        {
            throw new ArgumentNullException(nameof(shipSecond));
        }

        if (shipThird is null)
        {
            throw new ArgumentNullException(nameof(shipThird));
        }

        var journeyService = new JourneyService();
        journeyService.Travel(shipFirst, route1);
        FlyingResult shipFirstResult = journeyService.LastTravelResult;
        journeyService.Travel(shipSecond, route2);
        FlyingResult shipSecondResult = journeyService.LastTravelResult;
        journeyService.Travel(shipThird, route3);
        FlyingResult shipThirdResult = journeyService.LastTravelResult;

        Assert.Equal(FlyingStatus.FlyingStatusType.ShipDestroying, shipFirstResult.Status.StatusType);
        Assert.Equal(FlyingStatus.FlyingStatusType.Success, shipSecondResult.Status.StatusType);
        Assert.Equal(FlyingStatus.FlyingStatusType.Success, shipThirdResult.Status.StatusType);
        Assert.Equal(0, shipSecond.Deflector?.Hp);
        Assert.NotEqual(0, shipThird.Deflector?.Hp);
    }

    [Fact]
    public void PleasureShuttleAndVaklasCompareInSpace()
    {
        var shipFirst = new PleasureShuttle();
        var shipSecond = new Vaklas(new NullDeflectorPhotonic());
        IList<EnvironmentBase> route = new List<EnvironmentBase>();
        route.Add(new Space(30));

        var journeyService = new JourneyService();
        journeyService.Travel(shipFirst, route);
        FlyingResult shipFirstResult = journeyService.LastTravelResult;
        journeyService.Travel(shipSecond, route);
        FlyingResult shipSecondResult = journeyService.LastTravelResult;

        Assert.Equal(shipFirst, ChooseShipService.ChooseOptimalShip(shipFirst, shipSecond, shipFirstResult, shipSecondResult));
    }

    [Fact]
    public void AvgurAndStellaCompareInNebulaIncreasedDensity()
    {
        var shipFirst = new Avgur(new NullDeflectorPhotonic());
        var shipSecond = new Stella(new NullDeflectorPhotonic());
        IList<EnvironmentBase> route = new List<EnvironmentBase>();
        route.Add(new NebulaIncreasedDensity(110));

        var journeyService = new JourneyService();
        journeyService.Travel(shipFirst, route);
        FlyingResult shipFirstResult = journeyService.LastTravelResult;
        journeyService.Travel(shipSecond, route);
        FlyingResult shipSecondResult = journeyService.LastTravelResult;

        Assert.Equal(shipSecond, ChooseShipService.ChooseOptimalShip(shipFirst, shipSecond, shipFirstResult, shipSecondResult));
    }

    [Fact]
    public void PleasureShuttleAndVaklasCompareInNebulaNitrineParticles()
    {
        var shipFirst = new PleasureShuttle();
        var shipSecond = new Vaklas(new NullDeflectorPhotonic());
        IList<EnvironmentBase> route = new List<EnvironmentBase>();
        route.Add(new NebulaNitrineParticles(110));

        var journeyService = new JourneyService();
        journeyService.Travel(shipFirst, route);
        FlyingResult shipFirstResult = journeyService.LastTravelResult;
        journeyService.Travel(shipSecond, route);
        FlyingResult shipSecondResult = journeyService.LastTravelResult;

        Assert.Equal(shipSecond, ChooseShipService.ChooseOptimalShip(shipFirst, shipSecond, shipFirstResult, shipSecondResult));
    }

    [Fact]
    public void ShipsTestInDifferentEnvironmentsWithObstacles()
    {
        var shipFirst = new PleasureShuttle();
        var shipSecond = new Vaklas(new NullDeflectorPhotonic());
        var shipThird = new Stella(new NullDeflectorPhotonic());
        var shipFourth = new Avgur(new DeflectorPhotonic());

        IList<EnvironmentBase> route1 = LastTestRouteData();
        IList<EnvironmentBase> route2 = LastTestRouteData();
        IList<EnvironmentBase> route3 = LastTestRouteData();
        IList<EnvironmentBase> route4 = LastTestRouteData();

        var journeyService = new JourneyService();
        journeyService.Travel(shipFirst, route1);
        FlyingResult shipFirstResult = journeyService.LastTravelResult;
        journeyService.Travel(shipSecond, route2);
        FlyingResult shipSecondResult = journeyService.LastTravelResult;
        journeyService.Travel(shipThird, route3);
        FlyingResult shipThirdResult = journeyService.LastTravelResult;
        journeyService.Travel(shipFourth, route4);
        FlyingResult shipFourthResult = journeyService.LastTravelResult;

        Assert.Equal(FlyingStatus.FlyingStatusType.ShipDestroying, shipFirstResult.Status.StatusType);
        Assert.Equal(FlyingStatus.FlyingStatusType.CrewLoss, shipSecondResult.Status.StatusType);
        Assert.Equal(FlyingStatus.FlyingStatusType.ShipDestroying, shipThirdResult.Status.StatusType);
        Assert.Equal(FlyingStatus.FlyingStatusType.ShipLoss, shipFourthResult.Status.StatusType);
    }
}