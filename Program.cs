using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace BinaryTrees
{
  class Node
  {
    public int Data { get;  }
    public Node Left;
    public Node Right;
    public Node(int v) => Data = v;

    public void Print(string indent, bool last)
    {
      Console.Write(indent);
      if (last)
      {
        Console.Write("└─");
        indent += "  ";
      }
      else
      {
        Console.Write("├─");
        indent += "| ";
      }
      Console.WriteLine(Data);

      var children = new List<Node>();
      if (this.Left != null)
        children.Add(this.Left);
      if (this.Right != null)
        children.Add(this.Right);

      for (int i = 0; i < children.Count; i++)
        children[i].Print(indent, i == children.Count - 1);
    }
  }

  class BinaryTree
  {
    Node root;

    public BinaryTree( int[] values )
    {
      root = new Node(values[0]);
      for ( int i = 1; i < values.Length; i ++ )
        Add(root, values[i]);
    }

    public BinaryTree(Node r) => root = r;
    public void Print()
    {
      root.Print("", true);
    }
    //trasverse recursevily from top to bottom and find location
    private void Add( Node n, int v )
    {
      if ( v < n.Data )
      {
        if (n.Left == null)
          n.Left = new Node(v);
        else
          Add(n.Left, v);
      }
      else
      {
        if (n.Right == null)
          n.Right = new Node(v);
        else
          Add(n.Right, v);
      }
    }

    public int[] ToOrderedArray()
    {
      List<int> v = new List<int>();
      ToOrderedArray(root, v);
      return v.ToArray();
    }

    public void ToOrderedArray(Node node, List<int> v)
    {
      if (node.Left != null)
        ToOrderedArray(node.Left, v);
      v.Add(node.Data);
      if (node.Right != null)
        ToOrderedArray(node.Right, v);
    }

    public bool Contains(int v)
    {
      return Contains(root, v);
    }

    public bool Contains(Node n, int v)
    {
      if (n != null)
      {
        if (n.Data == v) return true;
        if (v < n.Data)
          return Contains(n.Left, v);
        else
          return Contains(n.Right, v);
      }

      return false;
    }

    public Node Find(int v)
    {
      return Find(root, v);
    }

    public Node Find(Node n, int v)
    {
      if (n != null)
      {
        if (n.Data == v ) return n;
        if (v < n.Data)
          return Find(n.Left, v);
        else
          return Find(n.Right, v);
      }

      return null;
    }

    public void Insert(int v)
    {

    }

    public void Delete(int v )
    {

    }

    public bool IsBinarySearchTree()
    {
      bool valid = true; 
      IsBinarySearchTree(root, ref valid );
      return valid;
    }
    public void IsBinarySearchTree(Node n, ref bool valid )
    {
      if ( ( valid ) && ( n != null ) )
      {
        if ((n.Left != null) && (n.Left.Data > n.Data))
          valid = false;
        if ((n.Right != null) && (n.Right.Data < n.Data))
          valid = false;

        if ( valid )
        {
          IsBinarySearchTree(n.Left, ref valid);
          IsBinarySearchTree(n.Right, ref valid);
        }
      }
    }
    public int Count()
    {
      int t = 1; //starting element
      CountRecursive(root, ref t);
      return t;
    }

    public void CountRecursive(Node root, ref int t)
    {
      if (root.Left != null)
      {
        t++;
        CountRecursive(root.Left, ref t);
      }
      if (root.Right != null)
      {
        t++;
        CountRecursive(root.Right, ref t);
      }
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      int[] treeValues = { 10, 5, 15, 7, 2, 9, 31 };
      BinaryTree tree = new BinaryTree(treeValues);
      tree.Print();
      Node node = tree.Find(151);
      if ( node != null )
        Console.WriteLine("found! data: " + node.Data );
      else
        Console.WriteLine("not found!");
      bool contains = tree.Contains(151);
      Console.WriteLine(contains);
      bool valid = tree.IsBinarySearchTree();
      Console.WriteLine("Is Valid " + valid);
      Console.WriteLine("Total nodes " + tree.Count());
      Console.WriteLine("Ordered array " + tree.ToOrderedArray());
      //invalid tree
      Node root = new Node(5);
      root.Left = new Node(2);
      root.Right = new Node(7);
      root.Right.Left = new Node(9);
      root.Right.Right = new Node(1);
      BinaryTree otherTree = new BinaryTree(root);
      otherTree.Print();
      bool otherValid = otherTree.IsBinarySearchTree();
      Console.WriteLine("Is Valid " + otherValid);
      Console.WriteLine("Total nodes " + otherTree.Count());
      Console.WriteLine("Ordered array " + otherTree.ToOrderedArray());
      Console.ReadLine();
    }
  }
}
