using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VENUS.TICTACTOE.DOMAIN.Constants;

namespace VENUS.TICTACTOE.DOMAIN
{
    public class PlayerX : Player
    {
        public PlayerX(Names name): base(name)
        {

        }

        public override string ToString()
        {
            return "X";
        }
    }
}
