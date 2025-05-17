using System.Reflection.PortableExecutable;
using System.Security.Cryptography.X509Certificates;

namespace Connect4;

class Program
{
    public static class Consts
    {
        public const int BoardWidth = 7;
        public const int BoardHeight = 6;
    }

    static List<int[]> SetupBoard()
    {
        int[] row = new int[Consts.BoardWidth];
        for (int i = 0; i < Consts.BoardWidth; i++)
        {
            row[i] = 0;
        }
        List<int[]> board = new List<int[]>();
        for (int i = 0; i < Consts.BoardHeight; i++)
        {
            board.Add((int[])row.Clone());
        }
        board[0][0] = 1;
        board[0][1] = 2;
        // temporary for testing
        return board;
    }

    static void DrawPixel(int pixel)
    {
        switch (pixel)
        {
            case 0:
                Console.Write("# ");
                break;
            case 1:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("# ");
                Console.ResetColor();
                break;
            case 2:
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("# ");
                Console.ResetColor();
                break;
        }
    }
    static void DrawBoard(List<int[]> board)
    {
        int xPos = 0;
        int yPos = 0;
        for (int y = 0; y < (Consts.BoardHeight * 4) - 1; y++)
        {
            for (int x = 0; x < (Consts.BoardWidth * 4) - 1; x++)
            {
                if (y % 4 == 3)
                {
                    Console.Write("--");
                }
                else
                {    
                    int currentPixelState = board[yPos][xPos];
                    if ((x + 1) % 4 != 0 || x == 0)
                    // draw # when its not a space
                    {
                        DrawPixel(currentPixelState);
                    }
                    if (x % 4 == 3)
                    // increment xPos every 4th x (on spaces)
                    {
                        Console.Write("| ");
                        xPos++;
                    }
                }
            }
            if (y % 4 == 3)
            // increment YPos every 4th y
            {
                yPos++;
            }
            xPos = 0;
            Console.WriteLine();
        }
    }
    static int GetPlayerInput(int currentPlayer){
        // input loop logic
        while(true){
            //Get and Store currentPlayer input
            Console.Write($"Player {currentPlayer}'s Turn:");
            string input = Console.ReadLine() ?? "";
            
            //initialize col and give it the int conversion of input, initilize IsNumber as the bool return of Tryparse(input)
            int col;
            bool IsNumber = int.TryParse(input, out col);

            //logic for handling cases 
            if (!IsNumber){
                Console.WriteLine("Not a Number. Try Again.");
                continue;
            }
            if (col < 1 || col > Consts.BoardWidth){
                Console.WriteLine("Number is out of bounds. Try again.");
                continue;
            }
            //returning PlayerInput
            return col-1;        
            }
    }
    static void Main()
    {
        List<int[]> board = SetupBoard();
        DrawBoard(board);
    }
}