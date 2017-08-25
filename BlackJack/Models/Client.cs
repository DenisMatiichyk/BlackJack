using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Core;
using BlackJack.States.ClientStates;

namespace BlackJack.Models
{
    public class Client : Player
    {
        private readonly Game _game;

        public Client(Game game)
        {
            _game = game;
            DefaultState = new DefaultState(_game);
            BlackJackState = new BlackJackState();
            WinPointsState = new WinPointsState();
            LosePointsState = new LosePointsState();
            PushState = new PushState();
            OverflowState = new OverflowState();
            SetState(DefaultState);
            
        }
       


    }
}
