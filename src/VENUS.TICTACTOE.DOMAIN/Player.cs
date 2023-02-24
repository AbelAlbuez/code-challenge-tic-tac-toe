using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using VENUS.TICTACTOE.DOMAIN.Constants;

namespace VENUS.TICTACTOE.DOMAIN
{
    public class Player
    {
        public Position position { get; set; }
        public Names name { get; set; }

        public Player(Names name)
        {
            this.position = null;
            this.name = name;
        }
    }
}
