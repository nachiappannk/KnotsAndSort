// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

int RED = 0;
int MAGENTA = 1;
int GREEN = 2;
int YELLOW = 3;
int BLUE = 4;

Stack stack = new Stack();
stack.Push(new SetHeadOperation(4, 1, MAGENTA));
stack.Push(new SetHeadOperation(2, 4, MAGENTA));

stack.Push(new SetHeadOperation(5, 2, GREEN));
stack.Push(new SetHeadOperation(2, 6, GREEN));

stack.Push(new SetHeadOperation(2, 3, BLUE));
stack.Push(new SetHeadOperation(4, 7, BLUE));

stack.Push(new SetHeadOperation(3, 5, RED));
stack.Push(new SetHeadOperation(1, 7, RED));

stack.Push(new SetHeadOperation(2, 2, YELLOW));
stack.Push(new SetHeadOperation(1, 6, YELLOW));

var board = GetBoard(stack);

Display d = new Display();
//d.Show(board);
while (TryMoveHead(board, d, stack)) { }

Repeat(stack, d);

Console.WriteLine("Arrived at the solution. Showing it");
Task.Delay(1000).Wait();


Board b1 = new Board(6, 9);
foreach (var o in stack.GetOperations())
{
    o.Operate(b1);
    d.Show(b1);
}

static bool Repeat(Stack stack, Display d)
{
    Board board = GetBoard(stack);
    List<MoveHeadOperation> operationList = GetMinimumOperations(board);
    foreach (var ops in operationList)
    {
        stack.PushWithResetMarker(ops);
        var b1 = GetBoard(stack);
        //d.Show(b1);
        while (TryMoveHead(b1, d, stack)) { }
        if (b1.IsInconsistent())
        {
            stack.Reset();
            //Console.WriteLine("RESETTING the OPtion");
            //Task.Delay(1000).Wait();
            continue;
        }
        if (b1.IsSolved())
        { 
            return true;
        }
        if (Repeat(stack, d) == true)
        {
            return true;
        }
        stack.Reset();
        //Console.WriteLine("RESETTING the OPtion");
        //Task.Delay(1000).Wait();
    }
    return false;
}


static bool TryMoveHead(Board board, Display d, Stack stack)
{
    for (int i = 0; i < board.X; i++)
    {
        for (int j = 0; j < board.Y; j++)
        {
            if (board.IsHead(i, j))
            {
                var points = board.GetPossibleHeadMovementPoints(i, j);
                if (points.Count == 1)
                {
                    var operation = new MoveHeadOperation(i, j, points[0].X, points[0].Y);
                    stack.Push(operation);
                    operation.Operate(board);
                    //d.Show(board);
                    return true;
                }
            }
        }
    }

    return false;
}

static Board GetBoard(Stack stack)
{
    Board board = new Board(6, 9);
    var operations = stack.GetOperations();
    foreach (var operation in operations)
    {
        operation.Operate(board);
    }
    return board; ;
}
static List<MoveHeadOperation> GetMinimumOperations(Board board)
{
    var listOfOperations = new List<List<MoveHeadOperation>>();
    for (int i = 0; i < board.X; i++)
    {
        for (int j = 0; j < board.Y; j++)
        {
            if (board.IsHead(i, j))
            {
                var points = board.GetPossibleHeadMovementPoints(i, j);
                var r = points.Select(x => new MoveHeadOperation(i, j, x.X, x.Y)).ToList();
                listOfOperations.Add(r);
            }
        }
    }
    return listOfOperations.ElementAt(0);//Todo to be removed
    var minPossibilities = listOfOperations.Min(x => x.Count);
    var operationList = listOfOperations.Where(x => x.Count == minPossibilities).First();
    return operationList;
}