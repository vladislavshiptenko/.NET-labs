using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles.StoneObstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Armors.Deflector;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public static class TestData
{
    public static IEnumerable<object[]> FirstTestShips()
    {
        yield return new object[]
        {
            new PleasureShuttle(),
            new Avgur(new NullDeflectorPhotonic()),
        };
    }

    public static IEnumerable<object[]> SecondTestShips()
    {
        yield return new object[]
        {
            new Vaklas(new NullDeflectorPhotonic()),
            new Vaklas(new DeflectorPhotonic()),
        };
    }

    public static IEnumerable<object[]> ThirdTestShips()
    {
        yield return new object[]
        {
            new Vaklas(new NullDeflectorPhotonic()),
            new Avgur(new NullDeflectorPhotonic()),
            new Meridian(new NullDeflectorPhotonic()),
        };
    }

    public static IList<EnvironmentBase> LastTestRouteData()
    {
        var environment1 = new NebulaIncreasedDensity(50);

        var environment2 = new Space(30);
        environment2.AddObstacle(new Meteorite());
        environment2.AddObstacle(new Asteroid());

        var environment3 = new NebulaIncreasedDensity(30);
        environment3.AddObstacle(new AntimatterFlares());

        IList<EnvironmentBase> route = new List<EnvironmentBase>();
        route.Add(environment1);
        route.Add(environment2);
        route.Add(environment3);

        return route;
    }
}