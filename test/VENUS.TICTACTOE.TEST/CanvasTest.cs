using System.Numerics;
using VENUS.TICTACTOE.DOMAIN;
using VENUS.TICTACTOE.DOMAIN.Constants;

namespace VENUS.TICTACTOE.TEST
{
    public class CanvasTest
    {
       

        [Fact]
        public void ReadPosition_WhenRowIsEmpty_ThrowAnException()
        {
            Assert.Throws<ArgumentNullException>(() => Canvas.ReadPosition("", "1"));
        }

        [Fact]
        public void ReadPosition_WhenColumnIsEmpty_ThrowAnException()
        {
            Assert.Throws<ArgumentNullException>(() => Canvas.ReadPosition("1", ""));
        }

        [Fact]
        public void ReadPosition_WhenColumnAndRowAreValid_ReturnPosition()
        {
            var position = new Position(1, 0);
            var response = Canvas.ReadPosition("1", "0");
            Assert.Equal(position, response);
        }



    }
}