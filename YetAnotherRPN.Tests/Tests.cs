namespace YetAnotherRPN.Tests
{
    [TestClass]
    public class Tests
    {
        private bool ParsingTest(string expression, string[] parsed) => 
            new Solver().Parse(expression).ToArray().SequenceEqual(parsed);


        [TestMethod]
        public void ParsingTests()
        {
            Assert.IsTrue(ParsingTest("11 2+5*", ["11", "2", "+", "5", "*"]));
            Assert.IsTrue(ParsingTest("2 2 + 3 -", ["2", "2", "+", "3", "-"]));
            Assert.IsTrue(ParsingTest("123 512 * 913 / 19 + 76", 
                ["123", "512", "*", "913", "/", "19", "+", "76"]));
            Assert.IsTrue(ParsingTest("- + * /", ["-", "+", "*", "/"]));
        }


        private bool SolvingTest(string expression, float result) =>
            new Solver().Solve(expression).Equals(result);


        [TestMethod]
        public void SolvingTests()
        {
            Assert.IsTrue(SolvingTest("11 2+5*", 65));
            Assert.IsTrue(SolvingTest("2 2 + 3 -", 1));
            Assert.IsTrue(SolvingTest("1 2 +3 * 6-4/", 0.75f));
            Assert.IsTrue(SolvingTest("4 8 - 2 * 5 +", -3));
        }
    }
}
