namespace AdventOfCode2022.Day10;

public class SignalProcessor
{
    private static int X = 1;
    private static int CurrentTick = 0;
    private static readonly List<Cycle> Cycles = new();

    public static List<Cycle> ProcessCommands(Queue<CPUCommand> commands)
    {
        while (commands.TryDequeue(out var command))
        {
            ProcessCommand(command);
        }

        return Cycles;
    }

    private static void ProcessCommand(CPUCommand command)
    {
        switch (command.Type)
        {
            case CommandType.Noop:
                ProcessNoop();
                break;
            case CommandType.AddX:
                ProcessAddX(command.Value);
                break;
        }
    }

    private static void ProcessNoop()
    {
        Tick();
        Cycles.Add(new Cycle { X = X, Tick = CurrentTick });
    }

    private static void ProcessAddX(int? argument)
    {
        for (int i = 0; i < 2; i++)
        {
            Tick();
            Cycles.Add(new Cycle { X = X, Tick = CurrentTick });
        }

        X += argument.GetValueOrDefault();
    }

    public static char[,] DrawCRTScreen(List<Cycle> cycles, int width, int height)
    {
        var screen = InitializeScreen(width, height);

        for (int i = 0; i < height; i++)
        {
            var line = cycles
                .Skip(i * width)
                .Take(width)
                .ToArray();

            for (int j = 0; j < width; j++)
            {
                var spriteIsVisible = line[j].X >= j - 1 && line[j].X <= j + 1;
                screen[i, j] = spriteIsVisible ? '#' : '.';
            }
        }

        return screen;
    }

    private static char[,] InitializeScreen(int width, int height)
    {
        var screen = new char[height, width];

        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                screen[i, j] = '.';
            }
        }

        return screen;
    }

    private static void Tick()
    {
        CurrentTick++;
    }
}
