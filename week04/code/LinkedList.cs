using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        // Create new node
        Node newNode = new(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            newNode.Next = _head; // Connect new node to the previous head
            _head.Prev = newNode; // Connect the previous head to the new node
            _head = newNode; // Update the head to point to the new node
        }
    }

    /// <summary>
    /// Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        // TODO Problem 1
        // Create a new node with the given value.
        Node newNode = new(value);
        // if _tail is null, then the list is empty.
        // we need to set both _head and _tail to the new node.
        if (_tail is null)
        {
            _head = newNode; // set head to the new node
            _tail = newNode; // set tail to the new node
        }
        // if _tail is not null, then the list is not empty.
        // we need to set the new node's previous to the current tail,
        // and then set the current tail's next to the new node.
        // we need to update the tail to point to the new node...
        else
        {
            newNode.Prev = _tail;
            _tail.Next = newNode; 
            _tail = newNode; 
        }

        
    }


    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        // If the list has only one item in it, then set head and tail 
        // to null resulting in an empty list.  This condition will also
        // cover an empty list.  Its okay to set to null again.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list has more than one item in it, then only the head
        // will be affected.
        else if (_head is not null)
        {
            _head.Next!.Prev = null; // Disconnect the second node from the first node
            _head = _head.Next; // Update the head to point to the second node
        }
    }


    /// <summary>
    /// Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // TODO Problem 2
        // This function is similar to RemoveHead, but we will be removing the tail:

        // If the list contains only one node, them
        // we set both head and tail to null..
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        // If the list contains more than one node..
        else if (_tail is not null)
        {
            _tail.Prev!.Next = null; // Disconnect the last node from the second to last node
            _tail = _tail.Prev; // Update the tail to point to the second to last node
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        // Search for the node that matches 'value' by starting at the 
        // head of the list.
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the location of 'value' is at the end of the list,
                // then we can call insert_tail to add 'new_value'
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                // For any other location of 'value', need to create a 
                // new node and reconnect the links to insert.
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; // Connect new node to the node containing 'value'
                    newNode.Next = curr.Next; // Connect new node to the node after 'value'
                    curr.Next!.Prev = newNode; // Connect node after 'value' to the new node
                    curr.Next = newNode; // Connect the node containing 'value' to the new node
                }

                return; // We can exit the function after we insert
            }

            curr = curr.Next; // Go to the next node to search for 'value'
        }
    }

    /// <summary>
    /// Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        // TODO Problem 3
        // "Set the prev of the node after current to the node before current (current.Next.Prev = current.Prev)
        // Set the next of the node before current to the node after current (current.Prev.Next = current.Next)"
        Node? curr = _head; // head of the list
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // If the node to remove is the head, then we need to call RemoveHead
                if (curr == _head)
                {
                    RemoveHead();
                }
                // If the node to remove is the tail, then we need to call RemoveTail
                else if (curr == _tail)
                {
                    RemoveTail();
                }
                // reconnect the sorrounding nodes to bypass the current node.
                else
                {
                    curr.Prev!.Next = curr.Next; // Connect the previous node to the next node
                    curr.Next!.Prev = curr.Prev; // Connect the next node to the previous node
                }

                return; // We can exit the function after we remove  the node
            }

            curr = curr.Next; // Go to the next node in order tp search for 'value'
        }
    }

    /// <summary>
    /// Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        // TODO Problem 4
        // "The function should search for all nodes that are equal to oldValue 
        // and then replace the value in those nodes with newValue. 
        // Unlike the remove function, this function should continue 
        // searching through the list to replace all values that match oldValue."
        Node? curr = _head; // head of the list
        while (curr is not null)
        {
            // If the current node's data matches oldValue, then we update it to newValue...
            if (curr.Data == oldValue)
            {
                curr.Data = newValue; // Replace the value in the current node
            }

            curr = curr.Next; // Go to the next node to continue searching. Different from Remove, we keep searching.
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; // Start at the beginning since this is a forward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // Provide (yield) each item to the user
            curr = curr.Next; // Go forward in the linked list
        }
    }

    /// <summary>
    /// Iterate backward through the Linked List
    /// </summary>
    public IEnumerable Reverse()
    {
        // TODO Problem 5
        // Very similar to the previous one
        var curr = _tail; // Start at the end since this is a backward iteration.
        while (curr is not null)
        {
            yield return curr.Data; // yield the current node's data
            curr = curr.Prev; // move to the previous node.
        }

    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    // Just for testing.
    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    // Just for testing.
    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}