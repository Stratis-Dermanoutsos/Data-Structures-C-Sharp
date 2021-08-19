using System;
using Data_Structures_C_Sharp.SinglyLinked;
using Data_Structures_C_Sharp.DoublyLinked;
using Data_Structures_C_Sharp.CircularLinked;
using Data_Structures_C_Sharp.Q;
using Data_Structures_C_Sharp.Stacks;
using Data_Structures_C_Sharp.BST;

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
            Console.WriteLine(queue.Dequeue().Data + " dequeued from queue.");
            queue.Dequeue();
            Console.WriteLine($"Queue: {queue}");

            Console.WriteLine(Environment.NewLine);

            Stack stack = new Stack();
            stack.Push(3);
            stack.Push(5);
            stack.Push(7);
            Console.WriteLine(stack.IsEmpty() ? "Stack is empty" : "Stack is not empty");
            stack.Push(11);
            stack.Push(13);
            stack.Push(17);
            Console.WriteLine(stack.Top.Data + " peeked from stack.");
            Console.WriteLine(stack.Pop().Data + " popped from stack.");
            stack.Pop();
            Console.WriteLine($"Stack: {stack}");

            Console.WriteLine(Environment.NewLine);

            BinarySearchTree bst = new BinarySearchTree();
            bst.Insert(50);
            bst.Insert(30);
            bst.Insert(20);
            bst.Insert(40);
            bst.Insert(70);
            bst.Insert(60);
            bst.Insert(80);
            bst.Remove(60);
            bst.Remove(30);
            Console.WriteLine($"Value 40 was {((bst.Search(40) == null) ? "not " : string.Empty)}found.");
            Console.WriteLine($"Value 30 was {((bst.Search(30) == null) ? "not " : string.Empty)}found.");
            Console.WriteLine($"Binary Search Tree (inorder): {bst}");
            Console.WriteLine($"Binary Search Tree (preorder): {bst.Preorder()}");
            Console.WriteLine($"Binary Search Tree (postorder): {bst.Postorder()}");
            Console.WriteLine($"Binary Search Tree (level order): {bst.LevelOrder()}");
        }
    }
}
