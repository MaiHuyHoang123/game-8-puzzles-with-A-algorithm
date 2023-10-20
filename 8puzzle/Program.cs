using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace _8puzzle
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
            /*
            int[,] stateDes = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            int[,] stateStart = new int[3, 3] { { 8, 4, 3 }, { 2, 1, 0 }, { 6, 5, 7 } };
            string[] operations = { "up", "down", "left", "right" };

            Node nodeDes = new Node(stateDes);
            Node nodeStart = new Node(stateStart, 0);
            Node currentNode = new Node();
            Node childNode = new Node();
            nodeStart.Hx = operation.caculateHeuristic(nodeDes, nodeStart);
            List<Node> listNode = new List<Node>();
            listNode.Add(nodeStart);
            while (listNode.Count != 0)
            {
                currentNode = listNode[0];
                listNode.RemoveAt(0);
                if (currentNode.equal(nodeDes)) break;
                for (int i = 0; i < 4; i++)
                {
                    childNode = operation.move(currentNode, operations[i]);
                    if (childNode != null)
                    {
                        childNode.Hx = operation.caculateHeuristic(nodeDes, childNode);
                        listNode.Add(childNode);
                        listNode.Sort(delegate(Node a,Node b)
                        {
                            if ((a.Hx + a.Gx) > (b.Hx + b.Gx)) return 1;
                            if ((a.Hx + a.Gx) == (b.Hx + b.Gx)) return 0;
                            return -1;
                        });
                    }
                }
            }
            operation.path(currentNode);
            */
        }
    }
}
