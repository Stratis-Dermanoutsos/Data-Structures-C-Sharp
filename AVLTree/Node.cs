namespace Data_Structures_C_Sharp.AVL
{
    public class Node
    {
        public int Data { get; set; }
        public int Height { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }

        public Node(int data)
        {
            this.Data = data;
            this.Height = 1;
            this.LeftChild = null;
            this.RightChild = null;
        }
    }
}