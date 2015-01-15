namespace _11.LinkedList
{
    public class LinkedList<T>
    {
        private ListItem<T> firstElement;

        public LinkedList(ListItem<T> element)
        {
            this.FirstElement = element;
        }

        public ListItem<T> FirstElement
        {
            get 
            { 
                return this.firstElement; 
            }
            set 
            { 
                this.firstElement = value; 
            }
        }
    }
}
