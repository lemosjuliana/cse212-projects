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

        // Plan:
        
        // 1. Make sure the sequence has 'length' number of elements.
        // 2. Make sure the sequence starts with the number 'number'.
        // 3. Make sure the sequence is multiples of 'number'.
        // 4. Return the array.

        // Detailing the plan:

        // 1. Create an array of doubles called multiples with the size of 'length'
        // to make sure we have the correct number of elements inside the array.

            double[] multiples = new double[length];
        
            // 2. Use a for loop to generate the multiples. The loops starts at i = 0
            // and goes until i < length. We can use i++ to make sure the loop
            // increments by 1 each time.

            for (int i = 0; i < length; i++)
            {
                // 3. Inside the loop, we ensure each value is a multiple of 'number.
                // We can calculate the multiple by multiplying
                // the number by (i + 1) and assign it to multiples[i].
                multiples[i] = number * (i + 1);
            }
            
            // 4. Now, we return the multiples array.
            return multiples;
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
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
        
        // Plan:
        // 1. Use the modulo operator (%) to reposition the elements in the list.
        // 2. Create a new temporary list to store the rotated elements.    
        // 3. Calculate the new positions (indices) for each element in the original list and populate the temporary list.
        // 4. Copy the rotated elements back to the original list.

        // Detailing the plan:

        // Step 1: The goal is to shift each elemnt to the right by 'amount' positions.
        // In this part of the code, we can handle cases where the  amount is 0 or equal to the size of the list.
        // If the amount is 0 the lists stays the same, so there is no need to process.
        // If the amount is equal to the size of the list, every elemnt moves back to the original position, so the list also stays the same.
        int n = data.Count;
        if (amount == 0 || amount == n) return; 

        // Step 2: Create a temporary list to store rotated elements to avoid overwriting the original list. 
        // In this case, we can use new List<int>(new int[data.Count]) to create fixed size list.
        // This will create a new list with the same size as the original list, but it will be empty.
        // I am pretty sure we have a better way to do this, but we can use this for now
        List<int> rotated = new List<int>(new int[data.Count]); 

        // Step 3: Calculate new indices and populate the temporary list.
        // We can create a for loop that loops through the original list.
        // To determine new positions, we stablish that the new index is equal to (i + amount) % n.
        // (i + amount) shifts the index by 'amount' positions
        //  % n ensures that valuess wrap around if the index exceeds the size of the list.
        // Then, we just need to assign value to the new position,.
        for (int i = 0; i < n; i++)
        {
            int newIndex = (i + amount) % n; // Calculate the new index
            rotated[newIndex] = data[i];   // Assign the value to the new position.
        }

        // almost there..

        // Step 4: Copy the rotated elements back to the original list.
        // We can use another for loop to iterate through the temporary list and copy the values back to the original list.
        // we ca use data[i] = rotated[i] to overwrite the original list with the rotated values.
        // I believe it is possible to reach the result wothiut this extra loop, but this is a ok way to do it..
        for (int i = 0; i < n; i++)
        {
            data[i] = rotated[i];
        }
    }
}