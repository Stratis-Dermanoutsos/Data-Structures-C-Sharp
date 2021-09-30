using System.Text;

namespace Data_Structures_C_Sharp.BST
{
    public class BinarySearchTree
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

        #region Preorder Traversal
        /* Recursively traverses the Binary Search Tree */
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
        /* Recursively traverses the Binary Search Tree */
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
        /* Recursively prints a level of the Binary Search Tree */
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

        /* Compute the height of the Binary Search Tree */
        private int Height(Node root)
        {
            if (root == null)
                return 0;

            /* Compute height of each subtree */
            int leftHeight = Height(root.LeftChild);
            int rightHeight = Height(root.RightChild);
            
            /* Use the larger one */
            return ((leftHeight > rightHeight) ? leftHeight : rightHeight) + 1;
        }

        /* Method to be called for level order traversal */
        public string LevelOrder()
        {
            StringBuilder result = new StringBuilder();
            int h = Height(this.Root);

            for (int i = 1; i <= h; i++)
                result.Append(LevelOrderCurrentLevel(this.Root, i));

            return result.ToString();
        }
        #endregion

        #region Invert the Tree
        private void Invert(Node root)
        {
            if (root == null)
                return;

            Node temp = root.RightChild;
            root.RightChild = root.LeftChild;
            root.LeftChild = temp;

            Invert(root.LeftChild);

            Invert(root.RightChild);
        }

        public void Invert()
        {
            Invert(this.Root);
        }
        #endregion

        public override string ToString()
        {
            return Inorder();
        }
    }
}
