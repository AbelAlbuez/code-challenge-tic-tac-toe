using VENUS.TICTACTOE.DOMAIN;
using VENUS.TICTACTOE.DOMAIN.Constants;

namespace VENUS.TICTACTOE.TEST
{
    public class MatchTest
    {
        [Fact]
        public void ChangePlayer_WhenMakeAPlay_PlayerChange()
        {
            Match match = new Match();
            var initialPlayer = match.CurrentPlayer;
            match.MakeMove(new Position(0, 1));
            var currentPlayer = match.CurrentPlayer;
            Assert.NotEqual(initialPlayer, currentPlayer);
        }

        #region CheckWinner Validation
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
            // Diagonal Winning Condition
            new Position[] { new Position(0, 2), new Position(2, 1),  new Position(1, 1), new Position(0, 0), new Position(2, 0)},
            // Anti Diagonal Winning Condition
            new Position[] { new Position(2, 0), new Position(2, 1),  new Position(1, 1), new Position(0, 0), new Position(0, 2)},
           };

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

       
        #endregion
    }
}