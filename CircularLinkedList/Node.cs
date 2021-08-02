using System;

namespace Data_Structures_C_Sharp.CircularLinked
{
    public class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }

        public Node(int data)
        {
            this.Data = data;
            this.Next = null;
        }
    }
}
