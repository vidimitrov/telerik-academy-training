namespace _11.LinkedList
{
    using System;
    using System.Collections.Generic;

    class EntryPoint
    {
        static void Main(string[] args)
        {
            ListItem<int> endItem = new ListItem<int>(5);
            ListItem<int> middleItem = new ListItem<int>(124, endItem);
            ListItem<int> startItem = new ListItem<int>(12, middleItem);

            LinkedList<int> linkedList = new LinkedList<int>(startItem);
        }
    }
}
