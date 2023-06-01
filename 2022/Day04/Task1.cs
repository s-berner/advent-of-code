namespace AdventOfCode2022.Day04
{
    public class Task1 : IAdventOfCodeTask
    {
        public void Solve(string[] input)
        {
            Console.WriteLine("Day 04, Task 1 solution:");
            var segmentAssignments = InputParser.Parse(input);

            int nestedSegmentSum = segmentAssignments.Count(x => CheckIfSegmentsAreNested(x));

            Console.WriteLine($"There are {nestedSegmentSum} nested segments.");
        }

        private bool CheckIfSegmentsAreNested(List<(int, int)> segmentAssignment)
        {
            var range1 = segmentAssignment[0];
            var range2 = segmentAssignment[1];

            if (range1.Item1 <= range2.Item1 && range1.Item2 >= range2.Item2 ||
                range1.Item1 >= range2.Item1 && range1.Item2 <= range2.Item2)
            {
                return true;
            }

            return false;
        }
    }
}