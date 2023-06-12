namespace AdventOfCode2022.Day06
{
    public class Task2 : IAdventOfCodeTask
    {
        private const int MarkerLength = 14;

        public void Solve(string[] input)
        {
            Console.WriteLine("Day 06, Task 2 solution:");

            var dataStream = InputParser.Parse(input);

            var startOfPacket = DataStreamHandler.FindStartOfMarker(dataStream, MarkerLength);

            Console.WriteLine($"Start of packet: { startOfPacket }");
        }
    }
}