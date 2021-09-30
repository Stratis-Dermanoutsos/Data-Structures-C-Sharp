using System;
using System.Text;

namespace Data_Structures_C_Sharp.AVL
{
    public class AVLTree
    {
        private Node Root { get; set; }

        #region Utility functions
        /* Compute the height of the Node specified */
        private int Height(Node root)
        {
            if (root == null)
                return 0;

            return root.Height;
        }

        /* Compute the balance factor of the Node specified */
        private int BalanceFactor(Node root)
        {
            if (root == null)
                return 0;

            return Height(root.LeftChild) - Height(root.RightChild);
        }

        /* Recursively finds and returns the node with the minimum value of the AVL Tree */
        private Node MinNode(Node root)
        {
            return (root == null) ? null : (root.LeftChild == null) ? root : MinNode(root.LeftChild);
        }
        #endregion

        #region Rotations
        /* Perform a right rotation of subtree rooted with root */
        private Node RightRotation(Node root)
        {
            Node newRoot = root.LeftChild;
            Node temp = newRoot.RightChild;

            /* Perform rotation */
            newRoot.RightChild = root;
            root.LeftChild = temp;

            /* Update heights */
            root.Height = Math.Max(Height(root.LeftChild), Height(root.RightChild)) + 1;
            newRoot.Height = Math.Max(Height(newRoot.LeftChild), Height(newRoot.RightChild)) + 1;

            return newRoot;
        }

        /* Perform a left rotation of subtree rooted with root */
        private Node LeftRotation(Node root)
        {
            Node newRoot = root.RightChild;
            Node temp = newRoot.LeftChild;

            /* Perform rotation */
            newRoot.LeftChild = root;
            root.RightChild = temp;

            /* Update heights */
            root.Height = Math.Max(Height(root.LeftChild), Height(root.RightChild)) + 1;
            newRoot.Height = Math.Max(Height(newRoot.LeftChild), Height(newRoot.RightChild)) + 1;

            return newRoot;
        }
        #endregion

        #region Insert
        /* Recursively adds a node with value <key> to the AVL Tree */
        private Node Insert(Node root, int key)
        {
            /* 1. Perform the normal BST insertion */
            if (root == null)
                root = new Node(key);

            if (key > root.Data)
                root.RightChild = Insert(root.RightChild, key);
            else if (key < root.Data)
                root.LeftChild = Insert(root.LeftChild, key);
            else // Prevent duplicate keys
                return root;

            /* 2. Update height of this ancestor node */
            root.Height = Math.Max(Height(root.LeftChild), Height(root.RightChild)) + 1;

            /* 3. Get the balance factor of this ancestor node to check whether this node became unbalanced */
            int balance = BalanceFactor(root);

            /* 4. If this node becomes unbalanced, then there are 4 cases */
            /* 4.1 Left Left Case */
            if (balance > 1 && key < root.LeftChild.Data)
                return RightRotation(root);

            /* 4.2 Right Right Case */
            if (balance < -1 && key > root.RightChild.Data)
                return LeftRotation(root);

            /* 4.3 Left Right Case */
            if (balance > 1 && key > root.LeftChild.Data) {
                root.LeftChild = LeftRotation(root.LeftChild);
                return RightRotation(root);
            }

            /* 4.4 Right Left Case */
            if (balance < -1 && key < root.RightChild.Data) {
                root.RightChild = RightRotation(root.RightChild);
                return LeftRotation(root);
            }

            return root;
        }

        /* Method to be called for insertion */
        public void Insert(int key)
        {
            this.Root = Insert(this.Root, key);
        }
        #endregion

        #region Remove
        /* Recursively removes the node with value <key> from the AVL Tree */
        public Node Remove(Node root, int key)
        {
            /* 1. Perform the normal BST removal */
            if (root == null)
                return root;

            if (key > root.Data)
                root.RightChild = Remove(root.RightChild, key);
            else if (key < root.Data)
                root.LeftChild = Remove(root.LeftChild, key);
            else {
                // Node with only one child or no child
                if (root.LeftChild == null)
                    return root.RightChild;
                else if (root.RightChild == null)
                    return root.LeftChild;

                int temp = root.Data;

                // Node with two children: Get the smallest in the right subtree
                root.Data = MinNode(root.RightChild).Data;

                // Remove the inorder successor
                root.RightChild = Remove(root.RightChild, temp);
            }

            // If the tree had only one node then return
            if (root == null)
                return root;

            /* 2. Update height of this ancestor node */
            root.Height = Math.Max(Height(root.LeftChild), Height(root.RightChild)) + 1;

            /* 3. Get the balance factor of this ancestor node to check whether this node became unbalanced */
            int balance = BalanceFactor(root);

            /* 4. If this node becomes unbalanced, then there are 4 cases */
            /* 4.1 Left Left Case */
            if (balance > 1 && BalanceFactor(root.LeftChild) >= 0)
                return RightRotation(root);

            /* 4.2 Right Right Case */
            if (balance < -1 && BalanceFactor(root.RightChild) <= 0)
                return LeftRotation(root);

            /* 4.3 Left Right Case */
            if (balance > 1 && BalanceFactor(root.LeftChild) < 0) {
                root.LeftChild = LeftRotation(root.LeftChild);
                return RightRotation(root);
            }

            /* 4.4 Right Left Case */
            if (balance < -1 && BalanceFactor(root.RightChild) > 0) {
                root.RightChild = RightRotation(root.RightChild);
                return LeftRotation(root);
            }

            return root;
        }

        /* Method to be called for removal */
        public void Remove(int key)
        {
            this.Root = Remove(this.Root, key);
        }
        #endregion

        #region Inorder Traversal
        /* Recursively traverses the AVL Tree */
        private string Inorder(Node root)
        {
            if (root == null)
                return string.Empty;

            StringBuilder result = new StringBuilder($"{Inorder(root.LeftChild)} {root.Data} {Inorder(root.RightChild)}");
            return result.ToString();
        }

        /* Method to be called for inorder traversal */
        public string Inorder()
        {
            return Inorder(this.Root);
        }
        #endregion

        #region Preorder Traversal
        /* Recursively traverses the AVL Tree */
        private string Preorder(Node root)
        {
            if (root == null)
                return string.Empty;

            StringBuilder result = new StringBuilder($"{root.Data} {Preorder(root.LeftChild)} {Preorder(root.RightChild)}");
            return result.ToString();
        }

        /* Method to be called for preorder traversal */
        public string Preorder()
        {
            return Preorder(this.Root);
        }
        #endregion

        #region Postorder Traversal
        /* Recursively traverses the AVL Tree */
        private string Postorder(Node root)
        {
            if (root == null)
                return string.Empty;

            StringBuilder result = new StringBuilder($"{Postorder(root.LeftChild)} {Postorder(root.RightChild)} {root.Data}");
            return result.ToString();
        }

        /* Method to be called for postorder traversal */
        public string Postorder()
        {
            return Postorder(this.Root);
        }
        #endregion

        #region Level Order Traversal
        /* Recursively prints a level of the AVL Tree */
        private string LevelOrderCurrentLevel(Node root, int level)
        {
            if (root == null)
                return string.Empty;

            if (level == 1)
                return $"{root.Data} ";
            else if (level > 1)
                return $"{LevelOrderCurrentLevel(root.LeftChild, level - 1)} {LevelOrderCurrentLevel(root.RightChild, level - 1)}";

            return string.Empty;
        }

        /* Method to be called for level order traversal */
        public string LevelOrder()
        {
            StringBuilder result = new StringBuilder();
            int h = this.Root.Height;

            for (int i = 1; i <= h; i++)
                result.Append(LevelOrderCurrentLevel(this.Root, i));

            return result.ToString();
        }
        #endregion

        public override string ToString()
        {
            return Inorder();
        }
    }
}