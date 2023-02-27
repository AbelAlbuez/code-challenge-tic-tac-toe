using VENUS.TICTACTOE.DOMAIN;

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
    }
}