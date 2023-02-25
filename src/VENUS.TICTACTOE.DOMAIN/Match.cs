namespace VENUS.TICTACTOE.DOMAIN
{
    using System;
    using VENUS.TICTACTOE.DOMAIN.Constants;

    public class Match
    {
        public Board board;
        public Names currentPlayer { get; set; }
        public int numberOfPlayLeft = 9;
        public List<Movement> movements = new List<Movement>();
        public bool GameOver = false; 
        public Match()
        {
            board = new Board(3, 3);
            currentPlayer = Names.O;
        }

        public void ChangePlayer()
        {
            if(currentPlayer == Names.X)
            {
                currentPlayer = Names.O;
            }
            else
            {
                currentPlayer = Names.X;
            }
        }

        public Player GetCurrentPlayer()
        {
            if (currentPlayer == Names.X)
            {
                return new PlayerO(Names.O);
            }
            else
            {
                return new PlayerX(Names.X);
            }
        }

        public void MakeMove(Position newPosition)
        {
          
            board.MovePlayerAt(GetCurrentPlayer(), newPosition);
            movements.Add(new Movement(GetCurrentPlayer(), newPosition));
            numberOfPlayLeft--;
            ChangePlayer();
        }

        public void SaveMovement(Movement movement)
        {
            movements.Add(movement);
        }

        public void CheckWinner()
        {

            #region Horzontal Winning Condtion
            if ( board.GetAllPosition(0, 0) != null ) { 
                if(board.board[0, 0] == board.board[0, 1] && board.board[0, 1]  == board.board[0, 2])
                {
                    Console.WriteLine("The Player {0} is Winner", board.board[0, 2]);
                    Console.Read();
                    GameOver = true;
                }
            }

            if (board.GetAllPosition(1, 0) != null)
            {
                if (board.board[1, 0] == board.board[1, 1] && board.board[1, 1] == board.board[1, 2])
                {
                    Console.WriteLine("The Player {0} is Winner", board.board[0, 2]);
                    Console.Read();
                    GameOver = true;
                }
            }

            if (board.GetAllPosition(2, 0) != null)
            {
                if (board.board[2, 0] == board.board[2, 1] && board.board[2, 1] == board.board[2, 2])
                {
                    Console.WriteLine("The Player {0} is Winner", board.board[0, 2]);
                    Console.Read();
                    GameOver = true;
                }
            }

            #endregion
            #region Left Winning Condtion
            if (board.GetAllPosition(0, 0) != null)
            {
                if (board.board[0, 0] == board.board[1, 0] && board.board[2, 1] == board.board[2, 2])
                {
                    Console.WriteLine("The Player {0} is Winner", board.board[0, 2]);
                    Console.Read();
                    GameOver = true;
                }
            }
            #endregion
            #region Middle Winning Condition
            if (board.GetAllPosition(0, 1) != null)
            {
                if (board.board[0, 1] == board.board[1, 1] && board.board[1, 1] == board.board[2, 1])
                {
                    Console.WriteLine("The Player {0} is Winner", board.board[0, 2]);
                    Console.Read();
                    GameOver = true;
                }
            }
            #endregion
            #region Right Winning Condition
            if (board.GetAllPosition(0, 2) != null)
            {
                if (board.board[0, 2] == board.board[1, 2] && board.board[1, 2] == board.board[2, 2])
                {
                    Console.WriteLine("The Player {0} is Winner", board.board[0, 2]);
                    Console.Read();
                    GameOver = true;
                }
            }
            #endregion
            #region Diagonal Winning Condition
            if (board.GetAllPosition(0, 2) != null)
            {
                if (board.board[0, 2] == board.board[1, 1] && board.board[1, 1] == board.board[2, 0])
                {
                    Console.WriteLine("The Player {0} is Winner", board.board[0, 2]);
                    Console.Read();
                    GameOver = true;
                }
            }
            #endregion

            #region Anti Diagonal Winning Condition
            if (board.GetAllPosition(2, 0) != null)
            {
                if (board.board[2, 0] == board.board[1, 1] && board.board[1, 1] == board.board[0, 2])
                {
                    Console.WriteLine("The Player {0} is Winner", board.board[0, 2]);
                    Console.Read();
                    GameOver = true;
                }
            }
            #endregion

            if (numberOfPlayLeft == 0)
            {
                Console.WriteLine("GAME OVER");
                GameOver = true;
            }

        }
    }
}