using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: ("LowPriorityPerson", 1), ("HighPriority", 5), and ("MediumPriorityPerson", 3) are added to the queue. Dequeue() is called to remove items one by one.
    // Expected Result: The highest priority person is removed first, followed by medium, and finally low.
    // Defect(s) Found: None :)
    public void TestEnqueueAndDequeue()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("LowPriorityPerson", 1);
        priorityQueue.Enqueue("HighPriorityPerson", 5);
        priorityQueue.Enqueue("MediumPriorityPerson", 3);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("HighPriorityPerson", result, "Highest priority person should be removed first.");
    }

    [TestMethod]
    // Scenario: People with the same priority are added to the queue. The order of removal should be FIFO.
    // Expected Result: the first person added with the same priority should be removed first.
    // Defect(s) Found:  Items with the same priority are not dequeued in FIFO orde
    public void TestPriorityRemoval()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("FirstHighPriorityPerson", 5);
        priorityQueue.Enqueue("SecondHighPriorityPerson", 5);
        priorityQueue.Enqueue("ThirdHighPriorityPerson", 5);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("FirstHighPriorityPerson", result, "First added high-priority person should leave the queue first.");
    }

    // Add more test cases as needed below.
    [TestMethod] 
    // Scenario: the queue is empty and Dequeue() is called.
    // Expected Result: calling Dequeue() on an empty queue throws an exception (InvalidOperationException)
    // Defect(s) Found: Queue does not empty at the correct time; people are not removed when their turns run out. 
   
    public void TestEmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        Assert.ThrowsException<InvalidOperationException>(() =>
        {
            priorityQueue.Dequeue();
        }, "Dequeue on an empty queue should throw an exception.");
    }

    [TestMethod]
    // Scenario:  A person with Turns ≤ 0 is added, and Dequeue() is called multiple times.
    // Expected Result: People with Turns <= 0 stay in the queue forever, instead of being removed.
    // Defect(s) Found: 
    public void TestInfiniteTurns()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("AlwaysHere", 0);

        for (int i = 0; i < 5; i++)
        {
            var result = priorityQueue.Dequeue();
            Assert.AreEqual("AlwaysHere", result, "People with infinite turns should remain in the queue.");
            priorityQueue.Enqueue(result, 0); // Ensuring re-enqueue
        }
    }

[TestMethod]
    // Scenario: People with different turn values are added to the queue, and Dequeue() is called until all turns run out.
    // Expected Result: When all turns run out, the queue empties at the correct time.
    // Defect(s) Found: 
public void TestFinalQueueState()
{
    var priorityQueue = new PriorityQueue();

    priorityQueue.Enqueue("Juliana", 2);
    priorityQueue.Enqueue("Brandon", 1);
    priorityQueue.Enqueue("Joe", 3);

    priorityQueue.Dequeue(); // Brandon removed (only had 1 turn)
    priorityQueue.Dequeue(); // Juliana's turn decreases to 1
    priorityQueue.Dequeue(); // Joe's turn decreases to 2
    priorityQueue.Dequeue(); // Juliana removed
    priorityQueue.Dequeue(); // Joe's turn decreases to 1
    priorityQueue.Dequeue(); // Joe removed

    Assert.ThrowsException<InvalidOperationException>(() =>
    {
        priorityQueue.Dequeue();
    }, "Queue should be empty after all turns are used.");
}

}