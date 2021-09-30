namespace Data_Structures_C_Sharp.BST
{
    public class Node
    {
        public int Data { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }

        public Node(int data)
        {
            this.Data = data;
            this.LeftChild = null;
            this.RightChild = null;
        }
    }
}
