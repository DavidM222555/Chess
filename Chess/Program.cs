// See https://aka.ms/new-console-template for more information

#pragma warning disable CS8604
#pragma warning disable CS8602

namespace Chess;

static class MainClass
{
    public static void Main()
    {
        var chessBoard = new Board.Board();
        
        string? cont = "yes";
        
        while (cont == "yes") // Game loop
        {
            var randomMoveString = chessBoard.MakeRandomMove();
            
            Console.Write("Move string of random move: " + randomMoveString + "\n");
            
            Console.Write("Board after random move: " + "\n");
            chessBoard.PrintBoard();
            
            Console.Write("Continue?" + "\n");
            cont = Console.ReadLine();
        }

    }
}