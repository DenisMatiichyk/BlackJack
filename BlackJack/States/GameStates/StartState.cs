using System;
using System.Linq;
using System.Threading;
using BlackJack.Core;

namespace BlackJack.States.GameStates
{
    public class StartState : IGameState
    {
        private readonly Game _game;

        public StartState(Game game)
        {
            _game = game;
        }
        public void Setup()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            // Start
            
            _game.Messages.GameStarted();

            Thread.Sleep(1000);
            _game.Messages.DistributionCards();

            Thread.Sleep(1500);

            _game.Client.TakeCard(_game.Croupier.GiveCards(1).First());
            _game.Client.TakeCard(_game.Croupier.GiveCards(1).First());
            _game.Messages.ShowUserStartPool(_game.Client); //TODO: #1


            _game.Croupier.TakeCard(_game.Croupier.GiveCards(1).First());
            _game.Croupier.TakeCard(_game.Croupier.GiveCards(1).First());

            _game.Croupier.CheckRules();
            //

            _game.SetState(_game.GettingCardsState);
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
