// See https://aka.ms/new-console-template for more information
public class Cell
{
	public Cell(int x, int y)
	{
        IsHead = false;
        Value = -1;
        X = x;
        Y = y;
    }

	public bool IsHead { get; set; }

	public int Value { get; set; }
    public int X { get; }
    public int Y { get; }

    public bool IsSet()
    {
        if (Value == -1) return false;
        return true;
    }
}

public class Point
{ 
    public int X { get; set; }
    public int Y { get; set; }
}
