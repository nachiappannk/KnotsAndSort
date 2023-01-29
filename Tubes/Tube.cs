// See https://aka.ms/new-console-template for more information
public class Tube
{
    private readonly int capacity;
    public int numberOfElements = 0;
    public int[] data;

    public Tube(int capacity)
    {
        this.capacity = capacity;
        data = new int[capacity];
    }

    public bool CanPush(int x)
    {
        if (numberOfElements == 0) return true;
        if (capacity == numberOfElements) return false;
        if(Top() == x)return true;
        return false;
    }

    public bool CanPop()
    {
        if(numberOfElements == 0) return false;
        return true;
    }

    public bool IsSolved()
    {
        if (numberOfElements == 0) return true;
        if (capacity != numberOfElements) return false;
        for(int i = 0; i < numberOfElements; i++) 
        {
            if (data[0] != data[i]) return false;
        }
        return true;
    }

    internal bool HasSpace()
    {
        if (capacity > numberOfElements) return true;
        return false;
    }

    internal void Push(int element)
    {
        data[numberOfElements] = element;
        numberOfElements++;
    }

    internal int Top()
    {
        return data[numberOfElements - 1];
    }

    internal int Pop()
    {
        numberOfElements--;
        return data[numberOfElements];
    }

    internal bool IsEmpty()
    {
        if (numberOfElements == 0) return true;
        return false;
    }

    internal bool IsSameColor()
    {
        if(numberOfElements == 0) return true;
        for(int i = 0; i< numberOfElements; i++) 
        {
            if (data[0] != data[i]) return false;    
        }
        return true;
    }
}
