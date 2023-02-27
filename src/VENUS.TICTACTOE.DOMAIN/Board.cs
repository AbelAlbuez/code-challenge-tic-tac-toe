using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace VENUS.TICTACTOE.DOMAIN
{
    public class Board
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public string[,] Table { get; set; }

        public Board(int Rows, int Columns)
        {
            this.Rows = Rows;
            this.Columns = Columns;
            this.Table = new string[Rows, Columns];
        }

        public string GetPosition(Position position)
        {
            InsideOfBoard(position);
            return Table[position.Row, position.Column];
        }

        public string GetAllPosition(int Rows, int Columns)
        {
            if (string.IsNullOrWhiteSpace(Table[Rows, Columns]))
            {
                return null;
            }

            return Table[Rows, Columns];
        }

        public bool PositionIsAvailable(Position position) => string.IsNullOrWhiteSpace(GetPosition(position));

        public bool IsOutOfBoard(Position position)
        {
            if (position.Row < 0 || position.Row >= Rows || position.Column < 0 || position.Column >= Columns)
            {
                return false;
            }
            return true;
        }


        public void MovePlayerAt(Player player, Position position)
        {
            if (!PositionIsAvailable(position))
                throw new Exception($"Player {player.ToString()}: Cannot move to an occupied Position");

            Table[position.Row, position.Column] = player.ToString();
            player.Position = position;
        }

        public void InsideOfBoard(Position position)
        {
            if (!IsOutOfBoard(position))
            {
                throw new Exception($"Invalid move: Cannot move to a Position off the Table.");
            }
        }
    }
}
