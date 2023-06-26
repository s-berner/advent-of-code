using AdventOfCode2022.Common;

namespace AdventOfCode2022.Day11;

public class Monkey
{
    public int Id { get; set; }
    public List<long> Items { get; set; } = new();
    public Func<long, long> Operation { get; set; } = null!;
    public int TestDevisableBy { get; set; } = 0;
    public int TestPassTargetId { get; set; } = 0;
    public int TestFailTargetId { get; set; } = 0;
    public long Inspections { get; set; } = 0;

    public Monkey(int id)
    {
        Id = id;
    }

    public void Play(Queue<Monkey> monkeys, bool task2 = false)
    {
        int modulus = 0;
        if (task2)
        {
            var monkeyDevisableBys = monkeys
                .Select(m => m.TestDevisableBy)
                .ToArray();

            modulus = MathHelper.GetLeastCommonMultiple(monkeyDevisableBys);
        }

        foreach (var item in Items)
        {
            Inspections++;

            var newItem = modulus == 0
                ? Operation(item)
                : Operation(item) % modulus;

            var targetMonkeyId = DecideWhatToDoWithItem(newItem)
                ? TestPassTargetId
                : TestFailTargetId;

            var targetMonkey = monkeys.First(m => m.Id == targetMonkeyId);

            targetMonkey.Items.Add(newItem);
        }

        Items.Clear();
    }

    private bool DecideWhatToDoWithItem(long item)
    {
        return item % TestDevisableBy == 0;
    }

    public void ParseItemLine(string line)
    {
        var items = line
            .Replace("  Starting items: ", "")
            .Split(", ")
            .Select(long.Parse);

        Items.AddRange(items);
    }

    public void ParseOperationLine(string line, bool task2 = false)
    {
        var lineSplit = line
            .Replace("  Operation: new = ", "")
            .Split(' ');

        var op = GetOperator(lineSplit[1]);

        if (lineSplit.ElementAt(2) == "old")
        {
            Operation = GetOperationWithOld(op, task2);
            return;
        }

        var value = int.Parse(lineSplit.ElementAt(2));
        Operation = GetOperationWithVal(op, value, task2);
    }

    private static MathOperators GetOperator(string op)
    {
        return op switch
        {
            "+" => MathOperators.Add,
            "-" => MathOperators.Subtract,
            "*" => MathOperators.Multiply,
            "/" => MathOperators.Divide,
            _ => throw new NotImplementedException(),
        };
    }

    private static Func<long, long> GetOperationWithOld(
        MathOperators op,
        bool task2 = false)
    {
        int divider = task2 ? 1 : 3;

        return (long old) => op switch
        {
            MathOperators.Add => (old + old) / divider,
            MathOperators.Subtract => (old - old) / divider,
            MathOperators.Multiply => old * old / divider,
            MathOperators.Divide => old / old / divider,
            _ => throw new NotImplementedException(),
        };
    }

    private static Func<long, long> GetOperationWithVal(
        MathOperators op,
        int value,
        bool task2 = false)
    {
        int divider = task2 ? 1 : 3;

        return (long old) => op switch
        {
            MathOperators.Add => (old + value) / divider,
            MathOperators.Subtract => (old - value) / divider,
            MathOperators.Multiply => old * value / divider,
            MathOperators.Divide => old / value / divider,
            _ => throw new NotImplementedException(),
        };
    }

    public void ParseTestLine(string line)
    {
        TestDevisableBy = int.Parse(line.Replace("  Test: divisible by ", ""));
    }

    public void ParseIfLine(string line)
    {
        var targetId = int.Parse(line.Replace("    If ", "").Split(' ').Last());

        if (line.Contains("true"))
        {
            TestPassTargetId = targetId;
            return;
        }

        TestFailTargetId = targetId;
    }
}