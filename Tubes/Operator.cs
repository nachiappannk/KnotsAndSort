// See https://aka.ms/new-console-template for more information

public class Operator
{
    private readonly Game game;
    public List<ActionTaken> operations { get; set; } = new List<ActionTaken>();

    public Operator(Game game)
    {
        this.game = game;
    }

    public void Operate(Operation operation)
    {
        var size = game.Move(operation.Source, operation.Destination);
        operations.Add(new ActionTaken()
        {
            Source = operation.Source,
            Destination = operation.Destination,
            Size = size
        });

    }

    public void Undo()
    {
        var operation = operations.ElementAt(operations.Count - 1);
        operations.RemoveAt(operations.Count - 1);
        game.UnMove(operation.Destination, operation.Source, operation.Size);
    }
}

public class ActionTaken
{
    public int Source { get; set; }
    public int Destination { get; set; }

    public int Size { get; set; }
}
