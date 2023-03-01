using System.Numerics;
using VENUS.TICTACTOE.DOMAIN;
using VENUS.TICTACTOE.DOMAIN.Constants;

namespace VENUS.TICTACTOE.TEST
{
    public class MatchTest
    {
        [Fact]
        public void MakeMove_WhenMakeAPlay_PlayerChange()
        {
            Match match = new Match();
            var initialPlayer = match.CurrentPlayer;
            match.MakeMove(new Position(0, 1));
            var currentPlayer = match.CurrentPlayer;
            Assert.NotEqual(initialPlayer, currentPlayer);
        }

        [Fact]
        public void MakeMove_WhenPlayerMoveToPosition_DecreasedNumberOfPlaysLeft()
        {
            Match match = new Match();
            var initialNumberOfPlayLeft = match.NumberOfPlayLeft;
            match.MakeMove(new Position(0, 1));
            Assert.NotEqual(initialNumberOfPlayLeft, match.NumberOfPlayLeft);
        }

        [Fact]
        public void MakeMove_WhenPlayerMoveToPosition_SaveMovement()
        {
            Match match = new Match();
            var initialPlayer = match.CurrentPlayer;
            var positionToMove = new Position(0, 1);
            match.MakeMove(positionToMove);
            Assert.Equal(positionToMove, match.Movements[0].position);
            Assert.Equal(initialPlayer.ToString(), match.Movements[0].player.ToString());
        }

        [Fact]
        public void MakeMove_WhenPlayerMoveToOccupiedPosition_ThrowAnException()
        {
            Match match = new Match();
            var initialPlayer = match.CurrentPlayer;
            match.MakeMove(new Position(0, 1));
            var ex = Assert.Throws<ArgumentException>(() => match.MakeMove(new Position(0, 1)));
            Assert.Equal(ex.Message, $"Player {match.CurrentPlayer.ToString()}: Cannot move to an occupied Position");
            Assert.Equal(Names.O, match.CurrentPlayer);
        }

        [Fact]
        public void MakeMove_WhenPlayerMoveOutOfBoard_ThrowAnException()
        {
            Match match = new Match();
            var ex = Assert.Throws<ArgumentException>(() => match.MakeMove(new Position(5, 1)));
            Assert.Equal(ex.Message, $"Invalid move: Cannot move to a Position off the Table.");
            Assert.Equal(Names.X, match.CurrentPlayer);
        }

        #region CheckWinner Validation
        [Fact]
        public void CheckWinner_WhenNumberOfPlayLeftIsZero_GameOverIsTrue()
        {
            var match = new Match();
            match.MakeMove(new Position(0, 0));
            match.CheckWinner();
            match.MakeMove(new Position(0, 1));
            match.CheckWinner();
            match.MakeMove(new Position(0, 2));
            match.CheckWinner();
            match.MakeMove(new Position(1, 1));
            match.CheckWinner();
            match.MakeMove(new Position(1, 0));
            match.CheckWinner();
            match.MakeMove(new Position(1, 2));
            match.CheckWinner();
            match.MakeMove(new Position(2, 0));
            match.CheckWinner();
            match.MakeMove(new Position(2, 1));
            match.CheckWinner();
            match.MakeMove(new Position(2, 2));
            match.CheckWinner();
            Assert.True(match.GameOver);
            Assert.Equal(0, match.NumberOfPlayLeft);
        }

    
        [Theory]
        [MemberData(nameof(Positions))]

        public void CheckWinner_WhenHaveAlWinner_GameOverIsTrue(Position first, Position second, Position third, Position fourth, Position fifth)
        {
            var match = new Match();
            match.MakeMove(first);
            match.MakeMove(second);
            match.MakeMove(third);
            match.MakeMove(fourth);
            match.MakeMove(fifth);

            match.CheckWinner();
            Assert.True(match.GameOver);
        }

        public static IEnumerable<Position[]> Positions =>
          new List<Position[]>
          {
            // Horzontal Winning Condtion
            new Position[] { new Position(0, 0), new Position(1, 0),  new Position(0, 1), new Position(2, 1), new Position(0, 2)},
            new Position[] { new Position(1, 0), new Position(2, 0),  new Position(1, 1), new Position(2, 1), new Position(1, 2)},
            new Position[] { new Position(2, 0), new Position(0, 1),  new Position(2, 1), new Position(1, 1), new Position(2, 2)},
            // Left Winning Condtion
            new Position[] { new Position(0, 0), new Position(1, 1),  new Position(1, 0), new Position(2, 2), new Position(2, 0)},
            // Middle Winning Condition
            new Position[] { new Position(0, 1), new Position(0, 0),  new Position(1, 1), new Position(2, 2), new Position(2, 1)},
            // Right Winning Condition
            new Position[] { new Position(0, 2), new Position(1, 1),  new Position(1, 2), new Position(0, 0), new Position(2, 2)},
            // Anti Diagonal Winning Condition
            new Position[] { new Position(0, 2), new Position(2, 1),  new Position(1, 1), new Position(0, 0), new Position(2, 0)},
            // Principal Diagonal Winning Condition
            new Position[] { new Position(0, 0), new Position(2, 0),  new Position(1, 1), new Position(0, 2), new Position(2, 2)},
          };

        #endregion
    }
}