using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace _8puzzle
{
    public partial class Form1 : Form
    {
        List<Node> path = new List<Node>();
        int stateNumber = 0;
        public Form1()
        {
            InitializeComponent();
        }


        private void btn_solve_Click(object sender, EventArgs e)
        {
            stateNumber = 0;
            path.Clear();
            this.lb_amountStep.Text = "Step";
            int[,] stateDes = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
            int[,] stateStart = new int[3, 3];
            string[] operations = { "up", "down", "left", "right" };
            string nameLabel = "label";

            for (int i = 0; i < 9; i++)
            {
                if (this.Controls.Find(nameLabel + (i + 1).ToString(), true)[0].Text != "") stateStart[(i / 3), (i % 3)] = Convert.ToInt32(this.Controls.Find(nameLabel + (i + 1).ToString(), true)[0].Text);
                else stateStart[(i / 3), (i % 3)] = 0;
            }

            Node nodeDes = new Node(stateDes);
            Node nodeStart = new Node(stateStart, 0);
            Node currentNode = new Node();
            Node childNode = new Node();


            nodeStart.Hx = operation.caculateHeuristic(nodeDes, nodeStart);
            List<Node> listNode = new List<Node>();
            List<Node> closedNode = new List<Node>();
            listNode.Add(nodeStart);
            while (listNode.Count != 0)
            {
                currentNode = listNode[0];
                closedNode.Add(currentNode);
                listNode.RemoveAt(0);
                Console.WriteLine(closedNode.Count);
                if (currentNode.equal(nodeDes)) break;
                for (int i = 0; i < 4; i++)
                {
                    childNode = operation.move(currentNode, operations[i]);
                    if (childNode != null)
                    {
                        if (!operation.checkList(childNode, closedNode) && !operation.checkList(childNode, listNode))
                        {
                            childNode.Hx = operation.caculateHeuristic(nodeDes, childNode);
                            listNode.Add(childNode);
                            listNode.Sort(delegate (Node a, Node b)
                            {
                                if ((a.Hx + a.Gx) > (b.Hx + b.Gx)) return 1;
                                if ((a.Hx + a.Gx) == (b.Hx + b.Gx)) return 0;
                                return -1;
                            });
                        }
                    }
                }
            }
            operation.path(currentNode, path);
            this.lb_amountStep.Text = (stateNumber + 1).ToString() + "/" + path.Count.ToString();
            for (int i = 0; i < 9; i++)
            {
                if(path[stateNumber].State[(i / 3), (i % 3)] != 0) this.Controls.Find(nameLabel + (i + 1).ToString(), true)[0].Text = path[stateNumber].State[(i / 3), (i % 3)].ToString();
                else this.Controls.Find(nameLabel + (i + 1).ToString(), true)[0].Text = "";
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (stateNumber >= path.Count - 2)
            {
                this.btn_next.Enabled = false;
            }
            stateNumber++;
            this.lb_amountStep.Text = (stateNumber+1).ToString() + "/" + path.Count.ToString();
            string nameLabel = "label";
            for (int i = 0; i < 9; i++)
            {
                if (path[stateNumber].State[(i / 3), (i % 3)] != 0) this.Controls.Find(nameLabel + (i + 1).ToString(), true)[0].Text = path[stateNumber].State[(i / 3), (i % 3)].ToString();
                else this.Controls.Find(nameLabel + (i + 1).ToString(), true)[0].Text = "";
            }
            this.btn_pre.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_mix_Click(object sender, EventArgs e)
        {
            this.btn_pre.Enabled = false;
            this.btn_next.Enabled = false;
            stateNumber = 0;
            path.Clear();
            this.lb_amountStep.Text = "Step";
            int[] array = Enumerable.Range(0, 9).ToArray();

            // Tạo đối tượng Random
            Random rand = new Random();

            // Xáo trộn mảng
            for (int i = 0; i < array.Length; i++)
            {
                // Chọn một chỉ số ngẫu nhiên
                int j = rand.Next(i, array.Length);

                // Hoán đổi phần tử tại vị trí i và vị trí j
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
            string nameLabel = "label";
            // In ra mảng sau khi đã xáo trộn
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != 0) this.Controls.Find(nameLabel + (i + 1).ToString(), true)[0].Text = array[i].ToString();
                else this.Controls.Find(nameLabel + (i + 1).ToString(), true)[0].Text = "";
            }

        }

        private void btn_pre_Click(object sender, EventArgs e)
        {
            if (stateNumber <= 1)
            {
                this.btn_pre.Enabled = false;
            }
            string nameLabel = "label";
            stateNumber--;
            this.lb_amountStep.Text = (stateNumber + 1).ToString() + "/" + path.Count.ToString();
            for (int i = 0; i < 9; i++)
            {
                if (path[stateNumber].State[(i / 3), (i % 3)] != 0) this.Controls.Find(nameLabel + (i + 1).ToString(), true)[0].Text = path[stateNumber].State[(i / 3), (i % 3)].ToString();
                else this.Controls.Find(nameLabel + (i + 1).ToString(), true)[0].Text = "";
            }
            this.btn_next.Enabled = true;
        }
    }
}

