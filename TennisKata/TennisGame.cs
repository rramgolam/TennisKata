using System;

namespace TennisKata
{
    public class TennisGame
    {
        private int playerOneScore;
        private int playerTwoScore;

        public TennisGame()
        {
            playerOneScore = 0;
            playerTwoScore = 0;
        }

        public string getScore()
        {
            if (isEqualScore())
            {
                if (playerOneScore > 3)
                {
                    return "deuce";
                }
                return getScoreName(playerOneScore) + "-all";
            }
            else
            {
                if (playerOneScore >= 4 || playerTwoScore >= 4)
                {
                    string score;

                    int minusResult = playerOneScore - playerTwoScore;
                    if (minusResult == 1)
                    {
                        score = "advantage player one";
                    } else if (minusResult == -1)
                    {
                        score = "advantage player two";
                    } else if (minusResult >= 2)
                    {
                        score = "player one wins";
                    }
                    else
                    {
                        score = "player two wins";
                    }
                    return score;
                }
                return getScoreName(playerOneScore) + "-" + getScoreName(playerTwoScore);
            }
        }

        public string getScoreName(int score)
        {
            switch (score)
            {
                case 0:
                    return "love";
                case 1:
                    return "fifteen";
                case 2:
                    return "thirty";
                case 3:
                    return "forty";
                default:
                    return "";
            }
        }

        private Boolean isEqualScore()
        {
            return playerOneScore == playerTwoScore;
        }

        public void playerOneScored()
        {
            playerOneScore++;
        }
        public void playerTwoScored()
        {
            playerTwoScore++;
        }
    }
}
