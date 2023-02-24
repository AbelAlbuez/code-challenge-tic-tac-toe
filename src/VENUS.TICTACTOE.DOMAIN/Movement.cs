using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VENUS.TICTACTOE.DOMAIN
{
    public class Movement
    {
        public Player player { get; set; }
        public Position position { get; set; }
        public Movement(Player player, Position position)
        {
            this.player = player;
            this.position = position;
        }
    }
}
