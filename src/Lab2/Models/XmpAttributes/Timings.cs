using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.XmpAttributes;

public class Timings
{
    public Timings(int rasToCas, int rasPrecharge, int tras, int trc)
    {
        if (rasToCas < 10 || rasToCas > 20)
        {
            throw new ArgumentInvalidValueException(nameof(rasToCas));
        }

        if (rasPrecharge < 10 || rasPrecharge > 20)
        {
            throw new ArgumentInvalidValueException(nameof(rasPrecharge));
        }

        if (tras < 10 || tras > 40)
        {
            throw new ArgumentInvalidValueException(nameof(tras));
        }

        if (trc < 10 || trc > 60)
        {
            throw new ArgumentInvalidValueException(nameof(trc));
        }

        RasToCas = rasToCas;
        RasPrecharge = rasPrecharge;
        TRas = tras;
        TRc = trc;
    }

    public int RasToCas { get; }
    public int RasPrecharge { get; }
    public int TRas { get; }
    public int TRc { get; }
}