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
                    _board.Table[i, j] = " ";
                }
            }
        }

        public void PrintBoard()
        {
            Console.WriteLine("\t--------------------------------------------------------------------------");
            //Console.WriteLine("row: \t0 \t| \t1 \t| \t2");
            Console.WriteLine($"\t0 \t| \t{_board.Table[0,0]} \t| \t{_board.Table[0,1]} \t| \t{_board.Table[0,2]} \t|");
            Console.WriteLine("\t--------------------------------------------------------------------------");
            Console.WriteLine($"\t1 \t| \t{_board.Table[1,0]} \t| \t{_board.Table[1,1]} \t| \t{_board.Table[1,2]} \t|");
            Console.WriteLine("\t--------------------------------------------------------------------------");
            Console.WriteLine($"\t2 \t| \t{_board.Table[2,0]} \t| \t{_board.Table[2,1]} \t| \t{_board.Table[2,2]}  \t|");
            Console.WriteLine("\t--------------------------------------------------------------------------");
            Console.WriteLine($"\tcolumn  | \t0 \t| \t1 \t| \t2  \t|");
            Console.WriteLine("\t--------------------------------------------------------------------------");
        }

        public static Position ReadPosition(string row, string column)
        {
            if (string.IsNullOrEmpty(row))
                throw new ArgumentNullException(nameof(row));

            if (string.IsNullOrEmpty(column))
                throw new ArgumentNullException(nameof(column));

            return new Position(int.Parse(row), int.Parse(column));
        }
    }
}