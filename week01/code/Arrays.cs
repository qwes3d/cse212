using System;
using System.Collections.Generic;

public class Arrays
{
    // Part 1: MultiplesOf
    public static double[] MultiplesOf(double start, int count)
    {
        /*
         PLAN:
         1. Create a new array of type double with a size equal to 'count'.
         2. Use a loop that runs 'count' times.
         3. For each index i:
            - Calculate the multiple by multiplying 'start' by (i + 1).
            - Store the result in the array at index i.
         4. After the loop finishes,then return the array.
        */

        double[] multiples = new double[count];

        for (int i = 0; i < count; i++)
        {
            multiples[i] = start * (i + 1);
        }

        return multiples;
    }

    // Part 2: RotateListRight
    public static void RotateListRight(List<int> data, int amount)
    {
        /*
         PLAN:
         1. The main goal is to rotate the list to the right by 'amount given'.
         2. Rotating right means taking the last 'amount' elements
            and moving them to the front of the list.
         3. Calculate the index where the split happens:
            splitIndex = data.Count - amount
         4. Use GetRange to:
            - Get the right portion (elements to move to the front)
            - Get the left portion (remaining elements)
         5. Clear the original list.
         6. Add the right portion first.
         7. Add the left portion after.
        */

        int splitIndex = data.Count - amount;

        List<int> rightPart = data.GetRange(splitIndex, amount);
        List<int> leftPart = data.GetRange(0, splitIndex);

        data.Clear();
        data.AddRange(rightPart);
        data.AddRange(leftPart);
    }
}
