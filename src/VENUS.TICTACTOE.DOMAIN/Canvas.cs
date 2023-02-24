namespace VENUS.TICTACTOE.DOMAIN
{
    using System;
    public class Canvas
    {
        private char[] _board { get; set; }
        public Canvas(char[] board)
        {
            _board = board;
        }
        public void PrintBoard()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", _board[1], _board[2], _board[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", _board[4], _board[5], _board[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", _board[7], _board[8], _board[9]);
            Console.WriteLine("     |     |      ");
        }

        public void ReadPosition(int player)
        {
            string choice = Console.ReadLine();
            int position = int.Parse(choice);
            if (position >= _board.Length || position < 1)
            {
                Console.WriteLine("Invalid movement", choice);
                Console.WriteLine("\n");
                Console.WriteLine("Please wait 2 second board is loading again.....");
                Thread.Sleep(2000);
            }
            else
            {
                if (_board[position] != 'X' && _board[position] != 'O')
                {
                    if (player % 2 == 0)
                    {
                        _board[position] = 'O';
                    }
                    else
                    {
                        _board[position] = 'X';
                    }
                }
                else
                {
                    Console.WriteLine("Sorry the row {0} is already marked with {1}", choice, _board[position]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait 2 second board is loading again.....");
                    Thread.Sleep(2000);
                }
            }
        }
    }
}