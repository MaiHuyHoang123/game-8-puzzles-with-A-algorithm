namespace _8puzzle
{
    internal class Node
    {
        private int[,] state = new int[3,3];
        private int gx;
        private int hx;
        Node parentNode;

        public int[,] State { get => state; set => state = value; }
        public int Gx { get => gx; set => gx = value; }
        public int Hx { get => hx; set => hx = value; }
        internal Node ParentNode { get => parentNode; set => parentNode = value; }

        public Node(int[,] state)
        {
            this.State = state;
        }

        public Node(int[,] state, int gx, int hx)
        {
            this.State = state;
            this.Gx = gx;
            this.Hx = hx;
        }

        public Node(int[,] state, int gx)
        {
            this.State = state;
            this.gx = gx;
        }

        public Node()
        {
        }

        public bool equal(Node other)
        {
            string keyCurrent = "", keyDes = "";
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    keyCurrent += this.State[i, j].ToString();
                    keyDes += other.State[i, j].ToString();
                }
            }
            if (keyCurrent == keyDes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int getEvalue()
        {
            return this.Gx + this.Hx;
        }
        
        public int[] getBlankPos()
        {
            int[] blankPos = new int[2];
            for(int i = 0;i < 3; i++)
            {
                for( int j = 0;j < 3; j++)
                {
                    if (this.state[i,j] == 0)
                    {
                        blankPos[0] = i;
                        blankPos[1] = j;
                    }
                }
            }
            return blankPos;
        }

        public Node deepClone()
        {
            Node newNode = new Node();
            for(int i = 0; i < 3; i++)
            {
                for(int j=0; j < 3; j++)
                {
                    newNode.State[i,j] = this.state[i,j];
                }
            }
            newNode.Gx = this.Gx;
            newNode.Hx = this.Hx;
            return newNode;
        }
    }
}
