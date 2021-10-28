using NUnit.Framework;

namespace TennisKata.Tests
{
    public class Tests
    {
        private TennisGame game;
        
        [SetUp]
        public void Setup()
        {
            game = new TennisGame();
        }

        [Test]
        public void WhenTwoPlayersStartATennisGameThenBothScoresAreZero()
        {
            string expectedResult = "love-all";

            game = new TennisGame();
            string result = game.getScore();

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void WhenTwoPlayersHaveBothScoredOnceThenReturnFifteenAll()
        {
            string expectedResult = "fifteen-all";

            game = new TennisGame();
            game.playerOneScored();
            game.playerTwoScored();

            string result = game.getScore();

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void WhenTwoPlayersHaveBothScoredTwiceThenReturnThirtyAll()
        {
            string expectedResult = "thirty-all";

            game = new TennisGame();
            game.playerOneScored();
            game.playerOneScored();
            game.playerTwoScored();
            game.playerTwoScored();

            string result = game.getScore();

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void WhenTwoPlayersHaveBothScoredThreeTimesThenReturnFourtyAll()
        {
            string expectedResult = "forty-all";

            game = new TennisGame();
            game.playerOneScored();
            game.playerOneScored();
            game.playerOneScored();

            game.playerTwoScored();
            game.playerTwoScored();
            game.playerTwoScored();

            string result = game.getScore();

            Assert.AreEqual(expectedResult, result);
        }

        [Test]
        public void WhenTwoPlayersHaveBothScoredFourTimesThenReturnDeuce()
        {
            string expectedResult = "deuce";

            game = new TennisGame();
            game.playerOneScored();
            game.playerOneScored();
            game.playerOneScored();
            game.playerOneScored();
            game.playerTwoScored();
            game.playerTwoScored();
            game.playerTwoScored();
            game.playerTwoScored();
            
            string result = game.getScore();

            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(1, 0, "fifteen-love")]
        [TestCase(0, 1, "love-fifteen")]
        // TODO Iterate to ALL permutations
        [TestCase(5, 0, "player one wins")]
        [TestCase(0, 5, "player two wins")]
        [TestCase(4, 3, "advantage player one")]
        [TestCase(3, 4, "advantage player two")]
        public void ParameterizedTestingOfPlayerScoresToResult(int playerOneScore, int playerTwoScore,
            string expectedResult)
        {
            game = new TennisGame();
            for (int i = 0; i < playerOneScore; i++)
            {
                game.playerOneScored();
            }
            for (int i = 0; i < playerTwoScore; i++)
            {
                game.playerTwoScored();
            }

            string result = game.getScore();

            Assert.AreEqual(expectedResult, result);
        }
    }
}