namespace AdventOfCode2022.Common;

public class MathHelper
{
    public static int GetGreatestCommonDivisor(int a, int b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    public static int GetLeastCommonMultiple(int[] values)
    {
        var res = values[0];
        for (int i = 1; i < values.Length; i++)
        {
            res = res * values[i] / GetGreatestCommonDivisor(res, values[i]);
        }

        return res;
    }
}
