// See https://aka.ms/new-console-template for more information

public class Board
{
    private Cell[,] cells;

    public int X { get; }
    public int Y { get; }

    public Board(int x, int y)
    {
        cells = new Cell[x, y];
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                cells[i, j] = new Cell(i, j);
            }
        }
        X = x;
        Y = y;
    }

    public bool IsSet(int x, int y)
    {
        return cells[x, y].IsSet();
    }

    public int GetValue(int x, int y)
    {
        return cells[x, y].Value;
    }


    public void SetHead(int x, int y, int color)
    {
        cells[x, y].Value = color;
        cells[x, y].IsHead = true;
    }

    public void MoveHead(int xs, int ys, int xd, int yd)
    {
        if (!cells[xs, ys].IsHead) throw new Exception();
        var value = cells[xs, ys].Value;
        cells[xd, yd].Value = value;
        cells[xs, ys].IsHead = false;
        cells[xd, yd].IsHead = true;
    }
    public bool IsHead(int x, int y)
    { 
        return cells[x, y].IsHead;
    }

    public List<Point> GetPossibleHeadMovementPoints(int x, int y)
    { 
        if(!IsHead(x, y)) throw new Exception();

        Cell? left = x == 0 ? null : cells[x - 1, y];
        Cell? right = x == cells.GetLength(0) - 1 ? null : cells[x + 1, y];
        Cell? up = y == 0 ? null : cells[x, y - 1];
        Cell? down = y == cells.GetLength(1) - 1 ? null : cells[x, y + 1];
        var cellList = new List<Cell?>() { up, down, right, left };
        cellList = cellList.Where(x => x != null).ToList();
        cellList = cellList.Where(n =>
        {
            if (!n.IsSet()) return true;
            if (n.IsHead && n.Value == cells[x, y].Value) return true;
            return false;
        }).ToList();
        return cellList.Select(p => new Point()
        {
            X = p.X,
            Y = p.Y,
        }).ToList();
    }

    internal bool IsInconsistent()
    {
        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                if (IsHead(i, j))
                {
                    var points = GetPossibleHeadMovementPoints(i, j);
                    if(points.Count == 0) return true;
                }
            }
        }
        return false;
    }

    internal bool IsSolved()
    {
        for (int i = 0; i < X; i++)
        {
            for (int j = 0; j < Y; j++)
            {
                if (IsHead(i, j))
                {
                    return false;
                }
            }
        }
        return true;
    }

    internal void DeleteHead(int x, int y)
    {
        cells[x, y].IsHead = false;
    }
}