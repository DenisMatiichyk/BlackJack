using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Models;

namespace BlackJack.Core
{
    public class Game
    {

        private static readonly List<Card> _decks = new List<Card>();
        private static readonly Random _rnd = new Random();
        public Croupier Croupier { get; } = new Croupier(_rnd.Next(0, 3));
        public Client Client { get; } = new Client();
        public int DecksCount { get; set; }

        public static Random Rnd => _rnd;

        public static List<Card> Decks => _decks;

        private List<Card> CreateDeck()
        {
            var deck = new List<Card>();
            var valuesIndex = 2;
           
            


            //2,3,4,5,6,7,8,9,10
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    deck.Add(
                        new Card()
                        {
                            Name = valuesIndex.ToString(),
                            Suit = ((SuitEnum)j).ToString(),
                            Value = valuesIndex

                        }
                        );
                }
                valuesIndex++;
            }

            //J,Q,K,T

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (((CardNamesEnum)j) != CardNamesEnum.T)
                    {
                        deck.Add(new Card()
                        {
                            Name = ((CardNamesEnum)j).ToString(),
                            Suit = ((SuitEnum)j).ToString(),
                            Value = 10


                        });

                    }
                    else
                    {
                        deck.Add(new Card()
                        {
                            Name = ((CardNamesEnum)j).ToString(),
                            Suit = ((SuitEnum)j).ToString(),
                            Value = 11


                        });
                    }

                }
            }

            return deck;
        }

        private List<Card> CreateDeckList()
        {
            var deckList = new List<Card>();

            for (int i = 0; i < DecksCount; i++)
            {
                deckList.AddRange(CreateDeck());
            }

            return deckList;
        }

        public void NewGame()
        {
            if (_decks.Any())
            {
                _decks.Clear();
                Croupier.CardPool.Clear();
                Client.CardPool.Clear();
            }

            _decks.AddRange(CreateDeckList().OrderBy(d => _rnd.Next()));
            Decks.AddRange(_decks);
         
        }


    }
}
