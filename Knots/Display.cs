// See https://aka.ms/new-console-template for more information



public class Display
{
    public void Show(Board board)
    {
        Console.Clear();
        for (int j = board.Y - 1; j >= 0; j--)
        {
            for (int i = 0; i < board.X; i++)
            {
                var value = board.IsSet(i, j) ? board.GetValue(i, j) : -1;
                var color = GetColor(value);
                Console.BackgroundColor = color;
                if (board.IsHead(i, j))
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(" ");
                }
                Console.ResetColor();
            }
            Console.WriteLine();
        }
        Task.Delay(1000).Wait();
    }

    public ConsoleColor GetColor(int value) { 
        switch(value) 
        {
            case -1: return ConsoleColor.Black;
            case 0: return ConsoleColor.Red;
            case 1: return ConsoleColor.Magenta;
            case 2: return ConsoleColor.Green;
            case 3: return ConsoleColor.Yellow;
            case 4: return ConsoleColor.Blue;
        }
        throw new NotImplementedException();
    }
}

