using Chess.Board;
using Chess.PieceAux;
#pragma warning disable CS8602
#pragma warning disable CS8604

namespace Chess.Pieces;

public class Knight : Piece
{
    public Knight(Color color, int y, int x, Board.Board board) : base(color, y, x, board)
    {
    }
    
    public override string ToString()
    {
        return "N";
    }

    public override IEnumerable<Tile> GetPossibleMoves()
    {
        List<Tile> possibleMoves = new List<Tile>();
        
        // There are up to 8 valid moves for the knight and we will need
        // to bound check each of them 

        var startTile = ParentBoard.GetTile(this.Y, this.X);
        
        if (this.Y - 2 >= 0 && this.X - 1 >= 0)
        {
            var possibleTileToAdd = ParentBoard.GetTile(this.Y - 2, this.X - 1);

            if (ParentBoard.TestTilePieceColors(startTile, possibleTileToAdd))
            {
                possibleMoves.Add(possibleTileToAdd);
            }
        }

        if (this.Y - 1 >= 0 && this.X - 2 >= 0)
        {
            var possibleTileToAdd = ParentBoard.GetTile(this.Y - 1, this.X - 2);

            if (ParentBoard.TestTilePieceColors(startTile, possibleTileToAdd))
            {
                possibleMoves.Add(possibleTileToAdd);
            }
        }

        if (this.Y + 1 < 8 && this.X - 2 >= 0)
        {
            var possibleTileToAdd = ParentBoard.GetTile(this.Y + 1, this.X - 2);

            if (ParentBoard.TestTilePieceColors(startTile, possibleTileToAdd))
            {
                possibleMoves.Add(possibleTileToAdd);
            }
        }

        if (this.Y + 2 < 8 && this.X - 1 >= 0)
        {
            var possibleTileToAdd = ParentBoard.GetTile(this.Y + 2, this.X - 1);

            if (ParentBoard.TestTilePieceColors(startTile, possibleTileToAdd))
            {
                possibleMoves.Add(possibleTileToAdd);
            }
        }

        if (this.Y + 2 < 8 && this.X + 1 < 8)
        {
            var possibleTileToAdd = ParentBoard.GetTile(this.Y + 2, this.X + 1);

            if (ParentBoard.TestTilePieceColors(startTile, possibleTileToAdd))
            {
                possibleMoves.Add(possibleTileToAdd);
            }
        }

        if (this.Y + 1 < 8 && this.X + 2 < 8)
        {
            var possibleTileToAdd = ParentBoard.GetTile(this.Y + 1, this.X + 2);

            if (ParentBoard.TestTilePieceColors(startTile, possibleTileToAdd))
            {
                possibleMoves.Add(possibleTileToAdd);
            }
        }

        if (this.Y - 1 >= 0 && this.X + 2 < 8)
        {
            var possibleTileToAdd = ParentBoard.GetTile(this.Y - 1, this.X + 2);

            if (ParentBoard.TestTilePieceColors(startTile, possibleTileToAdd))
            {
                possibleMoves.Add(possibleTileToAdd);
            }
        }

        if (this.Y - 2 >= 0 && this.X + 1 < 8)
        {
            var possibleTileToAdd = ParentBoard.GetTile(this.Y - 2, this.X + 1);

            if (ParentBoard.TestTilePieceColors(startTile, possibleTileToAdd))
            {
                possibleMoves.Add(possibleTileToAdd);
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
                startTile?.RemovePiece();
                
                tileToMoveTo.AddPieceToTile(this);
            }

            this.Y = tileToMoveTo.Y;
            this.X = tileToMoveTo.X;
        }
    }
    
}