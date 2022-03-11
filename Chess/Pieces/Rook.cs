using Chess.Board;
using Chess.BoardAux;
using Chess.PieceAux;
#pragma warning disable CS8602
#pragma warning disable CS8604

namespace Chess.Pieces;

public class Rook : Piece
{
    public Rook(Color color, int y, int x, Board.Board board) : base(color, y, x, board)
    {
    }
    
    public override string ToString()
    {
        return "R";
    }

    public override IEnumerable<Tile> GetPossibleMoves()
    {
        List<Tile> possibleMoves = new List<Tile>();

        var downwardMoves = this.ParentBoard.GetValidTilesInDirection(Direction.Down, 10, this.Y, this.X);
        
        foreach (var move in downwardMoves)
        {
            possibleMoves.Add(move);
        }
        
        var upwardMoves = this.ParentBoard.GetValidTilesInDirection(Direction.Up, 10, this.Y, this.X);
        
        foreach (var move in upwardMoves)
        {
            possibleMoves.Add(move);
        }
        
        var leftMoves = this.ParentBoard.GetValidTilesInDirection(Direction.Left, 10, this.Y, this.X);
        
        foreach (var move in leftMoves)
        {
            possibleMoves.Add(move);
        }
        
        var rightMoves = this.ParentBoard.GetValidTilesInDirection(Direction.Right, 10, this.Y, this.X);

        foreach (var move in rightMoves)
        {
            possibleMoves.Add(move);
        }
        
        return possibleMoves;
    }

    public override void UpdatePossibleMoves()
    {
        this.PossibleMoves = GetPossibleMoves();
    }

    public override void Move(Tile tileToMoveTo)
    {
        this.UpdatePossibleMoves();
        
        if(this.PossibleMoves.Contains(tileToMoveTo))
        {
            if (tileToMoveTo.IsTileOccupied()) // This is the case when we attack a tile and need to remove the piece on it.
            {
                // We need to remove this piece from where it is moving
                var startTile = this.ParentBoard.GetTile(this.Y, this.X);
                startTile.RemovePiece();

                this.ParentBoard.RemovePieceFromGame(tileToMoveTo);

                tileToMoveTo.AddPieceToTile(this);
                
            }
            else // Else we are just moving to an empty position
            {

                // We need to remove this piece from where it is moving
                var startTile = this.ParentBoard.GetTile(this.Y, this.X);
                startTile.RemovePiece();
                
                tileToMoveTo.AddPieceToTile(this);
            }

            this.Y = tileToMoveTo.Y;
            this.X = tileToMoveTo.X;
        }
    }
}