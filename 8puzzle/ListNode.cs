using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8puzzle
{
    internal class ListNode
    {
        private List<Node> nodes = new List<Node>();

        public ListNode()
        {
        }

        public List<Node> Nodes { get => nodes; set => nodes = value; }

        public ListNode(List<Node> nodes)
        {
            this.nodes = nodes;
        }

    }
}
