using Chess.Board;
using Chess.BoardAux;
using Chess.PieceAux;
#pragma warning disable CS8604
#pragma warning disable CS8602

namespace Chess.Pieces;

public class Bishop : Piece
{
    public Bishop(Color color, int y, int x, Board.Board board) : base(color, y, x, board)
    {
    }
    
    public override string ToString()
    {
        return "B";
    }

    public override IEnumerable<Tile> GetPossibleMoves()
    {
        List<Tile> possibleMoves = new List<Tile>();
        
        var downLeftMoves = this.ParentBoard.GetValidTilesInDirection(Direction.DownLeft, 10, this.Y, this.X);
        
        foreach (var move in downLeftMoves)
        {
            possibleMoves.Add(move);
        }
        
        var downRightMoves = this.ParentBoard.GetValidTilesInDirection(Direction.DownRight, 10, this.Y, this.X);
        
        foreach (var move in downRightMoves)
        {
            possibleMoves.Add(move);
        }
        
        var upLeftMoves = this.ParentBoard.GetValidTilesInDirection(Direction.UpLeft, 10, this.Y, this.X);
        
        foreach (var move in upLeftMoves)
        {
            possibleMoves.Add(move);
        }
        
        var upRightMoves = this.ParentBoard.GetValidTilesInDirection(Direction.UpRight, 10, this.Y, this.X);
        
        foreach (var move in upRightMoves)
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