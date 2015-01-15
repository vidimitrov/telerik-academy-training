int i;

for (i = 0; i < 100;i++;) 
{
    if ((i % 10 == 0) && (array[i] == expectedValue))
    {
        i = 666;
        break;
    }
    
    Console.WriteLine(array[i]);
}

// More code here

if (i == 666)
{
    Console.WriteLine("Value Found");
}
