using System.Text;

namespace Data_Structures_C_Sharp.DoublyLinked
{
    public class DoublyLinkedList
    {
        private Node Head { get; set; }
        private Node Tail { get; set; }

        public DoublyLinkedList()
        {
            this.Head = null;
            this.Tail = null;
        }

        /* Add a node as the Head of our DoublyLinkedList */
        public void Preppend(int value)
        {
            Node newNode = new Node(value);
            newNode.Next = this.Head;

            if (this.Head != null)
                this.Head.Previous = newNode;

            if (this.Tail == null) 
                this.Tail = newNode;

            this.Head = newNode;
        }

        /* Add a node at a set index of our DoublyLinkedList */
        public void Insert(int value, int index)
        {
            if (this.Head == null || index < 1) {
                Preppend(value);
                return;
            }

            Node newNode = new Node(value);

            Node current = this.Head;
            int count = 0;
            while (current.Next != this.Tail && ++count != index)
                current = current.Next;

            /* Connect newNode with its next */
            newNode.Next = current.Next;
            newNode.Next.Previous = newNode;

            /* Connect newNode with current */
            newNode.Previous = current;
            current.Next = newNode;
        }

        /* Add a node as the Tail of our DoublyLinkedList */
        public void Append(int value)
        {
            if (this.Head == null) {
                Preppend(value);
                return;
            }

            Node newNode = new Node(value);

            this.Tail.Next = newNode;
            newNode.Previous = this.Tail;

            this.Tail = newNode;
        }

        /* Delete a node from our DoublyLinkedList with a set value */
        public void Remove(int value)
        {
            if (this.Head == null) return;

            Node current = this.Head;

            while (current != this.Tail && current.Data != value)
                current = current.Next;

            if (current.Data == value) {
                Node toRemove = current;

                current.Previous.Next = current.Next;
                current.Next.Previous = current.Previous;
            }
        }

        /* Reverse our DoublyLinkedList */
        public DoublyLinkedList Reverse()
        {
            if (this.Head == null) return new DoublyLinkedList();

            DoublyLinkedList reversedList = new DoublyLinkedList();
            Node current = this.Tail;
            while (current != null) {
                reversedList.Append(current.Data);
                current = current.Previous;
            }

            return reversedList;
        }

        /* Print our DoublyLinkedList */
        public override string ToString()
        {
            if (this.Head == null) return "Empty DoublyLinkedList";

            // Create a StringBuilder to build the string, as strings are immutable
            StringBuilder sb = new StringBuilder();
            Node current = this.Head;

            while (current != null) {
                sb.Append($"{current.Data} -><- ");
                current = current.Next;
            }

            sb.Remove(sb.Length - 6, 6); // Remove the last " -><- " for printing purposes
            return sb.ToString();
        }
    }
}
