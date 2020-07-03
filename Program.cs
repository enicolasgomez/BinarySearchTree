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
      return null;
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
      return false;
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
        Console.WriteLine("found!");
      else
        Console.WriteLine("not found!");
      bool contains = tree.Contains(151);
      Console.WriteLine(contains);
      Console.ReadLine();
    }
  }
}
