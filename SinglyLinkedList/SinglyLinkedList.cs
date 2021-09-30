using System.Text;

namespace Data_Structures_C_Sharp.SinglyLinked
{
    public class SinglyLinkedList
    {
        private Node Head { get; set; }

        public SinglyLinkedList()
        {
            this.Head = null;
        }

        /* Add a node as the Head of our SinglyLinkedList */
        public void Preppend(int value)
        {
            Node newNode = new Node(value);
            newNode.Next = this.Head;
            this.Head = newNode;
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
            while (current.Next != null && ++count != index)
                current = current.Next;

            newNode.Next = current.Next;
            current.Next = newNode;
        }

        /* Add a node at the end of our SinglyLinkedList */
        public void Append(int value)
        {
            if (this.Head == null) {
                Preppend(value);
                return;
            }

            Node newNode = new Node(value);
            Node current = this.Head;
            while (current.Next != null)
                current = current.Next;

            current.Next = newNode;
        }

        /* Delete a node from our SinglyLinkedList with a set value */
        public void Remove(int value)
        {
            if (this.Head == null) return;

            Node current = this.Head;

            while (current.Next != null && current.Next.Data != value)
                current = current.Next;

            if (current.Next != null) {
                Node toRemove = current.Next;
                current.Next = toRemove.Next;
            }
        }

        /* Print our SinglyLinkedList */
        public override string ToString()
        {
            if (this.Head == null) return "Empty SinglyLinkedList";

            // Create a StringBuilder to build the string, as strings are immutable
            StringBuilder sb = new StringBuilder();
            Node current = this.Head;

            while (current != null) {
                sb.Append($"{current.Data} -> ");
                current = current.Next;
            }

            sb.Remove(sb.Length - 4, 4); // Remove the last " -> " for printing purposes
            return sb.ToString();
        }
    }
}
