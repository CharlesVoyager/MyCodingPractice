//622. Design Circular Queue

public class MyCircularQueue
{
    int[] Buffer;
    int Capacity = 0;
    int IndexFront = 0;
    int IndexRear = -1;
    int Count = 0;
    public MyCircularQueue(int k)
    {
        Buffer = new int[k];
        Capacity = k;
    }

    public bool EnQueue(int value)
    {
        if (IsFull()) return false;

        IndexRear = (IndexRear + 1) % Capacity;
        Buffer[IndexRear] = value;

        Count++;
        return true;
    }

    public bool DeQueue()
    {
        if (IsEmpty()) return false;
        IndexFront = (IndexFront + 1) % Capacity;
        Count--;
        return true;
    }

    public int Front()
    {
        if (IsEmpty()) return -1;
        return Buffer[IndexFront];
    }

    public int Rear()
    {
        if (IsEmpty()) return -1;
        return Buffer[IndexRear];
    }

    public bool IsEmpty()
    {
        return Count == 0;
    }

    public bool IsFull()
    {
        return Count == Capacity;
    }
}


class Program
{
    public static void Main()
    {
        bool result;
        int returnValue;

#if false // Test Case 1
        MyCircularQueue myCircularQueue = new MyCircularQueue(3);
        result = myCircularQueue.EnQueue(1);    // return True
        result = myCircularQueue.EnQueue(2);    // return True
        result = myCircularQueue.EnQueue(3);    // return True
        result = myCircularQueue.EnQueue(4);    // return False
        returnValue = myCircularQueue.Rear();   // return 3
        result = myCircularQueue.IsFull();      // return True
        result = myCircularQueue.DeQueue();     // return True
        result = myCircularQueue.EnQueue(4);    // return True
        returnValue = myCircularQueue.Rear();   // return 4
#endif

#if false // Test Case 2
        // Input
        //      ["MyCircularQueue","enQueue","Rear","Rear","deQueue","enQueue","Rear","deQueue","Front","deQueue","deQueue","deQueue"]
        //      [[6],[6],[],[],[],[5],[],[],[],[],[],[]]

        // Expected
        //      [null,true,6,6,true,true,5,true,-1,false,false,false]
        MyCircularQueue myCircularQueue = new MyCircularQueue(6);
        result = myCircularQueue.EnQueue(6);    // return True
        returnValue = myCircularQueue.Rear();   // return 6
        returnValue = myCircularQueue.Rear();   // return 6
        result = myCircularQueue.DeQueue();     // return True
        result = myCircularQueue.EnQueue(5);    // return True
        returnValue = myCircularQueue.Rear();   // return 5
        result = myCircularQueue.DeQueue();     // return True
        returnValue = myCircularQueue.Front();  // return -1
        result = myCircularQueue.DeQueue();     // return false
        result = myCircularQueue.DeQueue();     // return false
        result = myCircularQueue.DeQueue();     // return false
#endif

#if true // Test Case 3
        // Input
        // ["MyCircularQueue","enQueue","Front","isFull","enQueue","enQueue","enQueue","deQueue","enQueue","enQueue","isEmpty","Rear"]

        // [[4],[3],[],[],[7],[2],[5],[],[4],[2],[],[]]

        // Expected
        //     [null,true,3,false,true,true,true,true,true,false,false,4]
        MyCircularQueue myCircularQueue = new MyCircularQueue(4);
        result = myCircularQueue.EnQueue(3);    // return True
        returnValue = myCircularQueue.Front();   // return 3
        result = myCircularQueue.IsFull();       // return false
        result = myCircularQueue.EnQueue(7);     // return True
        result = myCircularQueue.EnQueue(2);    // return True
        result = myCircularQueue.EnQueue(5);    // return True
        result = myCircularQueue.DeQueue();     // return True
        result = myCircularQueue.EnQueue(4);    // return True
        result = myCircularQueue.EnQueue(2);    // return false
        result = myCircularQueue.IsEmpty();     // return false
        returnValue = myCircularQueue.Rear();   // return 4
#endif

    }
}
