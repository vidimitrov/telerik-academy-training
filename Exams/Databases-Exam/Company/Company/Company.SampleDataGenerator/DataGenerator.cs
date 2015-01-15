namespace Company.SampleDataGenerator
{
    using Company.Data;
    using System;

    internal abstract class DataGenerator: IDataGenerator
    {
        private IRandomDataGenerator random;
        private CompanyEntities db;
        private int count;

        public DataGenerator(IRandomDataGenerator randomDataGenerator, 
            CompanyEntities companyEntities, int countOfGeneratedObjects)
        {
            this.random = randomDataGenerator;
            this.db = companyEntities;
            this.count = countOfGeneratedObjects;
        }

        protected IRandomDataGenerator Random
        {
            get { return this.random; }
        }

        protected CompanyEntities Database
        {
            get { return this.db; }
        }

        protected int Count
        {
            get { return this.count; }
        }

        public abstract void Generate();
    }
}
