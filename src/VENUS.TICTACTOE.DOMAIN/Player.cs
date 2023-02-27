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
        public Position Position { get; set; }
        public Names Name { get; set; }

        public Player(Names name)
        {
            this.Position = null;
            this.Name = name;
        }
    }
}
