using System.Diagnostics;

namespace SumIntervalsSample.BusinessLibrary.Models;

[DebuggerDisplay("{ToString()}")]
public class Interval
{
    public int From { get; set; }
    public int To{ get; set; }

    public override string ToString() => $"[{From} - {To}]";
}