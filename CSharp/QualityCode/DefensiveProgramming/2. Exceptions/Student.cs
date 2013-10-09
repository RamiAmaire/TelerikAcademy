using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    #region Fields and constructors
    private string firstName = string.Empty;
    private string lastName = string.Empty;
    private IList<Exam> exams = new List<Exam>();

    public Student(string firstName, string lastName, IList<Exam> exams)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }
    #endregion

    #region Properties
    public string FirstName 
    {
        get
        {
            return this.firstName;
        }

        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("First name cannot be null.");
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }

        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Last name cannot be null.");
            }

            this.lastName = value;
        }
    }

    public IList<Exam> Exams
    {
        get
        {
            return this.exams;
        }

        set
        {
            if (value == null)
            {
                throw new ArgumentNullException("Exam list cannot be null.");
            }

            if (value.Count == 0)
            {
                throw new ArgumentNullException("Exam list must containt atleast one exam.");
            }

            this.exams = value;
        }
    }
    #endregion

    #region Methods
    public IList<ExamResult> CheckExams()
    {
        IList<ExamResult> results = new List<ExamResult>();
        for (int i = 0; i < this.Exams.Count; i++)
        {
            results.Add(this.Exams[i].Check());
        }

        return results;
    }

    public double CalcAverageExamResultInPercents()
    {
        double[] examScore = new double[this.Exams.Count];
        IList<ExamResult> examResults = this.CheckExams();

        for (int i = 0; i < examResults.Count; i++)
        {
            examScore[i] = 
                ((double)examResults[i].Score - examResults[i].MinScore) / 
                (examResults[i].MaxScore - examResults[i].MinScore);
        }

        return examScore.Average();
    }
    #endregion
}
