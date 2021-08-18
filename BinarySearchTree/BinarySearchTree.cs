using System.Text;

namespace Data_Structures_C_Sharp.BST
{
    class BinarySearchTree
    {
        private Node Root { get; set; }

        public BinarySearchTree()
        {
            this.Root = null;
        }

        #region Insert
        /* Recursively adds a node with value <key> to the Binary Search Tree */
        private Node Insert(Node root, int key)
        {
            if (root == null)
                root = new Node(key);
            else if (key > root.Data)
                root.RightChild = Insert(root.RightChild, key);
            else if (key < root.Data)
                root.LeftChild = Insert(root.LeftChild, key);

            return root;
        }

        /* Method to be called for insertion */
        public void Insert(int key)
        {
            this.Root = Insert(this.Root, key);
        }
        #endregion

        #region Search
        /* Recursively searches for the specified node in the Binary Search Tree */
        private Node Search(Node root, int key)
        {
            // Base Cases: root is null or key is present at root
            if (root == null || root.Data == key)
                return root;

            // Key is greater than root's key
            if (root.Data < key)
                return Search(root.RightChild, key);

            // Key is smaller than root's key
            return Search(root.LeftChild, key);
        }

        /* Method to be called for searching */
        public Node Search(int key)
        {
            return Search(this.Root, key);
        }
        #endregion

        #region Remove
        /* Recursively removes the node with value <key> from the Binary Search Tree */
        public Node Remove(Node root, int key)
        {
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

                // Node with two children: Get the smallest in the right subtree
                root.Data = Min(root.RightChild).Data;

                // Remove the inorder successor
                root.RightChild = Remove(root.RightChild, root.Data);
            }

            return root;
        }

        /* Method to be called for removal */
        public void Remove(int key)
        {
            this.Root = Remove(this.Root, key);
        }
        #endregion

        #region Minimum value
        /* Recursively finds and returns the node with the minimum value of the Binary Search Tree */
        Node Min(Node root)
        {
            return (root == null) ? null : (root.LeftChild == null) ? root : Min(root.LeftChild);
        }
        #endregion

        #region Inorder Traversal
        /* Recursively traverses the Binary Search Tree */
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

        public override string ToString()
        {
            return Inorder();
        }
    }
}
