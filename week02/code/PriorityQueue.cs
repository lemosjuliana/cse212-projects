public class PriorityQueue
{
    // FIFO order while selecting based on priority..
    private Queue<Person> _queue = new();

    /// <summary>
    /// Adds a new person to the queue with a specific number of turns.
    /// The person is added to the back of the queue.
    /// </summary>
    /// <param name="name">The person's name</param>
    /// <param name="turns">The number of turns they have before removal</param>
    public void Enqueue(string name, int turns)
    {
        _queue.Enqueue(new Person(name, turns)); 
    }

    /// <summary>
    /// Removes and returns the person with the highest turns in the queue.
    /// If multiple people have the same highest turns, the first-added one is removed first.
    /// </summary>
    /// <returns>Name of the person leaving the queu</returns>
    /// <exception cref="InvalidOperationException">Thrown if the queue is empty</exception>
    public string Dequeue()
    {
        // Prevents an empty queue from being dequeued and throws an exceptio
        if (_queue.Count == 0)
            throw new InvalidOperationException("The queue is empty.");

        int count = _queue.Count;
        Person toReturn = null;

        // Iterates through the queue to find the person with the highest turns
        for (int i = 0; i < count; i++)
        {
            var person = _queue.Dequeue();

            // Selects the first match with the highest turns. Preserves FIFO order
            if (toReturn == null || person.Turns > toReturn.Turns)
            {
                if (toReturn != null)
                    // Keeps previous items in order
                    _queue.Enqueue(toReturn); 

                toReturn = person;
            }
            else
            {
                // re-adds people with lower turns back to the queue
                _queue.Enqueue(person); 
            }
        }

        // Handles infinite-turn logic correctly: If Turns <= 0, always re-enqueues the person
        if (toReturn.Turns <= 0)
        {
            // never removes people with infinite turns
            _queue.Enqueue(toReturn); 
        }
        else
        {
            toReturn.Turns--; // =>Decreases turns for regular participants
            if (toReturn.Turns > 0)
                _queue.Enqueue(toReturn); // =>Re-enqueues only if they still have turns left...
        }

        return toReturn.Name;
    }

    /// <summary>
    /// Checks if the queue is empty or not.
    /// </summary>
    /// <returns>True if the queue has no people, false if contrary</returns>
    public bool IsEmpty()
    {
        return _queue.Count == 0;
    }

    public override string ToString()
    {
        return string.Join(", ", _queue.Select(p => p.ToString())); 
    }
}