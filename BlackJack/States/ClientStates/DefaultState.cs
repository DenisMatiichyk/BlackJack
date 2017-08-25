using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Core;
using BlackJack.Models;

namespace BlackJack.States.ClientStates
{
    public class DefaultState : IGameResultState
    {
        private readonly Game _game;

        public DefaultState(Game game)
        {
            _game = game;

        }
        public void CheckRules(Player player)
        {

            // Client.

            if (player is Client)
            {

                if (player.CheckForOverflow())
                {
                    _game.Messages.LoseOverflow();
                    player.SetState(player.OverflowState);
                    _game.SetState(_game.EndGameState);
                    
                    //endgame
                    return;
                }

                if (player.CheckBlackJack())
                {
                    if (_game.Croupier.CheckBlackJack())
                    {
                        player.SetState(player.PushState);
                        _game.Client.SetState(_game.Client.PushState);
                        _game.Messages.Push();
                        _game.SetState(_game.EndGameState);
                        return;
                    }

                    player.SetState(player.BlackJackState);
                    _game.Messages.WinBlackJack();
                }

            }

            // Croupier.

            if (player is Croupier)
            {
                if (player.CheckForOverflow())
                {
                    player.SetState(player.OverflowState);
                    _game.Messages.WinOverflow();
                    return;
                }

                if (player.CheckBlackJack())
                {
                    player.SetState(player.BlackJackState);
                    if (_game.Client.CheckBlackJack())
                    {
                        player.SetState(player.PushState);
                        _game.Client.SetState(_game.Client.PushState);
                        _game.SetState(_game.EndGameState);
                        _game.Messages.LoseBlackJack();
                    }
                }

            }


        }

        public void Default(Player player) { throw new NotImplementedException(); }
    }
}
