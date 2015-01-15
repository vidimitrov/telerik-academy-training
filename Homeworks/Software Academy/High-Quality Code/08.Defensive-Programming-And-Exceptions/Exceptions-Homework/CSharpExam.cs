using System;

public class CSharpExam : Exam
{
    public int Score { get; private set; }

    public CSharpExam(int score)
    {
        if (score < 0)
        {
            throw new ArgumentException("The score cannot be less than zero!");
        }

        this.Score = score;
    }

    public override ExamResult Check()
    {
        if (Score < 0 || Score > 100)
        {
            throw new ArgumentOutOfRangeException("Scores cannot be less than 0 and greater than 100!");
        }
        else
        {
            var results = new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
            return results;
        }
    }
}
