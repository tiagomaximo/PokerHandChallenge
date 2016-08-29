using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    public class Hand
    {
        public IList<Card> Cards { get; private set; }
        public String Name { get; private set;}

        public Hand(string input)
        {
            this.Cards = new List<Card>();
            SetupHand(input);

            CheckPoints();
        }

        public void SetupHand(string input)
        {
            string[] inputs = input.Split(',');

            if (inputs.Count() != 6)
                throw new ArgumentException("Invalid input!");

            Name = inputs[0];

            //The first element is skipped because is the Name
            foreach (string card in inputs.Skip(1))
            {
                Cards.Add(new Card(card));
            }

            Cards.OrderBy(c => c.Value);
        }

        private void CheckPoints()
        {
            if (CheckOnePair() && !CheckFullHouse())
                Point = Points.OnePair;
            else if (CheckTwoPair() && !CheckFullHouse())
                Point = Points.TwoPair;
            else if (CheckThreeOfAKind() && !CheckFullHouse())
                Point = Points.ThreeOfAKind;
            else if (CheckStraight() && !CheckFlush())
                Point = Points.Straight;
            else if (CheckFlush() && !CheckStraightFlush())
                Point = Points.Flush;
            else if (CheckFullHouse())
                Point = Points.FullHouse;
            else if (CheckFourOfAKind())
                Point = Points.FourOfAKind;
            else if (CheckStraightFlush())
                Point = Points.StraightFlush;
            else if (CheckRoyalFlush())
                Point = Points.RoyalFlush;
            else
                Point = Points.HighCard;
        }

        public PokerHands.Card.CardValues GetHighCard()
        {
            return Cards.Max(c => c.Value);
        }

        private bool CheckOnePair()
        {
            return Cards.GroupBy(c => c.Value).Count(group => group.Count() == 2) == 1 ? true : false;
        }

        private bool CheckTwoPair()
        {
            return Cards.GroupBy(c => c.Value).Count(group => group.Count() >= 2) == 2 ? true : false;
        }

        private bool CheckThreeOfAKind()
        {
            return Cards.GroupBy(c => c.Value).Any(group => group.Count() == 3) ? true : false;
        }

        private bool CheckStraight()
        {
            return Cards.GroupBy(c => c.Value).Count() == Cards.Count() && Cards.Max(c => (int)c.Value) - Cards.Min(c => (int)c.Value) == 4 ? true : false;
        }

        private bool CheckFlush()
        {
            return Cards.GroupBy(c => c.Suit).Count() == 1 ? true : false;
        }

        private bool CheckFullHouse()
        {
            return CheckOnePair() && CheckThreeOfAKind();
        }

        private bool CheckFourOfAKind()
        {
            return Cards.GroupBy(c => c.Value).Any(group => group.Count() == 4) ? true : false;
        }

        private bool CheckStraightFlush()
        {
            return hasStraightFlush() && !CheckRoyalFlush();
        }

        private bool CheckRoyalFlush()
        {
            return Cards.Min(c => (int)c.Value == (int)PokerHands.Card.CardValues.Ten && hasStraightFlush());
        }

        private bool hasStraightFlush()
        {
            return CheckFlush() && CheckStraight();
        }

        public Points Point { get; set; }
    }

    //Royal Flush: if those five are A, K, Q, J, 10
    //Straight flush: Five cards of the same suit in sequence
    //Four of a kind: Four cards of the same rank, and any one other card
    //Full house: Three cards of one rank and two of another
    //Flush: Five cards of the same suit
    //Straight: Five cards in sequence (for example, 4, 5, 6, 7, 8), but not all of the same suit
    //Three of a kind: Three cards of the same rank
    //Two pair: Two cards of one rank and two cards of another
    //One pair: Two cards of the same rank
    //High card: If no one has one pair or a better hand, the highest card wins
    public enum Points
    {
        HighCard,
        OnePair,
        TwoPair,
        ThreeOfAKind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush
    }
}
