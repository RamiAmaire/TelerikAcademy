using System;

public class ExamResult
{
    #region Fields and contructors
    private int score = 0;
    private int minScore = 0;
    private int maxScore = 0;
    private string comments = string.Empty;

    public ExamResult(int score, int minScore, int maxScore, string comments)
    {
        this.MaxScore = maxScore;
        this.MinScore = minScore;
        this.Score = score;
        this.Comments = comments;
    }
    #endregion

    #region Properties
    public int Score 
    {
        get
        {
            return this.score;
        }

        private set
        {
            if (value < this.minScore || value > this.maxScore)
            {
                throw new ArgumentOutOfRangeException(
                    "Score " + this.score + " is out of range (" + this.minScore + "-" + this.maxScore + ")");
            }

            this.score = value;
        }
    }

    public int MinScore 
    {
        get
        {
            return this.minScore;
        }

        private set
        {
            if (value < 0 || value > this.maxScore)
            {
                throw new ArgumentOutOfRangeException(
                   "Minimum score " +
                   this.minScore +
                   " is out of range (" +
                   0 +
                   "-" +
                   this.maxScore +
                   ")");
            }

            this.minScore = value;
        }
    }

    public int MaxScore 
    {
        get
        {
            return this.maxScore;
        }

        private set
        {
            if (value < minScore || value > int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(
                   "Maximum score " +
                   this.maxScore +
                   " is out of range (" +
                   minScore +
                   "-" +
                   int.MaxValue +
                   ")");
            }

            this.maxScore = value;
        }
    }

    public string Comments 
    {
        get
        {
            return this.comments;
        }

        private set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Comments cannot be null");
            }

            this.comments = value;
        }
    }
    #endregion
}
