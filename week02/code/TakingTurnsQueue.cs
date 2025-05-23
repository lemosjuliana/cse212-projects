/// <summary>
/// This queue is circular.  When people are added via AddPerson, then they are added to the 
/// back of the queue (per FIFO rules).  When GetNextPerson is called, the next person
/// in the queue is saved to be returned and then they are placed back into the back of the queue.  Thus,
/// each person stays in the queue and is given turns.  When a person is added to the queue, 
/// a turns parameter is provided to identify how many turns they will be given.  If the turns is 0 or
/// less than they will stay in the queue forever.  If a person is out of turns then they will 
/// not be added back into the queue.
/// </summary>
public class TakingTurnsQueue
{   
    //Reduce the need for a lot of code:
    private readonly Queue<Person> _people = new Queue<Person>(); // Standard Queue

    public int Length => _people.Count; 


    /// <summary>
    /// Add new people to the queue with a name and number of turns
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="turns">Number of turns remaining</param>
     public void AddPerson(string name, int turns)
    {
        // Directly add the person to the queue (more direct)
        _people.Enqueue(new Person(name, turns));
    }

    /// <summary>
    /// Get the next person in the queue and return them. The person should
    /// go to the back of the queue again unless the turns variable shows that they 
    /// have no more turns left.  Note that a turns value of 0 or less means the 
    /// person has an infinite number of turns.  An error exception is thrown 
    /// if the queue is empty.
    /// </summary>

    public Person GetNextPerson() // Fixed turn expiration logic
    {
        // Check if the queue is empty
        // If it is, throw an exception
        if (_people.Count == 0)
            throw new InvalidOperationException("No one in the queue.");

        Person person = _people.Dequeue();

        // If turns > 1, decrement and add them again to the queue
        if (person.Turns > 1)
        {
            person.Turns -= 1;
            _people.Enqueue(person);
        }
        // If turns == 0 (or negative too), they have infinite turns => stay in the queue
        else if (person.Turns <= 0)
        {
            _people.Enqueue(person);
        }
        // Turns == 1, they are out of turns and don't come back to the queue
        return person;

    }
public override string ToString()
{
    return string.Join(", ", _people.Select(p => p.Name)); ///////////
}
}