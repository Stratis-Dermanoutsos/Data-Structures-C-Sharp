using System.Text;

namespace Data_Structures_C_Sharp.Q
{
    public class Queue
    {
        public Node Front { get; private set; }
        public Node Rear { get; private set; }

        public Queue()
        {
            this.Front = null;
            this.Rear = null;
        }

        /* Add a node to our Queue */
        public void Enqueue(int value)
        {
            Node newNode = new Node(value);
            
            if (this.Rear != null)
                this.Rear.Next = newNode;

            this.Rear = newNode;

            if (this.Front == null)
                this.Front = newNode;
        }

        /* Remove a node from our Queue */
        public Node Dequeue()
        {
            if (this.Front == null) return null;

            Node toRemove = this.Front;
            this.Front = this.Front.Next;

            return toRemove;
        }

        /* Print our Queue */
        public override string ToString()
        {
            if (this.Front == null) return "Empty Queue";

            // Create a StringBuilder to build the string, as strings are immutable
            StringBuilder sb = new StringBuilder("Front: ");
            Node current = this.Front;

            while (current != null) {
                sb.Append($"{current.Data} -> ");
                current = current.Next;
            }

            sb.Remove(sb.Length - 4, 4); // Remove the last " -> " for printing purposes
            sb.Append(": Rear");
            return sb.ToString();
        }
    }
}