using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add 5 items to queue, 2 with same priority, 1 with highest.  (Adam, 2; Brett, 3; Chad, 1; Drew, 4; Evan, 3). Run 5 times.
    // Expected Result: Drew, Brett, Evan, Adam, Chad. 
    // Defect(s) Found: Dequeue() never removes the PriorityItem after determining the highest Priority. Also, Dequeue never checked the last index. Once it reached the last of the queue
    // it would see that i was not < _queue.Count -1 (the length of the queue) and would move on. Changed to <=
    // Third problem: When dequeue found an index that matched priority of its currently saved high priority, it replaced the index. So it was taking that last in the Queue
    // with the highest priority, instead of the first. Changed it to > only, so that it only replaced highest priority if the priority is greater, not the same.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        var adam = new PriorityItem("Adam", 2);
        var brett = new PriorityItem("Brett", 3);
        var chad = new PriorityItem("Chad", 1);
        var drew = new PriorityItem("Drew", 4);
        var evan = new PriorityItem("Evan", 3);

        PriorityItem[] expectedResult = [drew, brett, evan, adam, chad];

        priorityQueue.Enqueue(adam.Value, adam.Priority);
        priorityQueue.Enqueue(brett.Value, brett.Priority);
        priorityQueue.Enqueue(chad.Value, chad.Priority);
        priorityQueue.Enqueue(drew.Value, drew.Priority);
        priorityQueue.Enqueue(evan.Value, evan.Priority);

        int i = 0;
        while (i < 5)
        {
            var removed = priorityQueue.Dequeue();
            Assert.AreEqual(expectedResult[i].Value, removed);
            ++i;
        }
    }

    [TestMethod]
    // Scenario: Ensure that an empty queue throws an exception when Dequeue is called.
    // Expected Result: An InvalidOperationException is thrown.
    // Defect(s) Found: none
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

    Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
    }

    // Add more test cases as needed below.
}