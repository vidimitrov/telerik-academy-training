public void PrintStatistics(double[] inputArray, int count)
{
    double max;
    for (int i = 0; i < count; i++)
    {
        if (inputArray[i] > max)
        {
            max = inputArray[i];
        }
    }
    
    PrintMax(max);
    
    double min = 0;
    for (int i = 0; i < count; i++)
    {
        if (inputArray[i] < min)
        {
            min = inputArray[i];
        }
    }
    
    PrintMin(min);

    double sum = 0;
    for (int i = 0; i < count; i++)
    {
        sum += inputArray[i];
    }
    
    PrintAvg(sum/count);
}
