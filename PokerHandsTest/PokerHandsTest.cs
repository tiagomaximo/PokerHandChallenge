using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerHands;
using System.Collections.Generic;

namespace PokerHandsTest
{
    [TestClass]
    public class PokerHandsTest
    {
        [TestMethod]
        public void When_I_Create_A_Card_With_2H_The_Result_Card_Must_Be_2H()
        {
            Card card = new Card("2H");
            Assert.IsTrue(card.Value == Card.CardValues.Two && card.Suit == Card.SuitValues.Heart);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void When_I_Create_A_Card_With_A_Invalid_Vaue_I_Want_To_See_A_Freindly_Output_Message()
        {
            Card card = new Card("XY");
 
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void When_I_Create_A_Card_With_More_Than_Two_Caracteres_I_Whant_To_See_A_Freindly_Output_Message()
        {
            Card card = new Card("XYZ");
 
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void When_I_Create_A_Card_With_Less_Than_Two_Caracteres_I_Whant_To_See_A_Freindly_Output_Message()
        {
            Card card = new Card("X");

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void When_I_Create_A_Card_Without_Inform_The_Kind_Of_Card_I_Whant_To_See_A_Freindly_Output_Message()
        {
            Card card = new Card("");

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void When_I_Create_A_Card_With_A_StringEmpty_I_Whant_To_See_A_Freindly_Output_Message()
        {
            Card card = new Card(string.Empty);

        }

        [TestMethod]
        public void When_I_Create_A_New_Hand_The_Cards_Can_Not_Be_Null()
        {
            Hand hand = new Hand("Joe,3H,4H,5H,6H,8H");
            Assert.IsNotNull(hand.Cards);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void When_I_Create_A_New_Hand_With_Some_Wrong_Card_I_Want_To_See_A_Freindly_Output_Message()
        {
            Hand hand = new Hand("Joe,35H,4H,5H,6H,8H");
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void When_I_Create_A_New_Hand_With_Some_Wrong_Card_I_Want_To_See_A_Freindly_Output_Message2()
        {
            Hand hand = new Hand("Joe,XY,4H,5H,6H,8H");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void When_I_Create_A_New_Hand_With_A_Wrong_Input_I_Want_To_See_A_Freindly_Output_Message()
        {
            Hand hand = new Hand("Joe,4H,5H,6H,8H");
        }

        [TestMethod]
        public void When_I_Create_A_Hand_With_A_OnePair_The_HandPoint_Must_Be_OnePair()
        {
            Hand hand = new Hand("Sally,AC,TD,5C,2S,2H");
            Assert.AreEqual(hand.Point, Points.OnePair);
        }

        [TestMethod]
        public void When_I_Create_A_Hand_With_A_TwoPair_The_HandPoint_Must_Be_TwoPair()
        {
            Hand hand = new Hand("Sally,3H,AD,2S,2D,3C");
            Assert.AreEqual(hand.Point, Points.TwoPair);
        }

        [TestMethod]
        public void When_I_Create_A_Hand_With_A_ThreeOfAKind_The_HandPoint_Must_Be_ThreeOfAKind()
        {
            Hand hand = new Hand("Sally,AC,KD,KC,KS,2C");
            Assert.AreEqual(hand.Point, Points.ThreeOfAKind);
        }

        [TestMethod]
        public void When_I_Create_A_Hand_With_A_Straight_The_HandPoint_Must_Be_Straight()
        {
            Hand hand = new Hand("Sally,4C,5D,6H,7S,8D");
            Assert.AreEqual(hand.Point, Points.Straight);
        }

        [TestMethod]
        public void When_I_Create_A_Hand_With_A_Flush_The_HandPoint_Must_Be_Flush()
        {
            Hand hand = new Hand("Sally,4C,2C,AC,TC,8C");
            Assert.AreEqual(hand.Point, Points.Flush);
        }

        [TestMethod]
        public void When_I_Create_A_Hand_With_A_FullHouse_The_HandPoint_Must_Be_FullHouse()
        {
            Hand hand = new Hand("Sally,4C,4D,4S,8H,8D");
            Assert.AreEqual(hand.Point, Points.FullHouse);
        }

        [TestMethod]
        public void When_I_Create_A_Hand_With_A_FourOfAKind_The_HandPoint_Must_Be_FourOfAKind()
        {
            Hand hand = new Hand("Sally,4C,4D,4S,4H,8D");
            Assert.AreEqual(hand.Point, Points.FourOfAKind);
        }

        [TestMethod]
        public void When_I_Create_A_Hand_With_A_StraightFlush_The_HandPoint_Must_Be_StraightFlush()
        {
            Hand hand = new Hand("Sally,4C,5C,6C,7C,8C");
            Assert.AreEqual(hand.Point, Points.StraightFlush);
        }

        [TestMethod]
        public void When_I_Create_A_Hand_With_A_StraightFlush_The_HandPoint_Must_Be_StraightFlush2()
        {
            Hand hand = new Hand("Sally,8C,9C,TC,JC,QC");
            Assert.AreEqual(hand.Point, Points.StraightFlush);
        }

        //[TestMethod]
        //public void When_I_Create_A_Hand_With_A_RoyalFlush_The_HandPoint_Must_Be_RoyalFlush()
        //{
        //    Hand hand = new Hand("Sally,TH,JH,QH,AH,KH");
        //    Assert.AreEqual(hand.Point, Points.RoyalFlush);
        //}

        [TestMethod]
        public void When_I_Create_A_Hand_With_The_HighCard_Ace_The_Result_For_GetHighCard_Must_Be_Ace()
        {
            Hand hand = new Hand("Sally,8C,9C,TC,3C,AH");
            Assert.AreEqual(hand.GetHighCard(), Card.CardValues.Ace);
        }

        [TestMethod]
        public void When_I_Create_A_Hand_With_OnePair_And_Other_With_TwoPair_The_Winner_Must_Be_TwoPair()
        {
            Hand onePair = new Hand("Sally,AC,TD,5C,2S,2H");
            Hand twoPair = new Hand("Joe,3H,AD,2S,2D,3C");

            List<Hand> hands = new List<Hand>();

            hands.Add(onePair);
            hands.Add(twoPair);

            string result = Game.GetWinner(hands);

            Assert.AreEqual(result, "Joe");
        }

        [TestMethod]
        public void When_I_Create_A_Hand_With_Flush_And_Other_With_TwoPair_And_Other_With_Highcards_The_Winner_Must_Be_Flush()
        {
            Hand flush = new Hand("Bob,4C,2C,AC,TC,8C");
            Hand onePair = new Hand("Sally,AC,TD,5C,2S,2H");
            Hand highCard = new Hand("Joe,AC,TD,5C,2D,3H");

            List<Hand> hands = new List<Hand>();

            hands.Add(flush);
            hands.Add(onePair);
            hands.Add(highCard);

            string result = Game.GetWinner(hands);

            Assert.AreEqual(result, "Bob");
        }

        [TestMethod]
        public void When_I_Create_2_Hands_With_OnePair_The_Winner_Must_Be_Both()
        {
            Hand onePair1 = new Hand("Bob,AC,TD,5C,2S,2H");
            Hand onePair2 = new Hand("Sally,AC,TD,5C,8S,8H");
            Hand highCard = new Hand("Joe,8C,9D,TC,3C,JH");

            List<Hand> hands = new List<Hand>();

            hands.Add(onePair1);
            hands.Add(onePair2);
            hands.Add(highCard);

            string result = Game.GetWinner(hands);

            Assert.AreEqual(result, "Bob, Sally");
        }

        [TestMethod]
        public void When_I_Create_3_Hands_With_HighCards_The_Winner_Must_Be_Who_Have_The_Bigger_Card()
        {
            Hand highJ = new Hand("Joe,8C,9C,TC,3C,JH");
            Hand highA = new Hand("Bob,8C,9C,TC,3C,AH");
            Hand highQ = new Hand("Sally,8C,9C,TC,3C,QH");

            List<Hand> hands = new List<Hand>();

            hands.Add(highJ);
            hands.Add(highA);
            hands.Add(highQ);

            string result = Game.GetWinner(hands);

            Assert.AreEqual(result, "Bob");
        }

        [TestMethod]
        public void When_I_Create_3_Hands_With_HighCards_3_Equals_HighCards_The_Winner_Must_Be_All_Of_Them()
        {
            Hand highJ = new Hand("Joe,8C,9C,TC,3C,KH");
            Hand highA = new Hand("Bob,8C,9C,TC,3C,KS");
            Hand highQ = new Hand("Sally,8C,9C,TC,3C,KD");

            List<Hand> hands = new List<Hand>();

            hands.Add(highJ);
            hands.Add(highA);
            hands.Add(highQ);

            string result = Game.GetWinner(hands);

            Assert.AreEqual(result, "Joe, Bob, Sally");
        }

        [TestMethod]
        public void When_I_Create_A_2_Hands_With_Flush_The_Winner_Must_Be_Both()
        {
            Hand flush1 = new Hand("Bob,4C,2C,AC,TC,8C");
            Hand flush2 = new Hand("Max,6D,7D,9D,4D,2D");
            Hand onePair = new Hand("Sally,AC,TD,5C,2S,2H");
            Hand highCard = new Hand("Joe,AC,TD,5C,2D,3H");

            List<Hand> hands = new List<Hand>();

            hands.Add(onePair);
            hands.Add(flush1);
            hands.Add(highCard);
            hands.Add(flush2);

            string result = Game.GetWinner(hands);

            Assert.AreEqual(result, "Bob, Max");
        }
    }
}