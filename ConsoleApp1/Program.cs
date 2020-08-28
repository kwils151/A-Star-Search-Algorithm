using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//row,column
//change to input
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeVar = 0;
            
            List<Node> open = new List<Node>();
            List<Node> closed = new List<Node>();

            var nodesArray = new Node[15, 15];
            string[] xy = new string[] {};


            //creates the node objects
            for (int i = 0; i < 15; i++)
            {
                for (int x = 0; x < 15; x++)
                {
                    nodesArray[i, x] = new Node(i, x, "- ");
                }
            }

            
            //pick and assign start and end nodes
            int StartNodeRow = 0;
            string StartNodeRowString = " ";

            int StartNodeCol = 0;
            string StartNodeColString = " ";

            int endNodeRow = 0;
            string endNodeRowString = " ";

            int endNodeCol = 0;
            string endNodeColString = " ";

            Console.WriteLine("Enter a number between 0-14\n");

            //user input for start and end node
            Console.Write("Enter Starting Y Coordinate: ");
            StartNodeRowString = Console.ReadLine();
            StartNodeRow = Convert.ToInt32(StartNodeRowString);
            int StartNodeRowTemp = StartNodeRow;

            Console.Write("Enter Starting X Coordinate: ");
            StartNodeColString = Console.ReadLine();
            StartNodeCol = Convert.ToInt32(StartNodeColString);
            int StartNodeColTemp = StartNodeCol;

            Console.WriteLine();

            Console.Write("Enter Ending Y Coordinate: ");
            endNodeRowString = Console.ReadLine();
            endNodeRow = Convert.ToInt32(endNodeRowString);

            Console.Write("Enter Ending X Coordinate: ");
            endNodeColString = Console.ReadLine();
            endNodeCol = Convert.ToInt32(endNodeColString);

            nodesArray[StartNodeRow, StartNodeCol].setType("S ");
            nodesArray[endNodeRow, endNodeCol].setType("E ");



            //Randomly places walls
            Random rnd = new Random();
            int count = 0;
            do
            {
                int randomWallRow = rnd.Next(0, 15);
                int randomWallCol = rnd.Next(0, 15);

                if (randomWallRow != StartNodeRow && randomWallRow != endNodeRow && randomWallCol != StartNodeCol && randomWallCol != endNodeCol)
                {
                    nodesArray[randomWallRow, randomWallCol].setType("0 ");
                    count++;
                }
            } while (count < 24);
            

            //add starting node to open list
            open.Add(nodesArray[StartNodeRow, StartNodeCol]);

            int sCol, sRow, parentG, fValue;
            string sColType, sRowType;
            Node tempNode = new Node(0, 0, " ");

            for (int i = 0; i < 40; i++)
            {

                //searches right
                sCol = nodesArray[StartNodeRow, StartNodeCol].getCol();
                sCol = sCol + 1;
                if (sCol <= 14)
                {
                    sColType = nodesArray[StartNodeRow, StartNodeCol + 1].toString();

                    if (StartNodeRow == endNodeRow && sCol == endNodeCol)
                    {
                        break;
                    }

                    if (sCol <= 14 && sColType.Equals("- ") == true)
                    {
                        nodesArray[StartNodeRow, sCol].setParent(nodesArray[StartNodeRow, StartNodeCol]);//sets parent

                        parentG = nodesArray[StartNodeRow, sCol].getParent().getG();
                        nodesArray[StartNodeRow, sCol].setG(10 + parentG); // sets G-value

                        nodesArray[StartNodeRow, sCol].setH((Math.Abs(sCol - endNodeCol) + Math.Abs(StartNodeRow - endNodeRow)) * 10);//sets H-value
                        fValue = nodesArray[StartNodeRow, sCol].getG() + nodesArray[StartNodeRow, sCol].getH();
                        nodesArray[StartNodeRow, sCol].setF();//sets F-value

                        open.Add(nodesArray[StartNodeRow, sCol]);
                    }
                }


                //searchs left
                sCol = nodesArray[StartNodeRow, StartNodeCol].getCol();
                sCol = sCol - 1;
                if (sCol >= 0)
                {
                    sColType = nodesArray[StartNodeRow, StartNodeCol - 1].toString();

                    if (StartNodeRow == endNodeRow && sCol == endNodeCol)
                    {
                        break;
                    }

                    if (sCol >= 0 && sColType.Equals("- ") == true)
                    {
                        nodesArray[StartNodeRow, sCol].setParent(nodesArray[StartNodeRow, StartNodeCol]);//sets parent

                        parentG = nodesArray[StartNodeRow, sCol].getParent().getG();
                        nodesArray[StartNodeRow, sCol].setG(10 + parentG);//sets g-value

                        nodesArray[StartNodeRow, sCol].setH((Math.Abs(sCol - endNodeCol) + Math.Abs(StartNodeRow - endNodeRow)) * 10);//sets h-value

                        fValue = nodesArray[StartNodeRow, sCol].getG() + nodesArray[StartNodeRow, sCol].getH();//sets f-value
                        nodesArray[StartNodeRow, sCol].setF();

                        open.Add(nodesArray[StartNodeRow, sCol]);
                    }
                }

                //searches up
                sRow = nodesArray[StartNodeRow, StartNodeCol].getRow();
                sRow = sRow - 1;
                if (sRow >= 0)
                {
                    sRowType = nodesArray[StartNodeRow - 1, StartNodeCol].toString();

                    if (sRow == endNodeRow && StartNodeCol == endNodeCol)
                    {
                        break;
                    }

                    if (sRow >= 0 && sRowType.Equals("- ") == true)
                    {
                        nodesArray[sRow, StartNodeCol].setParent(nodesArray[StartNodeRow, StartNodeCol]);//sets parent

                        parentG = nodesArray[sRow, StartNodeCol].getParent().getG();
                        nodesArray[sRow, StartNodeCol].setG(10 + parentG);//sets g-value

                        nodesArray[sRow, StartNodeCol].setH((Math.Abs(StartNodeCol - endNodeCol) + Math.Abs(sRow - endNodeRow)) * 10);//sets h-value

                        fValue = nodesArray[sRow, StartNodeCol].getG() + nodesArray[sRow, StartNodeCol].getH();//sets f-value
                        nodesArray[sRow, StartNodeCol].setF();

                        open.Add(nodesArray[sRow, StartNodeCol]);
                    }
                }


                //searches down
                sRow = nodesArray[StartNodeRow, StartNodeCol].getRow();
                sRow = sRow + 1;
                if (sRow <= 14)
                {
                    sRowType = nodesArray[StartNodeRow + 1, StartNodeCol].toString();

                    if (sRow == endNodeRow && StartNodeCol == endNodeCol)
                    {
                        break;
                    }

                    if (sRow <= 14 && sRowType.Equals("- ") == true)
                    {
                        nodesArray[sRow, StartNodeCol].setParent(nodesArray[StartNodeRow, StartNodeCol]);//sets parent

                        parentG = nodesArray[sRow, StartNodeCol].getParent().getG();
                        nodesArray[sRow, StartNodeCol].setG(10 + parentG);//sets g-value

                        nodesArray[sRow, StartNodeCol].setH(0);
                        nodesArray[sRow, StartNodeCol].setH((Math.Abs(StartNodeCol - endNodeCol) + Math.Abs(sRow - endNodeRow)) * 10);//sets h-value

                        fValue = nodesArray[sRow, StartNodeCol].getG() + nodesArray[sRow, StartNodeCol].getH();//sets f-value
                        nodesArray[sRow, StartNodeCol].setF();

                        open.Add(nodesArray[sRow, StartNodeCol]);
                    }
                }

                closed.Add(nodesArray[StartNodeRow, StartNodeCol]);
                sizeVar++;

            
                open.Remove(nodesArray[StartNodeRow, StartNodeCol]);

                open.Sort();

                if (!open.Any())
                {
                    Console.WriteLine("\nNo path could be found");
                    break;
                }

                tempNode = open[0];
                open.Clear();
                tempNode.setType("* ");


                //change startnode x,y
                StartNodeRow = tempNode.getRow();
                StartNodeCol = tempNode.getCol();
            }

            //------------------------------------------------------------------------------------------------------------------------------------

            //Coordinate and board output
            Console.WriteLine("\n[Y, X]\n\n" + "[" + endNodeRow + ", " + endNodeCol + "]   End");
            Console.WriteLine("[" + nodesArray[StartNodeRow, StartNodeCol].getRow() + ", " + nodesArray[StartNodeRow, StartNodeCol].getCol() + "]");

            for (int i = sizeVar - 1; i >= 0; i--)
            {
                if(i == 0)
                {
                    break;
                }
                Console.WriteLine("[" + closed[i].getRow() + ", " + closed[i].getCol() + "]");
            }

            Console.WriteLine("[" + StartNodeRowTemp + ", " + StartNodeColTemp + "]   Start");

            Console.WriteLine("\n");
            for (int i = 0; i < 15; i++)
            {
                for (int x = 0; x < 15; x++)
                {
                    Console.Write(nodesArray[i, x].toString());
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}



/*
                        //diag search
                        string diagType;
                        int diagRow, diagCol;




                        //searches up/right
                        diagRow = nodesArray[StartNodeRow, StartNodeCol].getRow();
                        diagRow = diagRow - 1;

                        diagCol = nodesArray[StartNodeRow, StartNodeCol].getCol();
                        diagCol = diagCol + 1;

                        diagType = nodesArray[diagRow, diagCol].toString();

                        if(diagRow >= 0 && diagCol <= 14 && diagType.Equals("- ") == true)
                        {
                            nodesArray[diagRow, diagCol].setType("* ");
                        } 




                        //searches down/right
                        diagRow = nodesArray[StartNodeRow, StartNodeCol].getRow();
                        diagRow = diagRow + 1;

                        diagCol = nodesArray[StartNodeRow, StartNodeCol].getCol();
                        diagCol = diagCol + 1;

                        diagType = nodesArray[diagRow, diagCol].toString();

                        if (diagRow <= 14 && diagCol <= 14 && diagType.Equals("- ") == true)
                        {
                            nodesArray[diagRow, diagCol].setType("* ");
                        }






                        //searches up/left
                        diagRow = nodesArray[StartNodeRow, StartNodeCol].getRow();
                        diagRow = diagRow - 1;

                        diagCol = nodesArray[StartNodeRow, StartNodeCol].getCol();
                        diagCol = diagCol - 1;

                        diagType = nodesArray[diagRow, diagCol].toString();

                        if (diagRow >= 0 && diagCol >= 0 && diagType.Equals("- ") == true)
                        {
                            nodesArray[diagRow, diagCol].setType("* ");
                        }





                        //searches down/left
                        diagRow = nodesArray[StartNodeRow, StartNodeCol].getRow();
                        diagRow = diagRow + 1;

                        diagCol = nodesArray[StartNodeRow, StartNodeCol].getCol();
                        diagCol = diagCol - 1;

                        diagType = nodesArray[diagRow, diagCol].toString();

                        if (diagRow <= 14 && diagCol >= 0 && diagType.Equals("- ") == true)
                        {
                            nodesArray[diagRow, diagCol].setType("* ");
                        }




                        /*
                        Console.WriteLine("Start X: " + nodesArray[StartNodeRow, StartNodeCol].getCol());
                        Console.WriteLine("Start Y: " + nodesArray[StartNodeRow, StartNodeCol].getRow());

                        Console.WriteLine("\nNode X: " + nodesArray[StartNodeRow, sCol].getCol());
                        Console.WriteLine("Node Y: " + nodesArray[StartNodeRow, sCol].getRow());

                        Console.WriteLine(nodesArray[sRow, StartNodeCol].getParent().getRow());
                        Console.WriteLine(nodesArray[sRow, StartNodeCol].getParent().getCol());
            */
