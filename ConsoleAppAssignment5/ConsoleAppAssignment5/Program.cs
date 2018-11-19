using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppAssignment5
{
    class Program
    {
        private static readonly ListAndName PegA = new ListAndName();
        private static readonly ListAndName PegB = new ListAndName();
        private static readonly ListAndName PegC = new ListAndName();
        private static int _moves = 0;

        static void Main(string[] args)
        {
            PegA.List = new List<int>();
            PegA.ListName = "peg A";
            PegB.List = new List<int>();
            PegB.ListName = "peg B";
            PegC.List = new List<int>();
            PegC.ListName = "peg C";

            Console.Write("Input amount of disks: ");
            string amountOfDisks = Console.ReadLine();

            //If no number is given it goes with 5
            if (amountOfDisks == "")
            {
                amountOfDisks = "5";
                Console.Write(amountOfDisks);
            }

            //Generate the disks on peg A
            for (int i = 1; i <= Convert.ToInt32(amountOfDisks); i++)
            {
                PegA.List.Add(i);
            }

            //Starts the recursion
            MoveDisk(Convert.ToInt32(amountOfDisks), PegA, PegC, PegB);
        }

        private static void MoveDisk(int amountOfDisks ,ListAndName fromList, ListAndName toList, ListAndName otherList)
        {
            if (amountOfDisks > 0)
            {
                MoveDisk(amountOfDisks - 1, fromList, otherList, toList);

                int diskToMove = fromList.List[0];

                //Move disk from one list to another and then remove it from the first
                toList.List.Insert(0, fromList.List[0]);
                fromList.List.Remove(diskToMove);

                //Print current state
                Console.WriteLine("Moved disk {0} from {1} to {2}, Move: {3}", diskToMove, fromList.ListName, toList.ListName, ++_moves);
                PrintLists();

                //So that it doesn't just fly by we sleep for ½ second
                Thread.Sleep(500);

                MoveDisk(amountOfDisks - 1, otherList, toList, fromList);
            }
        }

        private static void PrintLists()
        {
            Console.WriteLine("A: " + String.Join(", ", PegA.List));
            Console.WriteLine("B: " + String.Join(", ", PegB.List));
            Console.WriteLine("C: " + String.Join(", ", PegC.List));
        }
    }

    class ListAndName
    {
        public List<int> List { get; set; }
        public string ListName { get; set; }
    }
}
