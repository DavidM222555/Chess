using Chess.PieceAux;

namespace Chess.Board;

public class Tile
{
    public int X;
    public int Y;

    private Piece? _pieceOnTile;

    public Tile(int y, int x)
    {
        this.X = x;
        this.Y = y;
    }

    public void AddPieceToTile(Piece pieceToPutOnTile)
    {
        this._pieceOnTile = pieceToPutOnTile;
    }

    public string? GetStringOfPieceOnTile()
    {
        return this._pieceOnTile == null ? " " : this._pieceOnTile.ToString();
    }

    public bool IsTileOccupied()
    {
        return this._pieceOnTile != null;
    }

    public Piece? GetPieceOnTile()
    {
        return _pieceOnTile;
    }
    
    public void RemovePiece()
    {
        _pieceOnTile = null;
    }
    
    
}