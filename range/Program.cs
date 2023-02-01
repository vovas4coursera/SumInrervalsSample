struct Interval
{
    public int from;
    public int to;
}

class Program
{
    public static void Main() 
    {
        List<string> generatedIntervals = new List<string>();

        var sdf = Enumerable.Range(7, 9);
        List<Interval> intervals = new List<Interval>()
        {
            new Interval() { from = 1, to = 4},
            new Interval() { from = 7, to = 10},
            new Interval() { from = 3, to = 5},
        };
        
        foreach(Interval item in intervals)
        {
            List<string> simpleIntervals = new List<string>();
            for (int i = item.from; i < item.to; i++)
            {
                simpleIntervals.Add(i.ToString() + (i + 1).ToString());
            }
            //var simpleIntervals = Enumerable.Range(item.from, item.to - item.from).Select(i => i.ToString() + (i + 1).ToString()).ToList();
            generatedIntervals.AddRange(simpleIntervals);
        }

            
        int count = generatedIntervals.Distinct().Count();
Console.WriteLine("Hello, World!");

Console.ReadLine();
    }
}

