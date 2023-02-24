using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VENUS.TICTACTOE.DOMAIN.Constants;

namespace VENUS.TICTACTOE.DOMAIN
{
    public class PlayerO : Player
    {
        public PlayerO(Names name): base(name)
        {

        }

        public override string ToString()
        {
            return "O";
        }
    }
}
