namespace AdventOfCode2022.Day04
{
    public class Task2 : IAdventOfCodeTask
    {
        public void Solve(string[] input)
        {
            Console.WriteLine("Day 04, Task 2 solution:");
            var segmentAssignments = InputParser.Parse(input);

            int intersectingSegmentSum = segmentAssignments.Count(x => CheckIfSegmentsIntersect(x));

            Console.WriteLine($"There are {intersectingSegmentSum} intersecting segments.");
        }

        private bool CheckIfSegmentsIntersect(List<(int, int)> segmentAssignment)
        {
            var (range1Start, range1End) = segmentAssignment[0];
            var (range2Start, range2End) = segmentAssignment[1];

            if (range1Start <= range2Start && range1End >= range2Start ||
                range1Start >= range2Start && range1Start <= range2End)
            {
                return true;
            }

            return false;
        }
    }
}