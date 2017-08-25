using System;
using BlackJack.Core;
using BlackJack.Models;
using BlackJack.States.ClientStates;

namespace BlackJack.States.GameStates
{
    public class ComparePointsState:IGameState
    {
        private Game _game;

        public ComparePointsState(Game game)
        {
            _game = game;
        }

        public void Setup()
        {
            throw new NotImplementedException();
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
            if (_game.IsPlayersDefaultState())
            {
                _game.Croupier.ComparePoints(_game.Client.CalculatePoints());
                
            }
            _game.SetState(_game.EndGameState);
        }

        public void EndGame()
        {
            throw new NotImplementedException();
        }
    }
}
