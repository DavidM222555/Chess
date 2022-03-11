using Chess.BoardAux;
using Chess.PieceAux;
using Chess.Pieces;
#pragma warning disable CS8604
#pragma warning disable CS8602

namespace Chess.Board;

public class Board
{
    private Tile[,] _tiles;
    private List<Piece> piecesOnBoard;

    // Initialize the board
    public Board()
    {
        _tiles = new Tile[8, 8];
        piecesOnBoard = new List<Piece>();
        
        InitBoard();
    }

    // @purpose: Initializes all the empty cells in the board
    private void InitBoard()
    {
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                _tiles[i, j] = new Tile(i, j);
            }
        }

        var blackLeftRook = new Rook(Color.Black,0,0, this);
        _tiles[0,0].AddPieceToTile(blackLeftRook);
        piecesOnBoard.Add(blackLeftRook);

        var blackLeftKnight = new Knight(Color.Black,0,1, this);
        _tiles[0, 1].AddPieceToTile(blackLeftKnight);
        piecesOnBoard.Add(blackLeftKnight);

        
        var blackLeftBishop = new Bishop(Color.Black,0,2, this);
        _tiles[0,2].AddPieceToTile(blackLeftBishop);
        piecesOnBoard.Add(blackLeftBishop);


        var blackQueen = new Queen(Color.Black,0,3, this);
        _tiles[0,3].AddPieceToTile(blackQueen);
        piecesOnBoard.Add(blackQueen);


        var blackKing = new King(Color.Black,0,4, this);
        _tiles[0,4].AddPieceToTile(blackKing);
        piecesOnBoard.Add(blackKing);


        var blackRightBishop = new Bishop(Color.Black,0,5, this);
        _tiles[0, 5].AddPieceToTile(blackRightBishop);
        piecesOnBoard.Add(blackRightBishop);


        var blackRightKnight = new Knight(Color.Black,0,6, this);
        _tiles[0,6].AddPieceToTile(blackRightKnight);
        piecesOnBoard.Add(blackRightKnight);


        var blackRightRook = new Rook(Color.Black,0,7, this);
        _tiles[0,7].AddPieceToTile(blackRightRook);
        piecesOnBoard.Add(blackRightRook);
        

        var blackPawn1 = new Pawn(Color.Black, 1, 0, this);
        _tiles[1,0].AddPieceToTile(blackPawn1);
        piecesOnBoard.Add(blackPawn1);

        
        var blackPawn2 = new Pawn(Color.Black, 1, 1, this);
        _tiles[1,1].AddPieceToTile(blackPawn2);
        piecesOnBoard.Add(blackPawn2);

        
        var blackPawn3 = new Pawn(Color.Black, 1, 2, this);
        _tiles[1,2].AddPieceToTile(blackPawn3);
        piecesOnBoard.Add(blackPawn3);

        
        var blackPawn4 = new Pawn(Color.Black, 1, 3, this);
        _tiles[1,3].AddPieceToTile(blackPawn4);
        piecesOnBoard.Add(blackPawn4);

        
        var blackPawn5 = new Pawn(Color.Black, 1, 4, this);
        _tiles[1,4].AddPieceToTile(blackPawn5);
        piecesOnBoard.Add(blackPawn5);

        
        var blackPawn6 = new Pawn(Color.Black, 1, 5, this);
        _tiles[1,5].AddPieceToTile(blackPawn6);
        piecesOnBoard.Add(blackPawn6);
        
        
        var blackPawn7 = new Pawn(Color.Black, 1, 6, this);
        _tiles[1,6].AddPieceToTile(blackPawn7);
        piecesOnBoard.Add(blackPawn7);

        
        var blackPawn8 = new Pawn(Color.Black, 1, 7, this);
        _tiles[1,7].AddPieceToTile(blackPawn8);
        piecesOnBoard.Add(blackPawn8);

        
        var whitePawn1 = new Pawn(Color.White, 6, 0, this);
        _tiles[6,0].AddPieceToTile(whitePawn1);
        piecesOnBoard.Add(whitePawn1);

        
        var whitePawn2 = new Pawn(Color.White, 6, 1, this);
        _tiles[6,1].AddPieceToTile(whitePawn2);
        piecesOnBoard.Add(whitePawn2);

        
        var whitePawn3 = new Pawn(Color.White, 6, 2, this);
        _tiles[6,2].AddPieceToTile(whitePawn3);
        piecesOnBoard.Add(whitePawn3);

        
        var whitePawn4 = new Pawn(Color.White, 6, 3, this);
        _tiles[6,3].AddPieceToTile(whitePawn4);
        piecesOnBoard.Add(whitePawn4);

        
        var whitePawn5 = new Pawn(Color.White, 6, 4, this);
        _tiles[6,4].AddPieceToTile(whitePawn5);
        piecesOnBoard.Add(whitePawn5);

        
        var whitePawn6 = new Pawn(Color.White, 6, 5, this);
        _tiles[6,5].AddPieceToTile(whitePawn6);
        piecesOnBoard.Add(whitePawn6);

        
        var whitePawn7 = new Pawn(Color.White, 6, 6, this);
        _tiles[6,6].AddPieceToTile(whitePawn7);
        piecesOnBoard.Add(whitePawn7);

        
        var whitePawn8 = new Pawn(Color.White, 6, 7, this);
        _tiles[6,7].AddPieceToTile(whitePawn8);
        piecesOnBoard.Add(whitePawn8);

        
        var whiteLeftRook = new Rook(Color.White,7,0, this);
        _tiles[7,0].AddPieceToTile(whiteLeftRook);
        piecesOnBoard.Add(whiteLeftRook);


        var whiteLeftKnight = new Knight(Color.White,7,1, this);
        _tiles[7, 1].AddPieceToTile(whiteLeftKnight);
        piecesOnBoard.Add(whiteLeftKnight);


        var whiteLeftBishop = new Bishop(Color.White,7,2, this);
        _tiles[7,2].AddPieceToTile(whiteLeftBishop);
        piecesOnBoard.Add(whiteLeftBishop);


        var whiteQueen = new Queen(Color.White,7,3, this);
        _tiles[7,3].AddPieceToTile(whiteQueen);
        piecesOnBoard.Add(whiteQueen);


        var whiteKing = new King(Color.White,7,4, this);
        _tiles[7,4].AddPieceToTile(whiteKing);
        piecesOnBoard.Add(whiteKing);


        var whiteRightBishop = new Bishop(Color.White,7,5, this);
        _tiles[7, 5].AddPieceToTile(whiteRightBishop);
        piecesOnBoard.Add(whiteRightBishop);


        var whiteRightKnight = new Knight(Color.White,7,6, this);
        _tiles[7,6].AddPieceToTile(whiteRightKnight);
        piecesOnBoard.Add(whiteRightKnight);


        var whiteRightRook = new Rook(Color.White,7,7, this);
        _tiles[7,7].AddPieceToTile(whiteRightRook);
        piecesOnBoard.Add(whiteRightRook);

    }
    
    private Piece? GetPieceOnBoard(int y, int x)
    {
        return _tiles[y, x].GetPieceOnTile();
    }
    
    public void PrintBoard()
    {
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                Console.Write(_tiles[i, j].GetStringOfPieceOnTile());
            }
            Console.WriteLine();
        }
    }
    
    // Returns valid tiles in a given direction -- stops when we hit a piece in the traversal
    public List<Tile> GetValidTilesInDirection(Direction direction, int numberOfMoves, int startY, int startX)
    {
        var tilesInDirection = new List<Tile>();

        var xCounter = startX;
        var yCounter = startY;
        var moveCounter = 0;
        
        switch (direction)
        {
            case Direction.Down:
                yCounter += 1;
                
                // Keep on iterating until we either meet the bounds or we encounter a piece
                while (yCounter < 8 && GetPieceOnBoard(yCounter, xCounter) == null && moveCounter < numberOfMoves)
                {
                    tilesInDirection.Add(_tiles[yCounter, xCounter]);

                    yCounter += 1;
                    moveCounter += 1;
                }
                
                // We then add the first piece hit to our list of valid tiles
                if (yCounter < 8 && moveCounter < numberOfMoves && TestTilePieceColors(_tiles[startY, startX], _tiles[yCounter, xCounter]))
                {
                    tilesInDirection.Add(_tiles[yCounter, xCounter]);
                }
                
                break;
            case Direction.Up:
                yCounter -= 1;
                
                while (yCounter >= 0 && GetPieceOnBoard(yCounter, xCounter) == null && moveCounter < numberOfMoves)
                {
                    tilesInDirection.Add(_tiles[yCounter, xCounter]);

                    yCounter -= 1;
                    moveCounter += 1;
                }

                if (yCounter >= 0 && moveCounter < numberOfMoves && TestTilePieceColors(_tiles[startY, startX], _tiles[yCounter, xCounter]))
                {
                    tilesInDirection.Add(_tiles[yCounter, xCounter]);
                }
                
                break;
            case Direction.Left:
                xCounter -= 1;
                
                while (xCounter >= 0 && GetPieceOnBoard(yCounter, xCounter) == null && moveCounter < numberOfMoves)
                {
                    tilesInDirection.Add(_tiles[yCounter, xCounter]);

                    xCounter -= 1;
                    moveCounter += 1;
                }

                if (xCounter >= 0 && moveCounter < numberOfMoves && TestTilePieceColors(_tiles[startY, startX], _tiles[yCounter, xCounter]))
                {
                    tilesInDirection.Add(_tiles[yCounter, xCounter]);
                }
                
                break;
            case Direction.Right:
                xCounter += 1;
                
                while (xCounter < 8 && GetPieceOnBoard(yCounter, xCounter) == null && moveCounter < numberOfMoves)
                {
                    tilesInDirection.Add(_tiles[yCounter, xCounter]);

                    xCounter += 1;
                    moveCounter += 1;
                }

                if (xCounter < 8 && moveCounter < numberOfMoves && TestTilePieceColors(_tiles[startY, startX], _tiles[yCounter, xCounter]))
                {
                    tilesInDirection.Add(_tiles[yCounter, xCounter]);
                }
                
                break;
            case Direction.DownLeft:
                yCounter += 1;
                xCounter -= 1;
                
                while (xCounter >= 0 && yCounter < 8 && GetPieceOnBoard(yCounter, xCounter) == null && moveCounter < numberOfMoves)
                {
                    tilesInDirection.Add(_tiles[yCounter, xCounter]);

                    yCounter += 1;
                    xCounter -= 1;
                    moveCounter += 1;
                }

                if (xCounter >= 0 && yCounter < 8 && moveCounter < numberOfMoves && TestTilePieceColors(_tiles[startY, startX], _tiles[yCounter, xCounter]))
                {
                    tilesInDirection.Add(_tiles[yCounter, xCounter]);
                }
                break;
            case Direction.DownRight:
                yCounter += 1;
                xCounter += 1;
                
                while (xCounter < 8 && yCounter < 8 && GetPieceOnBoard(yCounter, xCounter) == null && moveCounter < numberOfMoves)
                {
                    tilesInDirection.Add(_tiles[yCounter, xCounter]);

                    yCounter += 1;
                    xCounter += 1;
                    moveCounter += 1;
                }

                if (xCounter < 8 && yCounter < 8 && moveCounter < numberOfMoves && TestTilePieceColors(_tiles[startY, startX], _tiles[yCounter, xCounter]))
                {
                    tilesInDirection.Add(_tiles[yCounter, xCounter]);
                }
                break;
            case Direction.UpLeft:
                yCounter -= 1;
                xCounter -= 1;
                
                while (xCounter >= 0 && yCounter >= 0 && GetPieceOnBoard(yCounter, xCounter) == null && moveCounter < numberOfMoves)
                {
                    tilesInDirection.Add(_tiles[yCounter, xCounter]);

                    yCounter -= 1;
                    xCounter -= 1;
                    moveCounter += 1;
                }

                if (xCounter >= 0 && yCounter >= 0 && moveCounter < numberOfMoves && TestTilePieceColors(_tiles[startY, startX], _tiles[yCounter, xCounter]))
                {
                    tilesInDirection.Add(_tiles[yCounter, xCounter]);
                }
                break;
            case Direction.UpRight:
                yCounter -= 1;
                xCounter += 1;
                
                while (xCounter < 8 && yCounter >= 0 && GetPieceOnBoard(yCounter, xCounter) == null && moveCounter < numberOfMoves)
                {
                    tilesInDirection.Add(_tiles[yCounter, xCounter]);

                    yCounter -= 1;
                    xCounter += 1;
                    moveCounter += 1;
                }

                if (xCounter < 8 && yCounter >= 0 && moveCounter < numberOfMoves && TestTilePieceColors(_tiles[startY, startX], _tiles[yCounter, xCounter]))
                {
                    tilesInDirection.Add(_tiles[yCounter, xCounter]);
                }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
        
        return tilesInDirection;
    }
    
    public Tile? GetTile(int y, int x)
    {
        if(y < 8 && y >= 0 && x < 8 && x >= 0)
        {
            return _tiles[y, x];
        }
        
        return null;
    }
    
    
    public void RemovePieceFromGame(Tile tile)
    {
        Piece? pieceOnTile = this.GetPieceOnBoard(tile.Y, tile.X);
        
        this.RemovePieceFromBoard(pieceOnTile);
        
        tile.RemovePiece();
    }

    // Removes a piece from the board list
    public void RemovePieceFromBoard(Piece piece)
    {
        if(this.piecesOnBoard.Contains(piece))
        {
            this.piecesOnBoard.Remove(piece);

        }
        
    }

    // Iterates across all pieces and gets all valid moves in the current game state
    public List<Tuple<Piece, IEnumerable<Tile>>> GetAllValidMoves()
    {
        var allValidMoves = new List<Tuple<Piece, IEnumerable<Tile>>>();

        foreach (var piece in this.piecesOnBoard)
        {
            var movesForPiece =  piece.GetPossibleMoves();
            
            allValidMoves.Add(Tuple.Create(piece, movesForPiece));
        }
        
        return allValidMoves;
    }

    // Helper function used to test whether or not the pieces on two tiles are of the same color (and thus can't attack each other)
    public bool TestTilePieceColors(Tile tile1, Tile tile2)
    {
        if (tile1.GetPieceOnTile() != null && tile2.GetPieceOnTile() != null)
        {
            return tile1.GetPieceOnTile().PieceColor != tile2.GetPieceOnTile().PieceColor;
        }
        
        return true;
    }

    // Used for checking whether if a piece moving would put the king into check (and thus make it an invalid move)
    public bool PieceHitBy(Piece piece)
    {
        return false;
    }
    
}