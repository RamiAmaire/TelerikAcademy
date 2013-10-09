using System;

public class SimpleMathExam : Exam
{
    #region Constants, fields and constructors
    const int MAXIMUM_PROBLEMS = 3;
    const int MINIMUM_PROBLEMS = 0;

    private int problemsSolved = 0;

    public SimpleMathExam(int problemsSolved)
    {
        this.ProblemsSolved = problemsSolved;
    }
    #endregion

    #region Properties
    public int ProblemsSolved 
    {
        get
        {
            return this.problemsSolved;
        }

        private set
        {
            if (value < MINIMUM_PROBLEMS || value > MAXIMUM_PROBLEMS)
            {
                throw new ArgumentOutOfRangeException(
                    "The number of problems solved must be between (" +
                    MAXIMUM_PROBLEMS +
                    "-" +
                    MAXIMUM_PROBLEMS +
                    ")");
            }

            this.problemsSolved = value;
        }
    }
    #endregion

    #region Methods
    public override ExamResult Check()
    {
        if (ProblemsSolved == 1)
        {
            return new ExamResult(3, 2, 6, "Low result: only one problem solved.");
        }

        if (ProblemsSolved == 2)
        {
            return new ExamResult(4, 2, 6, "Average result: two problems solved.");
        }

        if (ProblemsSolved == 3)
        {
            return new ExamResult(6, 2, 6, "High result: all problems solved.");
        }

        return new ExamResult(2, 2, 6, "Poor result: no problems solved");
    }
    #endregion
}
