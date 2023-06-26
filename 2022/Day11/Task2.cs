namespace AdventOfCode2022.Day11;

public class Task2 : IAdventOfCodeTask
{
    public void Solve(string[] input)
    {
        Console.WriteLine("Day 11, Task 2 solution:");

        var monkeys = InputParser.Parse(input, true);

        WatchMonkeysPlay(monkeys);

        var top2Monkeys = monkeys
            .OrderByDescending(m => m.Inspections)
            .Take(2)
            .ToArray();

        var result = top2Monkeys[0].Inspections * top2Monkeys[1].Inspections;

        Console.WriteLine($"The product of the top 2 monkey inspections is { result }");
    }

    private static void WatchMonkeysPlay(Queue<Monkey> monkeys)
    {
        for (int round = 0; round < 10_000; round++)
        {
            PlayRound(monkeys);
        }
    }

    private static void PlayRound(Queue<Monkey> monkeys)
    {
        foreach (var monkey in monkeys.ToList())
        {
            monkey.Play(monkeys, true);
            monkeys.Enqueue(monkeys.Dequeue());
        }
    }
}
