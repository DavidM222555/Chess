using Chess.Board;
using Chess.BoardAux;
using Chess.PieceAux;
#pragma warning disable CS8602
#pragma warning disable CS8604

namespace Chess.Pieces;

public class King : Piece
{
    public King(Color color, int y, int x, Board.Board board) : base(color, y, x, board)
    {
    }
    public override string ToString()
    {
        return "K";
    }

    public override IEnumerable<Tile> GetPossibleMoves()
    {
        List<Tile> possibleMoves = new List<Tile>();
        
        var downwardMoves = this.ParentBoard.GetValidTilesInDirection(Direction.Down, 1, this.Y, this.X);
        
        foreach (var move in downwardMoves)
        {
            possibleMoves.Add(move);
        }
        
        var upwardMoves = this.ParentBoard.GetValidTilesInDirection(Direction.Up, 1, this.Y, this.X);
        
        foreach (var move in upwardMoves)
        {
            possibleMoves.Add(move);
        }
        
        var leftMoves = this.ParentBoard.GetValidTilesInDirection(Direction.Left, 1, this.Y, this.X);
        
        foreach (var move in leftMoves)
        {
            possibleMoves.Add(move);
        }
        
        var rightMoves = this.ParentBoard.GetValidTilesInDirection(Direction.Right, 1, this.Y, this.X);

        foreach (var move in rightMoves)
        {
            possibleMoves.Add(move);
        }
        
        var downLeftMoves = this.ParentBoard.GetValidTilesInDirection(Direction.DownLeft, 1, this.Y, this.X);
        
        foreach (var move in downLeftMoves)
        {
            possibleMoves.Add(move);
        }
        
        var downRightMoves = this.ParentBoard.GetValidTilesInDirection(Direction.DownRight, 1, this.Y, this.X);
        
        foreach (var move in downRightMoves)
        {
            possibleMoves.Add(move);
        }
        
        var upLeftMoves = this.ParentBoard.GetValidTilesInDirection(Direction.UpLeft, 1, this.Y, this.X);
        
        foreach (var move in upLeftMoves)
        {
            possibleMoves.Add(move);
        }
        
        var upRightMoves = this.ParentBoard.GetValidTilesInDirection(Direction.UpRight, 1, this.Y, this.X);
        
        foreach (var move in upRightMoves)
        {
            possibleMoves.Add(move);
        }

        
        return possibleMoves;
    }

    public override void UpdatePossibleMoves()
    {
        this.PossibleMoves = this.GetPossibleMoves();
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