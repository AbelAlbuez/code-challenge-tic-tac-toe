namespace VENUS.TICTACTOE.DOMAIN
{
    using System;
    public class Canvas
    {
        private Board _board { get; set; }
        public Canvas(Board board)
        {
            _board = board;
            CreateBoard();
        }
        private void CreateBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _board.board[i, j] = " ";
                }
            }
        }
        public void PrintBoard()
        {
            Console.WriteLine("___________________________________");
            Console.WriteLine("3" + "  {0}     |  {1}    |   {2}  ", _board.board[0, 0], _board.board[0, 1], _board.board[0, 2]);
            Console.WriteLine("___________________________________");
            Console.WriteLine("2" + "  {0}     |  {1}    |   {2}  ", _board.board[1, 0], _board.board[1, 1], _board.board[1, 2]);
            Console.WriteLine("___________________________________");
            Console.WriteLine("1" + "  {0}     |  {1}    |   {2}  ", _board.board[2, 0], _board.board[2, 1], _board.board[2, 2]);
            Console.WriteLine("___________________________________");
            Console.WriteLine(" " + "  a     |  b    |   c  ");
        }

        public Position ReadPosition(string row, string column)
        {
            if(string.IsNullOrEmpty(row))
            {
                throw new Exception("You have entered an invalid row");
            }

            if (string.IsNullOrEmpty(column))
            {
                throw new Exception("You have entered an invalid column");
            }

            return new Position(int.Parse(row), int.Parse(column));
        }
    }
}