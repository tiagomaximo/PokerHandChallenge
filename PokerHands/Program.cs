using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Intructions:");
            Console.WriteLine("Type 1 to use the default example or type any other key to start the program.");

            string instruction = Console.ReadLine();

            List<Hand> hands = new List<Hand>();

            try
            {
                if (instruction == "1")
                {
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("Joe,3H,4H,5H,6H,8H");
                    Console.WriteLine("Bob,3C,3D,3S,8C,TD");
                    Console.WriteLine("Sally,AC,TC,5C,2S,2C");

                    Hand hand1 = new Hand("Joe,3H,4H,5H,6H,8H");
                    Hand hand2 = new Hand("Bob,3C,3D,3S,8C,TD");
                    Hand hand3 = new Hand("Sally,AC,TC,5C,2S,2C");

                    hands.Add(hand1);
                    hands.Add(hand2);
                    hands.Add(hand3);
                }
                else
                {
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("Type the 3 hands:");

                    Hand hand1 = new Hand(Console.ReadLine());
                    Hand hand2 = new Hand(Console.ReadLine());
                    Hand hand3 = new Hand(Console.ReadLine());

                    hands.Add(hand1);
                    hands.Add(hand2);
                    hands.Add(hand3);
                }

                Console.WriteLine(Environment.NewLine);
                Console.WriteLine(string.Format("Result: {0}", Game.GetWinner(hands)));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Read();
        }
    }
}