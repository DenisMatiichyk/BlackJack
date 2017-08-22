using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Core
{
  public  class GameStates
    {
        public class NewGameState : IGameState
        {
            void IGameState.NewGame(Game game)
            {
                game.State = new StartState();
            }

            public void Start(Game game)
            {
                throw new NotImplementedException();
            }

            public void GettingCards(Game game)
            {
                throw new NotImplementedException();
            }

            public void EndGame(Game game)
            {
                throw new NotImplementedException();
            }
        }

        class StartState : IGameState
        {
            public void NewGame(Game game)
            {
                throw new NotImplementedException();
            }

            public void Start(Game game)
            {
                game.State = new TakeCardState();
            }

            public void GettingCards(Game game)
            {
                throw new NotImplementedException();
            }

            public void EndGame(Game game)
            {
                throw new NotImplementedException();
            }
        }
        class TakeCardState : IGameState
        {
            public void NewGame(Game game)
            {
                throw new NotImplementedException();
            }

            public void Start(Game game)
            {
                throw new NotImplementedException();
            }

            public void GettingCards(Game game)
            {
                game.State = new EndGameState();
            }

            public void EndGame(Game game)
            {
                throw new NotImplementedException();
            }
        }

        class EndGameState : IGameState
        {
            public void NewGame(Game game)
            {
                throw new NotImplementedException();
            }

            public void Start(Game game)
            {
                throw new NotImplementedException();
            }

            public void GettingCards(Game game)
            {
                throw new NotImplementedException();
            }

            public void EndGame(Game game)
            {
                game.State = new NewGameState();
            }
        }
    }
}
