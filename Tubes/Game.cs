// See https://aka.ms/new-console-template for more information

using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;

public class Game
{
    public const int RED = 0;
    public const int DARKBLUE = 1;
    public const int MAGENTA = 2;
    public const int BLUE = 3;
    public const int DARKMAGENTA = 4;
    public const int DARKGREEN = 5;
    public const int ORANGE = 6;
    public const int DARKRED = 7;
    public const int YELLOW = 8;
    public const int GRAY = 9;
    public const int GREEN = 10;
    public const int CYAN = 11;

    private Tube[] tubes;

    public Game(int numTubes)
    {
        tubes = new Tube[numTubes];
        for(int i = 0; i< tubes.Length; i++) 
        {
            tubes[i] = new Tube(4);
        }
    }

    public void Insert(int tubeNumber, int element)
    {
        if (tubes.Length <= tubeNumber) throw new Exception("Invalid operation");
        if (!tubes[tubeNumber].HasSpace()) throw new Exception("Invalid operation");
        tubes[tubeNumber].Push(element);
    }

    public int Move(int source, int destination)
    {
        if (!CanMove(source, destination)) throw new Exception();
        int number = 0;
        while (true)
        {
            if (!CanMove(source, destination)) break;
            int element = tubes[source].Pop();
            tubes[destination].Push(element);
            number++;
        }
        return number;
    }

    public void UnMove(int source, int destination, int size)
    {
        for (int i = 0; i < size; i++)
        {
            int element = tubes[source].Pop();
            tubes[destination].Push(element);
        }
    }

    private bool CanMove(int source, int destination)
    {
        if (tubes.Length <= source) throw new Exception("Invalid operation");
        if (tubes.Length <= destination) throw new Exception("Invalid operation");
        if (tubes[destination].IsEmpty() && tubes[source].IsSameColor()) return false;
        if (tubes[source].IsSolved()) return false;
        if (!tubes[source].CanPop()) return false;
        int top = tubes[source].Top();
        if (tubes[destination].CanPush(top)) return true;
        return false;
    }

    public List<Operation> GetPossibleOperations() 
    { 
        List<Operation> result = new List<Operation>();
        for(int i = 0; i < tubes.Length; i++) 
        {
            for (int j = 0; j < tubes.Length; j++)
            {
                if (i == j) continue;
                if (CanMove(i, j) == false) continue;
                result.Add(new Operation { Source = i, Destination = j });
            }
        }
        return result;
    }

    public bool IsGameCompleted()
    { 
        for(int i = 0; i < tubes.Length; i++) 
        {
            if (!tubes[i].IsSolved()) return false;
        }
        return true;
    }

    public void Display()
    {
        Console.Clear();
        for (int j = 3; j >= 0; j--)
        {
            for (int i = 0; i < tubes.Length/2; i++)
            {
                if (tubes[i].numberOfElements > j)
                {
                    var top = tubes[i].data[j];
                    ConsoleColor color = GetColor(top);
                    Console.BackgroundColor = color;
                    Console.Write("  ");
                    Console.ResetColor();
                    Console.Write("  ");
                }
                else {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("  ");
                    Console.ResetColor();
                    Console.Write("  ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine();

        for (int j = 3; j >= 0; j--)
        {
            for (int i = tubes.Length / 2; i < tubes.Length; i++)
            {
                if (tubes[i].numberOfElements > j)
                {
                    var top = tubes[i].data[j];
                    ConsoleColor color = GetColor(top);
                    Console.BackgroundColor = color;
                    Console.Write("  ");
                    Console.ResetColor();
                    Console.Write("  ");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("  ");
                    Console.ResetColor();
                    Console.Write("  ");
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Task.Delay(1000).Wait();

    }

    public BigInteger GetMyHash()
    { 
        BigInteger value = BigInteger.Zero;
        for(int i = 0; i < tubes.Length; i++) 
        { 
            for(int j=0; j < 4; j++)
            {
                int val;
                if (tubes[i].numberOfElements > j)
                {
                    val = tubes[i].data[j];
                }
                else 
                {
                    val = 15;
                }
                value = value * 16 + val;
            }
        }
        return value;
    }

    private static ConsoleColor GetColor(int top)
    {
        switch (top)
        {
            case Game.RED: return ConsoleColor.Red;
            case Game.DARKBLUE: return ConsoleColor.DarkBlue; 
            case Game.MAGENTA: return ConsoleColor.Magenta;
            case Game.BLUE: return ConsoleColor.Blue;
            case Game.DARKMAGENTA: return ConsoleColor.DarkMagenta;
            case Game.DARKGREEN: return ConsoleColor.DarkGreen;
            case Game.ORANGE: return ConsoleColor.DarkYellow;
            case Game.DARKRED: return ConsoleColor.DarkRed;
            case Game.YELLOW: return ConsoleColor.Yellow;
            case Game.GRAY: return ConsoleColor.DarkGray;
            case Game.GREEN: return ConsoleColor.Green;
            case Game.CYAN: return ConsoleColor.Cyan;
        }
        throw new Exception();
    }
}
