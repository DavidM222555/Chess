using System.Collections;
using Chess.Board;
using Chess.BoardAux;

namespace Chess.PieceAux; 


public abstract class Piece
{
    public Resources _resources; // Used for various things to help us get the algebraic names of moves
    
    protected internal Color PieceColor { get; set; }

    protected IEnumerable<Tile> PossibleMoves;

    protected int X;
    protected int Y;

    protected readonly Board.Board ParentBoard;

    public override string? ToString()
    {
        return base.ToString();
    }
    
    protected Piece(Color color, int y, int x, Board.Board parentBoard)
    {
        _resources = new Resources();
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
    public abstract string Move(Tile tileToMoveTo);
    
}
