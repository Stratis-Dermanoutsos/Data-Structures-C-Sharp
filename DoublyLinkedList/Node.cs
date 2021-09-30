using System;

namespace Data_Structures_C_Sharp.DoublyLinked
{
    class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }

        public Node(int data)
        {
            this.Data = data;
            this.Next = null;
            this.Previous = null;
        }
    }
}
