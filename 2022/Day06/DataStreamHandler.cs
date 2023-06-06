namespace AdventOfCode2022.Day06
{
    public class DataStreamHandler
    {
        public static int FindStartOfMarker(string dataStream, int MarkerLength)
        {
            for (int i = 0; i <= dataStream.Length - MarkerLength; i++)
            {
                var marker = dataStream.Substring(i, MarkerLength);


                if (HasValidMarker(marker, MarkerLength))
                {
                    return i + MarkerLength;
                }
            }

            return 0;
        }

        private static bool HasValidMarker(string marker, int MarkerLength)
        {
            return new HashSet<char>(marker).Count == MarkerLength;
        }
    }
}