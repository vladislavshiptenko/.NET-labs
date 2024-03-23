using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Armors.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Armors.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Emitter;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

public class Meridian : SpaceShip
{
    public Meridian(DeflectorPhotonic deflectorPhotonic)
        : base(new EnginePulseE(), null, new DeflectorClassSecond(deflectorPhotonic), new HullClassSecond(), new AntinitrineEmitter(), MiddleWeight)
    {
    }
}