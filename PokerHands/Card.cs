using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands
{
    public class Card
    {
        public enum CardValues
        {
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King,
            Ace
        }

        //hearts (H), clubs (C), spades (S), diamonds (D)
        public enum SuitValues
        {
            Heart,
            Club,
            Spade,
            Diamond
        }

        public Card(string card)
        {
            card = card.ToUpper();

            if (card.Length != 2)
                throw new ArgumentException("Invalid card!");
            try
            {
                Dictionary<string, CardValues> cardValues = new Dictionary<string, CardValues>() 
                {
                    {"2", CardValues.Two},
                    {"3", CardValues.Three},
                    {"4", CardValues.Four},
                    {"5", CardValues.Five},
                    {"6", CardValues.Six},
                    {"7", CardValues.Seven},
                    {"8", CardValues.Eight},
                    {"9", CardValues.Nine},
                    {"T", CardValues.Ten},
                    {"J", CardValues.Jack},
                    {"Q", CardValues.Queen},
                    {"K", CardValues.King},
                    {"A", CardValues.Ace},
                };

                Value = cardValues[card.Substring(0, 1)];

                //hearts (H), clubs (C), spades (S), and diamonds (D)
                Dictionary<string, SuitValues> suits = new Dictionary<string, SuitValues>() 
                {
                    {"H", SuitValues.Heart},
                    {"C", SuitValues.Club},
                    {"S", SuitValues.Spade},
                    {"D", SuitValues.Diamond}
                };

                Suit = suits[card.Substring(1, 1)];
            }
            catch (Exception)
            {
                throw new KeyNotFoundException("Invalid card!");
            }
        }

        public CardValues Value { get; set; }
        public SuitValues Suit { get; set; }
    }
}