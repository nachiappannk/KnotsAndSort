// See https://aka.ms/new-console-template for more information
using System.Numerics;

public class Player
{
    private readonly Game game;
    public readonly Operator @operator;
    private HashSet<BigInteger> set = new HashSet<BigInteger>();

    public Player(Game game)
    {
        this.game = game;
        this.@operator = new Operator(game);
    }

    public bool Play()
    {
        var myHash = game.GetMyHash();
        if (set.Contains(myHash))
        {
            return false;
        } 
        set.Add(myHash);
        var operations = game.GetPossibleOperations();
        foreach (var operation in operations) 
        {
            @operator.Operate(operation);
            if (game.IsGameCompleted()) return true;
            if (Play()) return true;
            @operator.Undo();

        }
        return false;
    }
}
