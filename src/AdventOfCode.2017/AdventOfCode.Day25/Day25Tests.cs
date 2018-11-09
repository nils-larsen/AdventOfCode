using Xunit;

namespace AdventOfCode.Day25
{
    public class TuringTests
    {
        readonly Turing _turing;

        public TuringTests()
        {
            _turing = new Turing();
        }

        [Fact]
        public void Part1_GetResult()
        {
            var actual = _turing.Solve(12425180);

            Assert.Equal(3099, actual);
        }
    }

}
