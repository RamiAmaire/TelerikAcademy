using System;

public class CSharpExam : Exam
{
    #region Constants, fields and constructors
    const int MIN_SCORE = 0;
    const int MAX_SCORE = 100;
    
    private int score = 0;

    public CSharpExam(int score)
    {
        this.Score = score;
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
            if (value < 0 || value > MAX_SCORE)
            {
                throw new ArgumentOutOfRangeException(
                    "Score " + value + " is out of range (" + MIN_SCORE + "-" + MAX_SCORE + ")");
            }

            this.score = value;
        }
    }
    #endregion

    #region Methods
    public override ExamResult Check()
    {
        ExamResult result = new ExamResult(this.Score, 0, 100, "C# exam results calculated by score.");
        return result;
    }
    #endregion
}
