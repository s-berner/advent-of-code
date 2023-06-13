namespace AdventOfCode2022.Day10;

public class Task1 : IAdventOfCodeTask
{
    private int X = 1;
    private int currentTick = 1;
    private readonly List<XTick> Ticks = new() { new XTick { X = 1, Tick = 1 } };

    public void Solve(string[] input)
    {
        var commands = InputParser.Parse(input);

        while (commands.Count > 0)
        {
            HandleCommand(commands.Dequeue());
        }

        for (int i = 19; i < Ticks.Count; i += 40)
        {
            var signalStrength = Ticks[i].Tick * Ticks[i].X;

            Console.WriteLine($"X: { Ticks[i].X }, Tick: { Ticks[i].Tick } SignalStrength: { signalStrength }");
        }
    }

    private void HandleCommand(CPUCommand command)
    {
        switch (command.Type)
        {
            case CommandType.Noop:
                HandleNoop();
                break;
            case CommandType.AddX:
                HandleAddX(command.Value);
                break;
        }
    }

    private void HandleNoop()
    {
        Tick();
        Ticks.Add(new XTick { X = X, Tick = currentTick });
    }

    private void HandleAddX(int? argument)
    {
        for (int i = 0; i < 2; i++)
        {
            Tick();
            Ticks.Add(new XTick { X = X, Tick = currentTick });
        }

        X += argument ?? 0;
    }

    private void Tick()
    {
        currentTick++;
    }
}
