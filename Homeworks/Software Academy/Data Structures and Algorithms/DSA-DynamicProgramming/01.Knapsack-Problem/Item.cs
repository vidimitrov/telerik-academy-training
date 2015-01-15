namespace _01.Knapsack_Problem
{
    public struct Item
    {
        public Item(string name, int weight, int value) : this()
        {
            this.Name = name;
            this.Weight = weight;
            this.Value = value;
        }

        public string Name { get; private set; }

        public int Weight { get; private set; }

        public int Value { get; private set; }
    }
}
