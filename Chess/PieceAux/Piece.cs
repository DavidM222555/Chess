using System.Collections;
using Chess.Board;

namespace Chess.PieceAux; 


public abstract class Piece
{
    protected internal Color PieceColor { get; set; }

    protected IEnumerable<Tile> PossibleMoves;

    protected int X;
    protected int Y;

    protected Board.Board ParentBoard;

    public override string? ToString()
    {
        return base.ToString();
    }
    
    protected Piece(Color color, int y, int x, Board.Board parentBoard)
    {
        Y = y;
        X = x;
        
        PieceColor = color;
        PossibleMoves = new List<Tile>();

        ParentBoard = parentBoard;
    }

    protected void UpdateLocation(int newY, int newX)
    {
        Y = newY;
        X = newX;
    }

    public abstract IEnumerable<Tile> GetPossibleMoves();

    public abstract void UpdatePossibleMoves();
    public abstract void Move(Tile tileToMoveTo);
    
}