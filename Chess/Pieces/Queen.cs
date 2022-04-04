using Chess.Board;
using Chess.BoardAux;
using Chess.PieceAux;
// ReSharper disable ForeachCanBeConvertedToQueryUsingAnotherGetEnumerator
#pragma warning disable CS8602
#pragma warning disable CS8604

namespace Chess.Pieces;

public class Queen : Piece
{
    public Queen(Color color, int y, int x, Board.Board board) : base(color, y, x, board)
    {
    }

    public override string ToString()
    {
        return "Q";
    }

    public override IEnumerable<Tile> GetPossibleMoves()
    {
        var possibleMoves = new List<Tile>();
        
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

    public override string Move(Tile tileToMoveTo)
    {
        var returnString = "";
        
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
                
                returnString += this.ToString() + "x" + _resources.ColNames[tileToMoveTo.X] + _resources.RowNames[tileToMoveTo.Y];

            }
            else // Else we are just moving to an empty position
            {

                // We need to remove this piece from where it is moving
                var startTile = this.ParentBoard.GetTile(this.Y, this.X);
                startTile.RemovePiece();
                
                tileToMoveTo.AddPieceToTile(this);
                
                returnString += this.ToString() + _resources.ColNames[tileToMoveTo.X] + _resources.RowNames[tileToMoveTo.Y];
            }

            this.Y = tileToMoveTo.Y;
            this.X = tileToMoveTo.X;
        }

        return returnString;
    }
    
}