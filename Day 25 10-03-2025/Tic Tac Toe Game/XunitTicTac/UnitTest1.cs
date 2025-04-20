using Xunit;
using Tic_Tac_Toe_Game;

namespace XunitTicTac
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var checkwinner = new Game();
            bool result = checkwinner.IsWinner(MarkType.X);
            Assert.False(result);

            var 


        }
    }
}