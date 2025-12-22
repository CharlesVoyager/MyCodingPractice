//622. Design Circular Queue

public class MyCircularQueue
{
    int[] Buffer;
    int Length = 0;
    int IndexFront = -1;
    int IndexBack = -1;
    public MyCircularQueue(int k)
    {
        Buffer = new int[k];
        Length = k;
    }

    public bool EnQueue(int value)
    {
        if (IsFull()) return false;

        if (IsEmpty())
        {
            IndexFront = 0;
            IndexBack = 0;
            Buffer[IndexBack] = value;
        }
        else
        {
            if (IndexBack == Length - 1)
                IndexBack = 0;
            else
                IndexBack++;

            Buffer[IndexBack] = value;
        }
        return true;
    }

    int Count()
    {
        if (IsEmpty()) return 0;
        return IndexBack - IndexFront + 1;
    }

    public bool DeQueue()
    {
        if (IsEmpty()) return false;

        if (Count() == 1)
        {
            IndexFront = -1;
            IndexBack = -1;
        }
        else
        {
            if (IndexFront == Length - 1)
                IndexFront = 0;
            else
                IndexFront++;
        }
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
        return Buffer[IndexBack];
    }

    public bool IsEmpty()
    {
        if (IndexFront == -1 && IndexBack == -1)
            return true;
        else
            return false;
    }

    public bool IsFull()
    {
        if ((IndexBack + 1) % Length == IndexFront)
            return true;
        else
            return false;
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
