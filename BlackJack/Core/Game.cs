using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Models;
using BlackJack.States.ClientStates;
using BlackJack.States.GameStates;

namespace BlackJack.Core
{
    public class Game
    {

        private IGameState _currentState;

        public SetupState SetupState { get; }
        public StartState StartState { get; }
        public GettingCardsState GettingCardsState { get; }
        public ComparePointsState ComparePointsState { get; }
        public EndGameState EndGameState { get; }

        public Croupier Croupier { get; }
        public Client Client { get; }
        public int DecksCount { get; set; }
        public Messages Messages { get; } = new Messages();
        public Random Rnd => _rnd;
        public List<Card> Decks => _decks;
        public static readonly List<Card> _decks = new List<Card>();
        private static readonly Random _rnd = new Random();

        public Game()
        {
            Client = new Client(this);
            Croupier = new Croupier(this,_rnd.Next(0, 3));

            SetupState = new SetupState(this);
            StartState = new StartState(this);
            GettingCardsState = new GettingCardsState(this);
            ComparePointsState = new ComparePointsState(this);
            EndGameState = new EndGameState(this);

            _currentState = SetupState;
           
        }

        private List<Card> CreateDeck()
        {
            var deck = new List<Card>();
            var valuesIndex = 2;
            var cardsWithNumericNamesCount = 36;
            var cardNameTypesCount = 13;

            var aceSuitIndex = 0;
            var suitIndex = 0;


            for (int i = 0; i < cardNameTypesCount; i++)
            {
                for (int j = 0; j < Enum.GetNames(typeof(SuitEnum)).Length; j++)
                {
                    if (cardsWithNumericNamesCount > deck.Count)
                    {
                        deck.Add(
                       new Card()
                       {
                           Name = valuesIndex.ToString(),
                           Suit = ((SuitEnum)j).ToString(),
                           Value = valuesIndex

                       }
                       );
                        continue;
                    }

                    if (((CardNamesEnum)j) != CardNamesEnum.Ace)
                    {
                        deck.Add(new Card()
                        {
                            Name = ((CardNamesEnum)j).ToString(),
                            Suit = ((SuitEnum)suitIndex).ToString(),
                            Value = 10

                        });
                        continue;
                    }

                    deck.Add(new Card()
                    {
                        Name = CardNamesEnum.Ace.ToString(),
                        Suit = ((SuitEnum)suitIndex).ToString(),
                        Value = 11

                    });

                    suitIndex++;
                }
                valuesIndex++;


            }

            return deck;
        }

        public List<Card> CreateDeckList()
        {
            var deckList = new List<Card>();

            for (int i = 0; i < DecksCount; i++)
            {
                deckList.AddRange(CreateDeck());
            }

            return deckList;
        }




        public void Run()
        {

        }



        public void NewGame()
        {
            _currentState.Setup();
        }

        public void Start() { _currentState.Start(); }

        public void GettingCards() { _currentState.GettingCards(); }
        public void ComparePoints() { _currentState.ComparePoints(); }
        public void EndGame() { _currentState.EndGame(); }

        public void SetState(IGameState gameState)
        {
            _currentState = gameState;
        }
        public bool IsPlayersDefaultState()
        {
            return ((Croupier.GetState() is DefaultState) && // ?
                    (Client.GetState() is DefaultState));
        }

    }

}
