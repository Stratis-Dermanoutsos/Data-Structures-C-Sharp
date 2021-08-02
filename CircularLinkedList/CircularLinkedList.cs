using System.Text;

namespace Data_Structures_C_Sharp.CircularLinked
{
    public class CircularLinkedList
    {
        private Node Head { get; set; }

        public CircularLinkedList()
        {
            this.Head = null;
        }

        /* Add a node as the Head of our CircularLinkedList */
        public void Preppend(int value)
        {
            Node newNode = new Node(value);
            newNode.Next = this.Head;
            this.Head = newNode;

            /* Create the circular link */
            if (this.Head.Next != null) {
                Node current = this.Head.Next;
                while (current.Next != null && current.Next != this.Head.Next)
                    current = current.Next;

                current.Next = this.Head;
            }
        }

        /* Add a node at a set index of our SinglyLinkedList */
        public void Insert(int value, int index)
        {
            if (this.Head == null || index < 1) {
                Preppend(value);
                return;
            }

            Node newNode = new Node(value);

            Node current = this.Head;
            int count = 0;
            while (current.Next != this.Head && ++count != index)
                current = current.Next;

            newNode.Next = current.Next;
            current.Next = newNode;
        }

        /* Add a node at the end of our CircularLinkedList */
        public void Append(int value)
        {
            if (this.Head == null) {
                Preppend(value);
                return;
            }

            Node newNode = new Node(value);
            Node current = this.Head;
            while (current.Next != this.Head)
                current = current.Next;

            current.Next = newNode;
            newNode.Next = this.Head;
        }

        /* Delete a node from our CircularLinkedList with a set value */
        public void Remove(int value)
        {
            if (this.Head == null) return;

            Node current = this.Head;

            while (current.Next != this.Head && current.Next.Data != value)
                current = current.Next;

            if (current.Next.Data == value) {
                Node toRemove = current.Next;
                current.Next = toRemove.Next;

                if (toRemove == this.Head)
                    this.Head = toRemove.Next;
            }
        }

        /* Print our CircularLinkedList */
        public override string ToString()
        {
            if (this.Head == null) return "Empty CircularLinkedList";

            // Create a StringBuilder to build the string, as strings are immutable
            StringBuilder sb = new StringBuilder($"{this.Head.Data} -> ");
            Node current = this.Head.Next;

            do {
                sb.Append($"{current.Data} -> ");
                current = current.Next;
            } while (current != this.Head.Next);

            sb.Remove(sb.Length - 4, 4); // Remove the last " -> " for printing purposes
            return sb.ToString();
        }
    }
}
