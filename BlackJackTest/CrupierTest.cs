using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using BlackJack.Core;
using BlackJack.Models;
using NUnit.Framework;

namespace BlackJackTest
{
    [TestFixture]
    public class CroupierTest
    {
        #region [CreateDeck] Need to change access level

        //[Test]
        //public void CreateDeck_Count([Values(1)] int deckCount,
        //  [Values("Denis")]string clientName)
        //{
        //    Game game = new Game();
        //    game.NewGame();

        //    croupier croupier = new croupier(1);

        //    Assert.AreEqual(52, game.CreateDeck().Count);

        //}
        //[Test]
        //public void CreateDeck_FistElementName([Values(1)] int deckCount,
        //    [Values("Denis")]string clientName)
        //{
        //    Game game = new Game();
        //    game.NewGame();

        //    croupier croupier = new croupier(1);

        //    Assert.AreEqual("2", game.CreateDeck().First().Name);

        //}

        //[Test]
        //public void CreateDeck_LastElementName([Values(1)] int deckCount,
        //    [Values("Denis")]string clientName)
        //{
        //    Game game = new Game();
        //    game.NewGame();

        //    croupier croupier = new croupier(1);

        //    Assert.AreEqual("T", game.CreateDeck().Last().Name);

        //}

        //[Test]
        //public void CreateDeckList_Count([Values(2)]int input, [Values(1)]
        //int deckCount, [Values("Denis")]string clientName)
        //{
        //    Game game = new Game();
        //    game.NewGame();

        //    croupier croupier = new croupier(1);

        //    Assert.AreEqual(52 * input, game.CreateDeckList(input).Count);

        //}


        #endregion

        [Test]
        public void GiveCards([Values(1)] int input, [Values(1)] int deckCount,
              [Values("Denis")]string clientName)
        {
            Game game = new Game();
            game.NewGame();

            Croupier croupier = new Croupier(1);

           // Assert.AreEqual("2", croupier.GiveCards(input).First().Name);
        }

        [Test]
        public void CalculatePoints([Values(1)] int input, [Values(1)] int deckCount,
              [Values("Denis")]string clientName)
        {
            Game game = new Game();
            game.NewGame();

            Croupier croupier = new Croupier(1);
            croupier.TakeCard(new Card() { Name = "5", Suit = "Heart", Value = 5 });
            croupier.TakeCard(new Card() { Name = "T", Suit = "Heart", Value = 11 });
            croupier.TakeCard(new Card() { Name = "T", Suit = "Heart", Value = 11 });
            croupier.TakeCard(new Card() { Name = "T", Suit = "Heart", Value = 11 });
            croupier.TakeCard(new Card() { Name = "10", Suit = "Heart", Value = 10 });
            
            Assert.AreEqual(18, croupier.CalculatePoints());
        }

       

        [Test]
        public void ComparePoints([Values(19)]int clientPoints)
        {
            Croupier croupier = new Croupier(1);
            croupier.TakeCard(new Card() { Name = "T", Suit = "Heart", Value = 11 });
            croupier.TakeCard(new Card() { Name = "Q", Suit = "Heart", Value = 10 });

            Assert.AreEqual("LOSE!",croupier.ComparePoints(clientPoints));
            
        }
    }


}
