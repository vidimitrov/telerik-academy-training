using System;

public class SimpleMathExam : Exam
{
    public int ProblemsSolved { get; private set; }

    public SimpleMathExam(int problemsSolved)
    {
        if (problemsSolved < 0)
        {
            problemsSolved = 0;
        }
        if (problemsSolved > 10)
        {
            problemsSolved = 10;
        }

        this.ProblemsSolved = problemsSolved;
    }

    public override ExamResult Check()
    {
        if (ProblemsSolved == 0)
        {
            var result = new ExamResult(2, 2, 6, "Bad result: nothing done.");

            return result;
        }
        else if (ProblemsSolved == 1)
        {
            var result = new ExamResult(4, 2, 6, "Average result: nothing done.");

            return result;
        }
        else if (ProblemsSolved == 2)
        {
            var result = new ExamResult(6, 2, 6, "Average result: nothing done.");

            return result;
        }

        return new ExamResult(0, 0, 0, "Invalid number of problems solved!");
    }
}
