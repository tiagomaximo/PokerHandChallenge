using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    public class Game
    {
        public static string GetWinner(IList<Hand> hands)
        {
            StringBuilder winners = new StringBuilder();

            //Ordering the colletion by high hand
            hands = hands.OrderByDescending(c => c.Point).ToList();

            Hand winner = hands.FirstOrDefault();

            if (winner.Point == Points.HighCard)
            {
                //If the high hand is a HighCard, ordering the collection by HighCard to be easier to check in case of tie
                hands = hands.OrderByDescending(c => c.GetHighCard()).ToList();
                winner = hands.FirstOrDefault();
            }

            winners.Append(winner.Name);

            //Started the i = 1 because we already have the first element in the winner variable. That way is easier to check some tie.
            //If the second element has a different point hand there is no way to have a tie and we call the break.
            for (int i = 1; i < hands.Count(); i++)
            {
                //Check if has tie for the HighCard hands
                if (winner.Point == Points.HighCard)
                {
                    if (hands[i].GetHighCard() == winner.GetHighCard())
                    {
                        winners.AppendFormat(", {0}", hands[i].Name);
                    }
                }
                //Check if has tie for the others hands
                else if (hands[i].Point == winner.Point)
                {
                    winners.AppendFormat(", {0}", hands[i].Name);
                }
                else
                {
                    break;
                }
            }

            return winners.ToString();
        }
    }
}