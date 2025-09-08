using System.Globalization;

public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Create a return variable with an array the length of how many multiples you want
        double[] result = new double[length];
        // Create a for loop that loops as many times as you want multiples. 
        for (int i = 1; i <= length; ++i)
        {
            // Multiply original number by the incremental value and add it to your return variable. Assign result to index of current iteration.
            result[i-1] = number * i;
        }

        return result; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Create a for loop that iterates by the amount you want to rotate the list
        for (int i = 0; i < amount; ++i)
        {
            // Pop the last value in the list and store it as a variable
            int lastVal = data[data.Count-1];
            data.RemoveAt(data.Count-1);
            // Insert that variable at the start of the list at index 0
            data.Insert(0, lastVal);

        }
    }
}
