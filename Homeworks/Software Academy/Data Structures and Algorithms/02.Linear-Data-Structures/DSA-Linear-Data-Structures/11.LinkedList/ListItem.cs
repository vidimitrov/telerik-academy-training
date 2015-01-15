namespace _11.LinkedList
{
    public class ListItem<T>
    {
        private T value;
        private ListItem<T> nextItem;


        public ListItem(T value, ListItem<T> item = null)
        {
            this.Value = value;
            this.NextItem = item;
        }

        public T Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
            }
        }

        public ListItem<T> NextItem
        {
            get
            {
                return this.nextItem.MemberwiseClone() as ListItem<T>;
            }
            set
            {
                this.nextItem = value;
            }
        }
    }
}
