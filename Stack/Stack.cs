using System.Text;

namespace Data_Structures_C_Sharp.Stacks
{
    public class Stack
    {
        public Node Top { get; private set; }

        public Stack()
        {
            this.Top = null;
        }

        /* Check if Stack is empty */
        public bool IsEmpty()
        {
            return this.Top == null;
        }

        /* Add a node as the Top of our Stack */
        public void Push(int value)
        {
            Node newNode = new Node(value);
            newNode.Next = this.Top;
            this.Top = newNode;
        }

        /* Remove the Top Node of our Stack */
        public Node Pop()
        {
            if (IsEmpty()) return null;

            Node temp = this.Top;
            this.Top = this.Top.Next;

            return temp;
        }

        /* Print our Stack */
        public override string ToString()
        {
            if (IsEmpty()) return "Empty Stack.";

            // Create a StringBuilder to build the string, as strings are immutable
            StringBuilder sb = new StringBuilder();
            Node current = this.Top;

            while (current != null) {
                sb.Append($"{current.Data} -> ");
                current = current.Next;
            }

            sb.Remove(sb.Length - 4, 4); // Remove the last " -> " for printing purposes
            return sb.ToString();
        }
    }
}