namespace VENUS.TICTACTOE.UI
{
    using VENUS.TICTACTOE.DOMAIN;
    using VENUS.TICTACTOE.DOMAIN.Constants;

    internal class Program
    {

        static void Main(string[] args)
        {
            Match match = new Match();
            Canvas canvas = new Canvas(match.board);
            while (!match.GameOver)
            {
                try
                {

                    Console.WriteLine("\nTicTacToe GAME");
                    Console.WriteLine("The game is in process - {0} plays left", match.numberOfPlayLeft);
                    foreach (var movement in match.movements)
                    {
                        Console.WriteLine($"Player {movement.player.ToString()} - Moved row {movement.position.row} and column {movement.position.column}");
                    }
                    canvas.PrintBoard();
                    Console.WriteLine("\n");
                    Console.WriteLine("Waiting for player {0}", match.GetCurrentPlayer().ToString());
                    Console.WriteLine("In which row do you want to play?");
                    string row = Console.ReadLine();
                    Console.WriteLine("In which column do you want to play? ");
                    string column = Console.ReadLine();
                    Position position = canvas.ReadPosition(row, column);
                    match.MakeMove(position);
                    canvas.PrintBoard();
                    match.CheckWinner();
                    Console.WriteLine("\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}