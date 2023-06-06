namespace AdventOfCode2022.Day06
{
    public class Task1 : IAdventOfCodeTask
    {
        private const int MarkerLength = 4;

        public void Solve(string[] input)
        {
            var dataStream = InputParser.Parse(input);

            var startOfPacket = DataStreamHandler.FindStartOfMarker(dataStream, MarkerLength);

            Console.WriteLine($"Start of packet: { startOfPacket }");
        }
    }
}