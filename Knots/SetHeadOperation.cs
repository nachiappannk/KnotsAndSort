// See https://aka.ms/new-console-template for more information
public class SetHeadOperation : Operation
{
    private readonly int x;
    private readonly int y;
    private readonly int color;

    public SetHeadOperation(int x, int y, int color)
    {
        this.x = x;
        this.y = y;
        this.color = color;
    }

    public override void Operate(Board board)
    {
        board.SetHead(x, y, color);
    }
}
