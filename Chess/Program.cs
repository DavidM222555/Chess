// See https://aka.ms/new-console-template for more information

#pragma warning disable CS8604
#pragma warning disable CS8602

namespace Chess;

static class MainClass
{
    public static void Main()
    {
        var chessBoard = new Board.Board();
        
        var rookPiece = chessBoard.GetTile(0, 1).GetPieceOnTile();
        
        rookPiece.Move(chessBoard.GetTile(2, 2));
        rookPiece.Move(chessBoard.GetTile(4, 3));
        
        chessBoard.PrintBoard();
        
        var allValidMoves = chessBoard.GetAllValidMoves();

        // foreach (var list in allValidMoves)
        // {
        //     Console.WriteLine("Current piece: " + list.Item1.ToString());
        //     
        //     foreach(var x in list.Item2)
        //     {
        //         Console.WriteLine("Move to Y = " + x.Y + " X = " + x.X);
        //     }
        // }

        // while (true) // Game loop
        // {
        //     Console.Write("Enter Y of tile to move: ");
        //     int startY = Convert.ToInt16(Console.ReadLine());
        //     
        //
        //     Console.Write("Enter X of tile to move: ");
        //     int startX = Convert.ToInt16(Console.ReadLine());
        //
        //     Console.Write("Enter Y to move to: ");
        //     int endingY = Convert.ToInt16(Console.ReadLine());
        //     
        //     Console.Write("Enter X to move to: ");
        //     int endingX = Convert.ToInt16(Console.ReadLine());
        //     
        //     var pieceToMove = chessBoard.GetTile(startY, startX).GetPieceOnTile();
        //     
        //     pieceToMove.Move(chessBoard.GetTile(endingY, endingX));
        //     
        //     Console.WriteLine("Board after move: ");
        //     chessBoard.PrintBoard();
        //     Console.WriteLine();
        // }

    }
}