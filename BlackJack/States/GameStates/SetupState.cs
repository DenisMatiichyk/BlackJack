using System;
using System.Linq;
using BlackJack.Core;
using BlackJack.States.ClientStates;

namespace BlackJack.States.GameStates
{
    public class SetupState : IGameState
    {
        private readonly Game _game;

        public SetupState(Game game)
        {
            _game = game;
        }

        public void Setup()
        {
            _game.Client.SetState(_game.Client.DefaultState);
            _game.Croupier.SetState(_game.Croupier.DefaultState);

            _game.Messages.WriteName();

            _game.Client.Name = Console.ReadLine();

            while (true)
            {
                _game.Messages.AskDecksCount();

                try
                {
                    _game.DecksCount = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (FormatException)
                {
                    _game.Messages.UnknownCommand();
                }

            }

            if (_game.Decks.Any())
            {
                _game.Decks.Clear();
                _game.Croupier.CardPool.Clear();
                _game.Client.CardPool.Clear();
            }

            _game.Decks.AddRange(_game.CreateDeckList().OrderBy(d => _game.Rnd.Next()));
            _game.Decks.AddRange(_game.Decks);


             _game.SetState(_game.StartState);
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void GettingCards()
        {
            throw new NotImplementedException();
        }

        public void ComparePoints()
        {
            throw new NotImplementedException();
        }

        public void EndGame()
        {
            throw new NotImplementedException();
        }
    }
}
