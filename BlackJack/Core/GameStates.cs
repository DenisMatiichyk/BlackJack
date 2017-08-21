using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Core
{
    class GameStates
    {
        class NewGame:IGameState
        {
            void NewGameState(Game game)
            {
                throw new NotImplementedException();
            }

            public void StartState(Game game)
            {
                throw new NotImplementedException();
            }

            public void TakeCard(Game game)
            {
                throw new NotImplementedException();
            }
        }

    }
}
