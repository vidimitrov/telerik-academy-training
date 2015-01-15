namespace _02.Minimum_Edit_Distance
{
    using System;
    using System.Text;

    internal class EntryPoint
    {
        private const double REPLACE_COST = 1;
        private const double DELETE_COST = 0.9;
        private const double INSERT_COST = 0.8;

        private static void Main()
        {
            Console.WriteLine("Please enter the initial word:");
            string initialWord = Console.ReadLine();
            Console.WriteLine("Please enter the target word:");
            string targetWord = Console.ReadLine();
 
            int[,] matrixOfLCS = BuildMatrixOfLongestCommonSet(targetWord, initialWord);
 
            PrintLCSMatrix(matrixOfLCS, targetWord, initialWord);
 
            double transformCost = CalcTransformCost(matrixOfLCS, targetWord, initialWord);
 
            Console.WriteLine("The transformation cost is: {0}", transformCost);
        }

        private static void PrintLCSMatrix(int[,] matrixOfLCS, string targetWord, string initialWord)
        {
            StringBuilder matrixToPrint = new StringBuilder();
 
            matrixToPrint.Append("      ");
 
            for (int i = 0; i < initialWord.Length; i++)
            {
                matrixToPrint.Append(initialWord[i] + ", ");
            }
 
            matrixToPrint.Length -= 2;
            matrixToPrint.AppendLine();
 
            for (int i = 0; i < matrixOfLCS.GetLength(0); i++)
            {
                if (i > 0)
                {
                    matrixToPrint.Append(targetWord[i - 1] + ": ");
                }
                else
                {
                    matrixToPrint.Append("   ");
                }
 
                for (int j = 0; j < matrixOfLCS.GetLength(1); j++)
                {
                    matrixToPrint.Append(matrixOfLCS[i, j] + ", ");
                }
 
                matrixToPrint.Length -= 2;
                matrixToPrint.AppendLine();
            }
 
            Console.WriteLine(matrixToPrint.ToString());
        }
 
        private static double CalcTransformCost(int[,] matrixOfLCS, string targetWord, string initialWord)
        {
            double transformCost = 0;
 
            int currentX = matrixOfLCS.GetLength(0) - 1;
            int currentY = matrixOfLCS.GetLength(1) - 1;
 
            while (currentX != 0 && currentY != 0)
            {
                if (targetWord[currentX - 1] == initialWord[currentY - 1])
                {
                    currentX--;
                    currentY--;
                }
                else if (matrixOfLCS[currentX - 1, currentY] == matrixOfLCS[currentX, currentY - 1])
                {
                    transformCost += REPLACE_COST;
                    currentX--;
                    currentY--;
                }
                else if (matrixOfLCS[currentX - 1, currentY] > matrixOfLCS[currentX, currentY - 1])
                {
                    transformCost += INSERT_COST;
                    currentX--;
                }
                else
                {
                    transformCost += DELETE_COST;
                    currentY--;
                }
            }
 
            if (currentX > 0)
            {
                transformCost += currentX * INSERT_COST;
            }
 
            if (currentY > 0)
            {
                transformCost += currentY * DELETE_COST;
            }
 
            return transformCost;
        }
 
        private static int[,] BuildMatrixOfLongestCommonSet(string targetWord, string initialWord)
        {
            int[,] matrixOfLCS = new int[targetWord.Length + 1, initialWord.Length + 1];
 
            for (int i = 1; i <= targetWord.Length; i++)
            {
                bool letterMatched = false;
                for (int j = 1; j <= initialWord.Length; j++)
                {
                    if ((!letterMatched) && (targetWord[i - 1] == initialWord[j - 1]))
                    {
                        matrixOfLCS[i, j] = matrixOfLCS[i, j - 1] + 1;
                        letterMatched = true;
                    }
                    else
                    {
                        matrixOfLCS[i, j] = Math.Max(matrixOfLCS[i - 1, j], matrixOfLCS[i, j - 1]);
                    }
                }
            }
 
            return matrixOfLCS;
        }
    }
}
