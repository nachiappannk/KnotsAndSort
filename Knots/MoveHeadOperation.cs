// See https://aka.ms/new-console-template for more information
public class MoveHeadOperation : Operation
{
    private readonly int xs;
    private readonly int ys;
    private readonly int xd;
    private readonly int yd;

    public MoveHeadOperation(int xs, int ys, int xd, int yd)
    {
        this.xs = xs;
        this.ys = ys;
        this.xd = xd;
        this.yd = yd;
    }

    public override void Operate(Board board)
    {
        if (board.IsHead(xs, ys) && board.IsHead(xd, yd))
        {
            board.MoveHead(xs, ys, xd, yd);
            board.DeleteHead(xd, yd);
        }else
        {
            board.MoveHead(xs, ys, xd, yd);
        }
        
    }
}
