﻿using System;
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
        public string[,] board { get; set; }

        public Board(int Rows, int Columns)
        {
            this.Rows = Rows;
            this.Columns = Columns;
            this.board = new string[Rows, Columns];
        }

        public string GetPosition(Position position)
        {
            InsideOfBoard(position);
            return board[position.row, position.column];
        }

        public string GetAllPosition(int Rows, int Columns)
        {
            if(string.IsNullOrWhiteSpace(board[Rows, Columns]))
            {
                return null;
            }

            return board[Rows, Columns];
        }

        public bool PositionIsAvailable(Position position)
        {
            return !string.IsNullOrWhiteSpace(GetPosition(position));
        }
        public bool IsOutOfBoard(Position position)
        {
            if (position.row < 0 || position.row >= Rows || position.column < 0 || position.column >= Columns)
            {
                return false;
            }
            return true;
        }


        public void MovePlayerAt(Player player, Position position)
        {
            if (PositionIsAvailable(position))
            {
               throw new Exception($"Player {player.ToString()}: Cannot move to an occupied position");
            }
            else
            {
                board[position.row, position.column] = player.ToString();
                player.position = position;
            }
        }

        public void InsideOfBoard(Position position)
        {
            if (!IsOutOfBoard(position))
            {
                throw new Exception($"Invalid move: Cannot move to a position off the board.");
            }
        }
    }
}
