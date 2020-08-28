using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Node : IComparable
    {
        // g - distance from start node
        // h - distance from end node
        // f - g + h

        int g, h, f, row, col, value;
        string type;
        private Node parent;

        public Node(int r, int c, string t)
        {
            row = r;
            col = c;
            type = t;
        }


        public int CompareTo(Object other)
        {
            if (other == null) return 1;

            Node otherNode = other as Node;

            if (this.f > otherNode.f)
            {
                return 1;
            }
            else if(this.f < otherNode.f)
            {
                return -1;
            }
            else return 0;

        }


        public void setG(int value)
        {
            this.g = value;
        }
        public void setH(int value)
        {
            this.h = value;
        }
        public void setF()
        {
            this.f = g + h;
        }
        public void setType(string value)
        {
            type = value;
        }
        public void setParent(Node n)
        {
            parent = n;
        }



        public int getG()
        {
            return this.g;
        }
        public int getH()
        {
            return this.h;
        }
        public int getF()
        {
            return this.f;
        }
        public int getRow()
        {
            return row;
        }
        public int getCol()
        {
            return col;
        }
        public Node getParent()
        {
            return parent;
        }




        public String toString()
        {
            return type;
        } 
    }
}
