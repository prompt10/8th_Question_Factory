using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _8th_Question_Factory
{
    class Node
    {
        public char line;
        public int Countdown;
        public Node Next;

        public Node(int CountdownValue, char lineValue)
        {
            Countdown = CountdownValue;
            line = lineValue;
        }
    }

    class Queue
    {
        private Node Root;
        public void Push(Node node)
        {
            if (Root == null)
            {
                Root = node;
            }
            else
            {
                Node ptr = Root;
                while (ptr.Next != null)
                {
                    ptr = ptr.Next;
                }
                ptr.Next = node;
            }
        }

        public Node Pop()
        {
            if (Root == null)
            {
                return null;
            }
            Node node = Root;
            Root = Root.Next;
            node.Next = null;
            return node;
        }
    }

    class Program
    {
        static char GetNextRay(char line)
        {
            switch (line)
            {
                case 'A':
                    return 'B';
                case 'B':
                    return 'C';
                case 'C':
                    return 'D';
                case 'D':
                    return 'E';
                case 'E':
                    return 'A';
                default:
                    return '?';
            }
        }
        static void Main(string[] args)
        {
            Queue pieceQueue = new Queue();
            char line;
            int Countdown;
            while (true)
            {
                Countdown = int.Parse(Console.ReadLine());
                if (Countdown < 0)
                {
                    break;
                }
                line = char.Parse(Console.ReadLine());
                Node piece = new Node(Countdown, line);
                pieceQueue.Push(piece);
            }

            Node CountdownPiece;
            while (true)
            {
                CountdownPiece = pieceQueue.Pop();
                if (CountdownPiece == null)
                {
                    break;
                }
                Console.Write(CountdownPiece.line);
                if (CountdownPiece.Countdown > 1)
                {   Node childPiece1 = new Node(CountdownPiece.Countdown - 1, GetNextRay(CountdownPiece.line));
                    Node childPiece2 = new Node(CountdownPiece.Countdown - 1, GetNextRay(CountdownPiece.line));
                    pieceQueue.Push(childPiece1);
                    pieceQueue.Push(childPiece2);
                }
            }
        }
    }
}