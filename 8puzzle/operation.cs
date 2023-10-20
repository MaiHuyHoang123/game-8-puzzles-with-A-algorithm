using System;
using System.Collections.Generic;

namespace _8puzzle
{
    internal class operation
    {
        public static Node move(Node node, string operation)
        {
            int[] blankPos = node.getBlankPos();
            if (string.Equals(operation, "up", StringComparison.OrdinalIgnoreCase))
            {
                if (blankPos[0] == 0)
                {
                    return null;
                }
                else
                {
                    return swap(node, blankPos[0] - 1, blankPos[1]);
                }
            }
            if (string.Equals(operation, "down", StringComparison.OrdinalIgnoreCase))
            {
                if (blankPos[0] == 2)
                {
                    return null;
                }
                else
                {
                    return swap(node, blankPos[0] + 1, blankPos[1]);
                }
            }
            if (string.Equals(operation, "left", StringComparison.OrdinalIgnoreCase))
            {
                if (blankPos[1] == 0)
                {
                    return null;
                }
                else
                {
                    return swap(node, blankPos[0], blankPos[1] - 1);
                }
            }
            if (string.Equals(operation, "right", StringComparison.OrdinalIgnoreCase))
            {
                if (blankPos[1] == 2)
                {
                    return null;
                }
                else
                {
                    return swap(node, blankPos[0], blankPos[1] + 1);
                }
            }
            return null;
        }
        
        public static int caculateHeuristic(Node nodeDes, Node nodeCurrent)
        {
            int hx = 0, rowDes = 0, columnDes = 0, rowCurrent = 0, columnCurrent = 0;
            for (int k = 1; k < 9; k++)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (nodeDes.State[i, j] == k)
                        {
                            rowDes = i;
                            columnDes = j;
                        }
                        if (nodeCurrent.State[i, j] == k)
                        {
                            rowCurrent = i;
                            columnCurrent = j;
                        }
                    }
                }
                hx += (Math.Abs(rowDes - rowCurrent) + Math.Abs(columnDes - columnCurrent));
            }
            return hx;
        }
 
/*
        public static int caculateHeuristic(Node nodeDes, Node nodeCurrent)
        {
            int hx = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (nodeDes.State[i, j] != nodeCurrent.State[i, j])
                    {
                        hx++;
                    }
                }
            }
            return hx;
        }
*/
        public static Node swap(Node node, int NewRowOfBlank, int NewColumnOfBlank)
        {
            int[] blankPos = node.getBlankPos();
            Node newNode = node.deepClone();
            newNode.State[blankPos[0], blankPos[1]] = node.State[NewRowOfBlank, NewColumnOfBlank];
            newNode.State[NewRowOfBlank, NewColumnOfBlank] = 0;
            newNode.getBlankPos();
            newNode.ParentNode = node;
            newNode.Gx += 1;
            return newNode;
        }
        public static void path(Node node, List<Node> Path)
        {
            if (node.ParentNode != null)
                path(node.ParentNode, Path);
            Path.Add(node);
            displayNode(node);

        }
        public static void displayNode(Node node)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(node.State[i, j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("----------------------");
        }
        public static bool checkList(Node currentNode, List<Node> list)
        {
            foreach (Node node in list)
            {
                if (node.equal(currentNode)) return true;
            }
            return false;
        }
    }
}
