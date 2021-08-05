using System;
using Data_Structures_C_Sharp.SinglyLinked;
using Data_Structures_C_Sharp.DoublyLinked;
using Data_Structures_C_Sharp.CircularLinked;
using Data_Structures_C_Sharp.Q;

namespace Data_Structures_C_Sharp
{
    class Playground
    {
        static void Main(string[] args)
        {
            SinglyLinkedList listSingle = new SinglyLinkedList();
            listSingle.Preppend(3);
            listSingle.Preppend(5);
            listSingle.Preppend(7);
            listSingle.Append(11);
            listSingle.Append(13);
            listSingle.Append(17);
            listSingle.Remove(3);
            listSingle.Insert(3, 3);
            listSingle.Preppend(9);
            Console.WriteLine($"Singly Linked List: {listSingle}");

            Console.WriteLine(Environment.NewLine);

            DoublyLinkedList listDouble = new DoublyLinkedList();
            listDouble.Preppend(3);
            listDouble.Preppend(5);
            listDouble.Preppend(7);
            listDouble.Append(11);
            listDouble.Append(13);
            listDouble.Append(17);
            listDouble.Remove(3);
            listDouble.Insert(3, 3);
            listDouble.Preppend(9);
            Console.WriteLine($"Doubly Linked List: {listDouble}");
            Console.WriteLine($"Doubly Linked List: {listDouble.Reverse()} (in reverse)");

            Console.WriteLine(Environment.NewLine);

            CircularLinkedList listCirce = new CircularLinkedList();
            listCirce.Preppend(3);
            listCirce.Preppend(5);
            listCirce.Preppend(7);
            listCirce.Append(11);
            listCirce.Append(13);
            listCirce.Append(17);
            listCirce.Remove(3);
            listCirce.Insert(3, 3);
            listCirce.Preppend(9);
            Console.WriteLine($"Circular Linked List: {listCirce}");

            Console.WriteLine(Environment.NewLine);

            Queue queue = new Queue();
            queue.Enqueue(3);
            queue.Enqueue(5);
            queue.Enqueue(7);
            queue.Enqueue(11);
            queue.Enqueue(13);
            queue.Enqueue(17);
            queue.Dequeue();
            queue.Dequeue();
            Console.WriteLine($"Queue: {queue}");
        }
    }
}
