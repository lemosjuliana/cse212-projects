public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1

        // Update the Insert function of the Node class to
        // only allow unique values to be added to the tree
        // (thus creating a sorted set). 
        // The Insert function is already written to correctly
        // insert values into the tree. However, the current
        // implementation will cause duplicate values to be a
        // dded to the tree.

        // what I have to do is basically add a condition that checks 
        // if the value already exists or not

        if (value == Data)
        {
            return;
        }

        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insert to the right
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        // TODO Start Problem 2
        // Implement the Contains function in the Node class. 
        // This function is called by the Contains function 
        // in the BinarySearchTree to search for a value in the tree.
        // If the value is found, true should be returned;
        // otherwise return false. 
        // Hint: study the Insert function.
        // You will need to use recursion to solve this problem.

        // If we need to use recursion, let's start with the base case 
        // and the small problem.

        // Base case: If the current node contains the value, return true.
        // Also, if  the current node is null, return false.

        // Small problem: Search one side of the tree.

        //  The keyword "this" to refer to
        // the current instance of the Node class
        if (this == null) // Base case. (if  the current node is null, return false.))
        {
            return false;
        }

        if (value == Data) // Base case. (If the current node contains the value, return true).
        {
            return true;
        }
        if (value < Data) // recursion
        {
            // Calls Contains(value) on the left child, if it exists.
             return Left?.Contains(value) ?? false;
        }
        else
        {
            // Does the same thing, but on the right child.
            return Right?.Contains(value) ?? false; 
        }
        
    }


    public int GetHeight()
    {
        // TODO Start Problem 4

        // this is also a recursive problem
        // Base case: If the current node is null, the height is 0.

        // Small problem: Get the height of each side of the tree.

        if (this == null) // Base case. (If the current node is null, the height is 0. )
        {
            return 0; // Replace this line with the correct return statement(s)
        }

        int leftHeight = Left?.GetHeight() ?? 0; // get the height of the left subtree recursively
        int rightHeight = Right?.GetHeight() ?? 0; // does the same on the right subtree

        return 1 + Math.Max(leftHeight, rightHeight); // take the max and add 1 for the current node..
         
       
    }
}