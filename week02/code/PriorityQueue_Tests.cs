using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario:
    // Enqueue several items with different priorities and dequeue once.
    //
    // Expected Result:
    // The item with the highest priority value should be removed and returned,
    // regardless of the order in which items were enqueued.
    //
    // Defect(s) Found:
    // This test will fail if Dequeue removes the front item instead of the
    // highest-priority item.
    public void Dequeue_RemovesHighestPriorityItem()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("medium", 5);
        priorityQueue.Enqueue("high", 10);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("high", result);
    }

    [TestMethod]
    // Scenario:
    // Enqueue multiple items with the same highest priority.
    //
    // Expected Result:
    // When priorities are equal, the item that was enqueued first
    // (FIFO order) should be removed first.
    //
    // Defect(s) Found:
    // This test will fail if FIFO order is not preserved for items
    // with equal priority.
    public void Dequeue_SamePriority_UsesFIFOOrder()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("first", 10);
        priorityQueue.Enqueue("second", 10);
        priorityQueue.Enqueue("third", 5);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("first", result);
    }

    [TestMethod]
    // Scenario:
    // Enqueue items and ensure they are added to the back of the queue.
    //
    // Expected Result:
    // If all items have the same priority, they should be dequeued
    // in the exact order they were enqueued.
    //
    // Defect(s) Found:
    // This test will fail if Enqueue does not place items at the back
    // of the queue.
    public void Enqueue_AddsItemsToBackOfQueue()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("A", 3);
        priorityQueue.Enqueue("B", 3);
        priorityQueue.Enqueue("C", 3);

        Assert.AreEqual("A", priorityQueue.Dequeue());
        Assert.AreEqual("B", priorityQueue.Dequeue());
        Assert.AreEqual("C", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario:
    // Attempt to dequeue from an empty queue.
    //
    // Expected Result:
    // An InvalidOperationException should be thrown with the exact
    // message: "The queue is empty."
    //
    // Defect(s) Found:
    // This test will fail if:
    // - No exception is thrown
    // - The wrong exception type is thrown
    // - The exception message does not match exactly
    public void Dequeue_EmptyQueue_ThrowsException()
    {
        var priorityQueue = new PriorityQueue();

        var exception = Assert.ThrowsException<InvalidOperationException>(
            () => priorityQueue.Dequeue());

        Assert.AreEqual("The queue is empty.", exception.Message);
    }

    [TestMethod]
    // Scenario:
    // Dequeue multiple times and ensure the next highest priority
    // item is always selected.
    //
    // Expected Result:
    // Items should be removed in descending priority order, using
    // FIFO order when priorities match.
    //
    // Defect(s) Found:
    // This test will fail if priorities are not re-evaluated after
    // each dequeue operation.
    public void Dequeue_MultipleOperations_MaintainsCorrectOrder()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("low", 1);
        priorityQueue.Enqueue("high1", 10);
        priorityQueue.Enqueue("medium", 5);
        priorityQueue.Enqueue("high2", 10);

        Assert.AreEqual("high1", priorityQueue.Dequeue());
        Assert.AreEqual("high2", priorityQueue.Dequeue());
        Assert.AreEqual("medium", priorityQueue.Dequeue());
        Assert.AreEqual("low", priorityQueue.Dequeue());
    }
}
