using Chess.Board;
using Chess.BoardAux;
using Chess.PieceAux;
// ReSharper disable All
#pragma warning disable CS8604
#pragma warning disable CS8602

namespace Chess.Pieces;

public class Pawn : Piece
{
    public bool MovedYet { get; set; } // Used to determine if the piece can move two tiles or not
    
    public override string ToString()
    {
        return "P";
    }

    public Pawn(Color color, int y, int x, Board.Board board) : base(color, y, x, board) {}

    public override IEnumerable<Tile> GetPossibleMoves()
    {
        var possibleMoves = new List<Tile>();

        // Determines whether we go up or down the board
        if (PieceColor == Color.Black)
        {
            
            var downwardMoves = this.ParentBoard.GetValidTilesInDirection(Direction.Down, 2, this.Y, this.X);

            if (MovedYet == false && downwardMoves.Count >= 2)
            {
                if (downwardMoves[0].IsTileOccupied() == false)
                {
                    possibleMoves.Add(downwardMoves[0]);
                }

                if (downwardMoves[1].IsTileOccupied() == false)
                {
                    possibleMoves.Add(downwardMoves[1]);
                }
            }
            else if(downwardMoves.Count >= 1)
            {
                if (downwardMoves[0].IsTileOccupied() == false)
                {
                    possibleMoves.Add(downwardMoves[0]);
                }
            }

            var downLeftAttackTile = this.ParentBoard.GetTile(this.Y + 1, this.X - 1);
            var downRightAttackTile = this.ParentBoard.GetTile(this.Y + 1, this.X + 1);
            
            if (downLeftAttackTile != null && downLeftAttackTile.IsTileOccupied()) // Down and left attack position
            {
                if (downLeftAttackTile.GetPieceOnTile().PieceColor == Color.White) 
                {
                    
                    possibleMoves.Add(downLeftAttackTile);
                }
            }

            if (downRightAttackTile != null && downRightAttackTile.IsTileOccupied()) // Down and right attack position
            {
                if (downRightAttackTile.GetPieceOnTile().PieceColor == Color.White)
                {
                    possibleMoves.Add(downRightAttackTile);
                }
            }

        }
        else // Case for white pawns
        {
            var upwardMoves = this.ParentBoard.GetValidTilesInDirection(Direction.Up, 2, this.Y, this.X);

            if (MovedYet == false && upwardMoves.Count >= 2)
            {
                if (upwardMoves[0].IsTileOccupied() == false)
                {
                    possibleMoves.Add(upwardMoves[0]);
                }

                if (upwardMoves[1].IsTileOccupied() == false)
                {
                    possibleMoves.Add(upwardMoves[1]);
                }
            }
            else if(upwardMoves.Count >= 1)
            {
                if (upwardMoves[0].IsTileOccupied() == false)
                {
                    possibleMoves.Add(upwardMoves[0]);
                }
            }
            
            var upLeftAttackTile = this.ParentBoard.GetTile(this.Y - 1, this.X - 1);
            var upRightAttackTile = this.ParentBoard.GetTile(this.Y - 1, this.X + 1);
            
            if (upLeftAttackTile != null && upLeftAttackTile.IsTileOccupied()) // Down and left attack position
            {
                if (upLeftAttackTile.GetPieceOnTile().PieceColor == Color.Black)
                {
                    possibleMoves.Add(upLeftAttackTile);
                }
            }

            if (upRightAttackTile != null && upRightAttackTile.IsTileOccupied()) // Down and right attack position
            {
                if (upRightAttackTile.GetPieceOnTile().PieceColor == Color.Black)
                {
                    possibleMoves.Add(upRightAttackTile);
                }
                
            }
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
            this.MovedYet = true;
        }
    }
    
}