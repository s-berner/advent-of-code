namespace AdventOfCode2022.Day11;

public class Task1 : IAdventOfCodeTask
{
    public void Solve(string[] input)
    {
        Console.WriteLine("Day 11, Task 1 solution:");

        var monkeys = InputParser.Parse(input);

        WatchMonkeysPlay(monkeys);

        var top2Monkeys = monkeys
            .OrderByDescending(m => m.InspectedItems)
            .Take(2)
            .ToArray();

        var result = top2Monkeys[0].InspectedItems * top2Monkeys[1].InspectedItems;

        Console.WriteLine($"The product of the top 2 monkey item inspections is { result }");
    }

    private static void WatchMonkeysPlay(Queue<Monkey> monkeys)
    {
        for (int round = 0; round < 20; round++)
        {
            foreach (var monkey in monkeys.ToList())
            {
                monkey.Play(monkeys);
                monkeys.Enqueue(monkeys.Dequeue());
            }
        }
    }
}
