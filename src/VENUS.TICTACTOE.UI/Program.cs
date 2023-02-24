namespace VENUS.TICTACTOE.UI
{
    using VENUS.TICTACTOE.DOMAIN;
    internal class Program
    {

        static void Main(string[] args)
        {
            char[] board = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            int flag = 0;
            int player = 1;
            Canvas canvas = new Canvas(board);
            Match match = new Match();
            do
            {
                Console.Clear();
                Console.WriteLine("Player1:X and Player2:O");
                canvas.PrintBoard();
                Console.WriteLine("\n");
                if (player % 2 == 0)
                {
                    Console.WriteLine("Player 2 Chance");
                }
                else
                {
                    Console.WriteLine("Player 1 Chance");
                }
                canvas.ReadPosition(player);
                player++;
                flag = match.CheckWin(board);
            }
            while (flag != 1 && flag != -1);
            Console.Clear();
            if (flag == 1)
            {
          
                canvas.PrintBoard();
                Console.WriteLine("Player {0} has won", (player % 2) + 1);
            }
            else
            {
                Console.WriteLine("Draw");
            }

            Console.ReadLine();
        }
    }
}