using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VENUS.TICTACTOE.DOMAIN
{
    public class Board
    {
        public int rows { get; set; }
        public int columns { get; set; }
        public string[,] board { get; set; }

        public Board(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            this.board = new string[rows, columns];
        }

        public string getPosition(Position position)
        {
            InsideOfBoard(position);
            return board[position.row, position.column];
        }

        public string getAllPosition(int rows, int columns)
        {
            return board[rows, columns];
        }

        public bool positionIsAvailable(Position position)
        {
            return !string.IsNullOrWhiteSpace(getPosition(position));
        }
        public bool isOutOfBoard(Position position)
        {
            if (position.row < 0 || position.row >= rows || position.column < 0 || position.column >= columns)
            {
                return false;
            }
            return true;
        }


        public void MovePlayerAt(Player player, Position position)
        {
            if (positionIsAvailable(position))
            {
               Console.WriteLine("There is already a player in this position");
               Console.WriteLine("\n");
            }
            else
            {
                board[position.row, position.column] = player.ToString();
                player.position = position;
            }
        }

        public void InsideOfBoard(Position position)
        {
            if (!isOutOfBoard(position))
            {
                throw new Exception("Position is out of board");
            }
        }
    }
}
