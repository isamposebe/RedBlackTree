﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassRB
{
    public enum Color
    {
        Red,
        Black
    }
    /// <summary>
    /// Object of type Node contains 4 properties
    /// Colour
    /// Left
    /// Right
    /// Parent
    /// Data
    /// </summary>
    public class Node : RB
    {
        public Color colour;

        public Node left;

        public Node right;

        public Node parent;

        public int data;


        public Node(int data) { this.data = data; }

        public Node(Color colour) { this.colour = colour; }

        public Node(int data, Color colour) { this.data = data; this.colour = colour; }

        public Node()
        {
        }

        /// <summary>
        ///     Отображение значения головы дерева
        /// </summary>
        /// <returns>Значение (data)</returns>
        public int СonclusionHeadTree()
        {
            return data;
        }
        
    }
    public class RB
    {



        /// <summary>
        /// Root node of the tree (both reference & pointer)
        /// </summary>
        private Node root;

        /// <summary>
        /// Новый экземпляр красно-черного объекта дерева
        /// </summary>
        public RB() { }


        /// <summary>
        ///     Провека на нахождение элемента
        /// </summary>
        /// <param name="elenent">Значения которое надо найти</param>
        /// <returns>Есть элемент или нету</returns>
        public bool CheckingElement(int elenent)
        {
            bool res = false;
            RB newRB = new RB();
            newRB.root = root;
            if (newRB.Find(elenent) != null)
            {
                res = true;
            }
            return res;
        }

        /// <summary>
        /// Влево вращаться
        /// </summary>
        /// <param name="X"></param>
        /// <returns>void</returns>
        private void LeftRotate(Node X)
        {
            Node Y = X.right; //установить y
            X.right = Y.left;//повернуть левое поддерево Y в правую поддерево X
            if (Y.left != null)
            {
                Y.left.parent = X;
            }
            if (Y != null)
            {
                Y.parent = X.parent;//Родитель ссылки X на Y
            }
            if (X.parent == null)
            {
                root = Y;

            }
            else if (X == X.parent.left)
            {
                X.parent.left = Y;
            }
            else
            {
                X.parent.right = Y;
            }

            Y.left = X; //put X on Y's left
            if (X != null)
            {
                X.parent = Y;
            }

        }

        /// <summary>
        /// Rotate Right
        /// </summary>
        /// <param name="Y"></param>
        /// <returns>void</returns>
        private void RightRotate(Node Y)
        {
            // right rotate is simply mirror code from left rotate
            Node X = Y.left;
            Y.left = X.right;
            if (X.right != null)
            {
                X.right.parent = Y;
            }
            if (X != null)
            {
                X.parent = Y.parent;
            }
            if (Y.parent == null)
            {
                root = X;
            }
            if (Y == Y.parent.right)
            {
                Y.parent.right = X;
            }
            if (Y == Y.parent.left)
            {
                Y.parent.left = X;
            }

            X.right = Y;//put Y on X's right
            if (Y != null)
            {
                Y.parent = X;
            }
        }

        /// <summary>
        /// Display Tree
        /// </summary>
        public void DisplayTree()
        {
            if (root == null)
            {
                Console.WriteLine("Nothing in the tree!");
                return;
            }
            if (root != null)
            {
                InOrderDisplay(root);
            }
        }

        /// <summary>
        /// Найдите элемент в дереве
        /// </summary>
        /// <param name="key">Значение элемента(data)</param>
        /// <returns>Элемент дерева(Null -> Элемент не найден)</returns>
        public Node Find(int key)
        {
            bool isFound = false;
            Node temp = root;
            Node item = null;
            while (!isFound)
            {
                if (temp == null)
                {
                    break;
                }
                if (key == temp.data)
                {
                    isFound = true;
                    item = temp;
                }
                if (key < temp.data)
                {
                    temp = temp.left;
                }
                if (key > temp.data)
                {
                    temp = temp.right;
                }
                //if (key != temp.data)
                //{
                //    break;
                //}

            }
            if (isFound)
            {
                Console.WriteLine("{0} was found", key);
                return temp;
            }
            else
            {
                Console.WriteLine("{0} not found", key);
                return null;
            }
        }
        /// <summary>
        /// Вставьте новый объект в дерево RB
        /// </summary>
        /// <param name="item"></param>
        public void Insert(int item)
        {
            Node newItem = new Node(item);
            if (root == null)
            {
                root = newItem;
                root.colour = Color.Black;
                return;
            }
            Node Y = null;
            Node X = root;
            while (X != null)
            {
                Y = X;
                if (newItem.data < X.data)
                {
                    X = X.left;
                }
                else
                {
                    X = X.right;
                }
            }
            newItem.parent = Y;
            if (Y == null)
            {
                root = newItem;
            }
            else if (newItem.data < Y.data)
            {
                Y.left = newItem;
            }
            else
            {
                Y.right = newItem;
            }
            newItem.left = null;
            newItem.right = null;
            newItem.colour = Color.Red;//colour the new node red
            InsertFixUp(newItem);//call method to check for violations and fix
        }

        private void InOrderDisplay(Node current)
        {
            if (current != null)
            {
                InOrderDisplay(current.left);
                Console.Write("({0}) ", current.data);
                InOrderDisplay(current.right);
            }
        }

        private void InsertFixUp(Node item)
        {
            //Checks Red-Black Tree properties
            while (item != root && item.parent.colour == Color.Red)
            {
                /*We have a violation*/
                if (item.parent == item.parent.parent.left)
                {
                    Node Y = item.parent.parent.right;
                    if (Y != null && Y.colour == Color.Red)//Case 1: uncle is red
                    {
                        item.parent.colour = Color.Black;
                        Y.colour = Color.Black;
                        item.parent.parent.colour = Color.Red;
                        item = item.parent.parent;
                    }
                    else //Case 2: uncle is black
                    {
                        if (item == item.parent.right)
                        {
                            item = item.parent;
                            LeftRotate(item);
                        }
                        //Case 3: recolour & rotate
                        item.parent.colour = Color.Black;
                        item.parent.parent.colour = Color.Red;
                        RightRotate(item.parent.parent);
                    }

                }
                else
                {
                    //mirror image of code above
                    Node X = null;

                    X = item.parent.parent.left;
                    if (X != null && X.colour == Color.Black)//Case 1
                    {
                        item.parent.colour = Color.Red;
                        X.colour = Color.Red;
                        item.parent.parent.colour = Color.Black;
                        item = item.parent.parent;
                    }
                    else //Case 2
                    {
                        if (item == item.parent.left)
                        {
                            item = item.parent;
                            RightRotate(item);
                        }
                        //Case 3: recolour & rotate
                        item.parent.colour = Color.Black;
                        item.parent.parent.colour = Color.Red;
                        LeftRotate(item.parent.parent);

                    }

                }
                root.colour = Color.Black;//re-colour the root black as necessary
            }
        }

        /// <summary>
        /// Deletes a specified value from the tree
        /// </summary>
        /// <param name="item"></param>
        public void Delete(int key)
        {
            //first find the node in the tree to delete and assign to item pointer/reference
            Node item = Find(key);
            Node X = null;
            Node Y = null;

            if (item == null)
            {
                Console.WriteLine("Nothing to delete!");
                return;
            }
            if (item.left == null || item.right == null)
            {
                Y = item;
            }
            else
            {
                Y = TreeSuccessor(item);
            }
            if (Y.left != null)
            {
                X = Y.left;
            }
            else
            {
                X = Y.right;
            }
            if (X != null)
            {
                X.parent = Y;
            }
            if (Y.parent == null)
            {
                root = X;
            }
            if (Y == Y.parent.left)
            {
                Y.parent.left = X;
            }
            else
            {
                Y.parent.left = X;
            }
            if (Y != item)
            {
                item.data = Y.data;
            }
            if (Y.colour == Color.Black)
            {
                DeleteFixUp(X);
            }

        }

        /// <summary>
        /// Checks the tree for any violations after deletion and performs a fix
        /// </summary>
        /// <param name="X"></param>
        private void DeleteFixUp(Node X)
        {

            while (X != null && X != root && X.colour == Color.Black)
            {
                if (X == X.parent.left)
                {
                    Node W = X.parent.right;
                    if (W.colour == Color.Red)
                    {
                        W.colour = Color.Black; //case 1
                        X.parent.colour = Color.Red; //case 1
                        LeftRotate(X.parent); //case 1
                        W = X.parent.right; //case 1
                    }
                    if (W.left.colour == Color.Black && W.right.colour == Color.Black)
                    {
                        W.colour = Color.Red; //case 2
                        X = X.parent; //case 2
                    }
                    else if (W.right.colour == Color.Black)
                    {
                        W.left.colour = Color.Black; //case 3
                        W.colour = Color.Red; //case 3
                        RightRotate(W); //case 3
                        W = X.parent.right; //case 3
                    }
                    W.colour = X.parent.colour; //case 4
                    X.parent.colour = Color.Black; //case 4
                    W.right.colour = Color.Black; //case 4
                    LeftRotate(X.parent); //case 4
                    X = root; //case 4
                }
                else //mirror code from above with "right" & "left" exchanged
                {
                    Node W = X.parent.left;
                    if (W.colour == Color.Red)
                    {
                        W.colour = Color.Black;
                        X.parent.colour = Color.Red;
                        RightRotate(X.parent);
                        W = X.parent.left;
                    }
                    if (W.right.colour == Color.Black && W.left.colour == Color.Black)
                    {
                        W.colour = Color.Black;
                        X = X.parent;
                    }
                    else if (W.left.colour == Color.Black)
                    {
                        W.right.colour = Color.Black;
                        W.colour = Color.Red;
                        LeftRotate(W);
                        W = X.parent.left;
                    }
                    W.colour = X.parent.colour;
                    X.parent.colour = Color.Black;
                    W.left.colour = Color.Black;
                    RightRotate(X.parent);
                    X = root;
                }
            }
            if (X != null)
                X.colour = Color.Black;
        }

        private Node Minimum(Node X)
        {
            while (X.left.left != null)
            {
                X = X.left;
            }
            if (X.left.right != null)
            {
                X = X.left.right;
            }
            return X;
        }

        private Node TreeSuccessor(Node X)
        {
            if (X.left != null)
            {
                return Minimum(X);
            }
            else
            {
                Node Y = X.parent;
                while (Y != null && X == Y.right)
                {
                    X = Y;
                    Y = Y.parent;
                }
                return Y;
            }
        }
    }
}
