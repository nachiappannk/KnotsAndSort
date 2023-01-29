// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var game = new Game(12);
var player = new Player(game);

int[,] colors = new int[,]
{
    { Game.CYAN,        Game.DARKRED,   Game.GRAY,          Game.YELLOW },
    { Game.GREEN,        Game.ORANGE,      Game.MAGENTA,       Game.GREEN },
    { Game.YELLOW,        Game.ORANGE,      Game.MAGENTA,          Game.YELLOW},
    { Game.YELLOW, Game.DARKRED,    Game.CYAN,          Game.MAGENTA },
    { Game.CYAN,        Game.DARKRED,      Game.MAGENTA,       Game.DARKMAGENTA },
    { Game.BLUE, Game.DARKMAGENTA,    Game.CYAN,        Game.GREEN },


    { Game.DARKBLUE,        Game.BLUE,      Game.BLUE,        Game.DARKRED   },
    { Game.GRAY,      Game.BLUE,   Game.GREEN,        Game.DARKBLUE },
    { Game.DARKBLUE,      Game.DARKBLUE,   Game.GRAY,        Game.DARKMAGENTA },
    { Game.DARKMAGENTA,      Game.ORANGE,   Game.GRAY,        Game.ORANGE },

};

for (int i = 0; i < colors.GetLength(0); i++)
{
    for (int j = 3; j >= 0; j--)
    {
        game.Insert(i, colors[i, j]);
    }
}

player.Play();

var game1 = new Game(12);
for (int i = 0; i < colors.GetLength(0); i++)
{
    for (int j = 3; j >= 0; j--)
    {
        game1.Insert(i, colors[i, j]);
    }
}

game1.Display();
foreach (var operation in player.@operator.operations)
{
    //game1.Move(operation.Source, operation.Destination);
    //game1.Display();
    Console.WriteLine($"{operation.Source} \t {operation.Destination}");
}