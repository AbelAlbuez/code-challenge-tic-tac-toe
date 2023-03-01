namespace VENUS.TICTACTOE.DOMAIN
{
    using System;
    using VENUS.TICTACTOE.DOMAIN.Constants;

    public class Match
    {
        public Board board;
        public Names CurrentPlayer { get; set; }
        public int NumberOfPlayLeft = 9;
        public List<Movement> Movements = new List<Movement>();
        public bool GameOver = false; 
        public Match()
        {
            board = new Board(3, 3);
            CurrentPlayer = Names.X;
        }

        public Match(Board _board)
        {
            board = _board;
        }


        public void ChangePlayer() =>  CurrentPlayer = CurrentPlayer == Names.X ? Names.O : Names.X;

        public Player GetCurrentPlayer()
        {
            if (CurrentPlayer == Names.O)
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
            Movements.Add(new Movement(GetCurrentPlayer(), newPosition));
            NumberOfPlayLeft--;
            ChangePlayer();
        }

        public void SaveMovement(Movement movement)
        {
            Movements.Add(movement);
        }

        public void CheckWinner()
        {

            #region Horzontal Winning Condtion
            if ( board.GetAllPosition(0, 0) != null ) { 
                if(board.Table[0, 0] == board.Table[0, 1] && board.Table[0, 1]  == board.Table[0, 2])
                {
                    Console.WriteLine("The Player {0} is Winner", board.Table[0, 0]);
                    GameOver = true;
                }
            }

            if (board.GetAllPosition(1, 0) != null)
            {
                if (board.Table[1, 0] == board.Table[1, 1] && board.Table[1, 1] == board.Table[1, 2])
                {
                    Console.WriteLine("The Player {0} is Winner", board.Table[1, 0]);
                    GameOver = true;
                }
            }

            if (board.GetAllPosition(2, 0) != null)
            {
                if (board.Table[2, 0] == board.Table[2, 1] && board.Table[2, 1] == board.Table[2, 2])
                {
                    Console.WriteLine("The Player {0} is Winner", board.Table[2, 0]);
                    GameOver = true;
                }
            }

            #endregion
            #region Left Winning Condtion
            if (board.GetAllPosition(0, 0) != null)
            {
                if (board.Table[0, 0] == board.Table[1, 0] && board.Table[1, 0] == board.Table[2, 0])
                {
                    Console.WriteLine("The Player {0} is Winner", board.Table[0, 0]);
                    GameOver = true;
                }
            }
            #endregion
            #region Middle Winning Condition
            if (board.GetAllPosition(0, 1) != null)
            {
                if (board.Table[0, 1] == board.Table[1, 1] && board.Table[1, 1] == board.Table[2, 1])
                {
                    Console.WriteLine("The Player {0} is Winner", board.Table[0, 2]);
                    
                    GameOver = true;
                }
            }
            #endregion
            #region Right Winning Condition
            if (board.GetAllPosition(0, 2) != null)
            {
                if (board.Table[0, 2] == board.Table[1, 2] && board.Table[1, 2] == board.Table[2, 2])
                {
                    Console.WriteLine("The Player {0} is Winner", board.Table[0, 2]);
                    
                    GameOver = true;
                }
            }
            #endregion

            #region Diagonal Principal Winning Condition
            if (board.GetAllPosition(0, 0) != null)
            {
                if (board.Table[0, 0] == board.Table[1, 1] && board.Table[1, 1] == board.Table[2, 2])
                {
                    Console.WriteLine("The Player {0} is Winner", board.Table[0, 0]);
                    
                    GameOver = true;
                }
            }
            #endregion

            #region Anti Diagonal Winning Condition
            if (board.GetAllPosition(0, 2) != null)
            {
                if (board.Table[0, 2] == board.Table[1, 1] && board.Table[1, 1] == board.Table[2, 0])
                {
                    Console.WriteLine("The Player {0} is Winner", board.Table[0, 2]);
                    
                    GameOver = true;
                }
            }
            #endregion

            if (NumberOfPlayLeft == 0)
            {
                Console.WriteLine("GAME OVER");
                GameOver = true;
            }

        }
    }
}