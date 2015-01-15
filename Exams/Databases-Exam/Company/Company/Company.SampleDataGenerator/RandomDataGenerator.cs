namespace Company.SampleDataGenerator
{
    using System;

    internal class RandomDataGenerator: IRandomDataGenerator
    {
        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private static IRandomDataGenerator randomDataGenerator;
        private Random random;

        private RandomDataGenerator()
        {
            this.random = new Random();
        }

        public static IRandomDataGenerator Instance 
        { 
            get
            {
                if (randomDataGenerator == null)
                {
                    randomDataGenerator = new RandomDataGenerator();
                }

                return randomDataGenerator;
            }
        }

        public int GetRandomNumber(int min, int max)
        {
            return this.random.Next(min, max + 1);
        }

        public string GetRandomString(int length)
        {
            var result = new char[length];

            for (int i = 0; i < length; i++)
            {
                int randomLetterIndex = this.GetRandomNumber(0, Letters.Length - 1);
                result[i] = Letters[randomLetterIndex];
            }

            return new string(result);
        }

        public string GetRandomStringWithRandomLength(int min, int max)
        {
            return this.GetRandomString(this.GetRandomNumber(min, max));
        }

        public DateTime GetRandomDate()
        {
            DateTime start = new DateTime(1995, 1, 1);

            int range = (DateTime.Today - start).Days;  
         
            return start.AddDays(this.random.Next(range));
        }

        public DateTime GetRandomDate(DateTime startDate)
        {
            DateTime endDate = new DateTime(2020, 1, 1);

            int range = (endDate - startDate).Days;  
         
            return startDate.AddDays(this.random.Next(range));
        }
    }
}
