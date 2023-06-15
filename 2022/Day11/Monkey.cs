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
    public long InspectedItems { get; set; } = 0;

    public Monkey(int id)
    {
        Id = id;
    }

    public void Play(Queue<Monkey> monkeys)
    {
        foreach (var item in Items)
        {
            InspectedItems++;

            var newItem = Operation(item);

            if (TestItem(newItem))
            {
                monkeys.First(m => m.Id == TestPassTargetId).Items.Add(newItem);
            }
            else
            {
                monkeys.First(m => m.Id == TestFailTargetId).Items.Add(newItem);
            }
        }

        Items.Clear();
    }

    private bool TestItem(long item)
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

    public void ParseOperationLine(string line)
    {
        var lineSplit = line
            .Replace("  Operation: new = ", "")
            .Split(' ');

        var @operator = GetOperator(lineSplit[1]);

        if (lineSplit.ElementAt(2) == "old")
        {
            Operation = GetOperationWithOld(@operator);
        }
        else
        {
            var value = int.Parse(lineSplit.ElementAt(2));
            Operation = GetOperationWithValue(@operator, value);
        }
    }

    private static MathOperators GetOperator(string @operator)
    {
        return @operator switch
        {
            "+" => MathOperators.Add,
            "-" => MathOperators.Subtract,
            "*" => MathOperators.Multiply,
            "/" => MathOperators.Divide,
            _ => throw new NotImplementedException(),
        };
    }

    private static Func<long, long> GetOperationWithOld(MathOperators @operator)
    {
        return (long old) => @operator switch
        {
            MathOperators.Add => (old + old) / 3,
            MathOperators.Subtract => (old - old) / 3,
            MathOperators.Multiply => old * old / 3,
            MathOperators.Divide => old / old / 3,
            _ => throw new NotImplementedException(),
        };
    }

    private static Func<long, long> GetOperationWithValue(MathOperators operand, int value)
    {
        return (long old) => operand switch
        {
            MathOperators.Add => (old + value) / 3,
            MathOperators.Subtract => (old - value) / 3,
            MathOperators.Multiply => old * value / 3,
            MathOperators.Divide => old / value / 3,
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
        }
        else
        {
            TestFailTargetId = targetId;
        }
    }
}