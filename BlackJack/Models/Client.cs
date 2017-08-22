using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Core;

namespace BlackJack.Models
{
    public class Client : Player
    {
        // States.

        public class OverflowState : IGameResultState
        {
            public void CheckRules(Player player)
            {
                throw new NotImplementedException();
            }

            public void Default(Player player) { player.State = new DefaultState(); }
        }

        public class BlackJackState : IGameResultState
        {
            public void CheckRules(Player player)
            {
                throw new NotImplementedException();
            }

            public void Default(Player player) { player.State = new DefaultState(); }
        }

        public class PushState : IGameResultState
        {
            public void CheckRules(Player player)
            {
                throw new NotImplementedException();
            }

            public void Default(Player player) { player.State = new DefaultState(); }
        }

        public class WinPointsState : IGameResultState
        {
            public void CheckRules(Player player)
            {
                throw new NotImplementedException();
            }

            public void Default(Player player)
            {
                throw new NotImplementedException();
            }
        }
        public class LosePointsState : IGameResultState
        {
            public void CheckRules(Player player)
            {
                throw new NotImplementedException();
            }

            public void Default(Player player)
            {
                throw new NotImplementedException();
            }
        }

        public class DefaultState : IGameResultState
        {
            public void CheckRules(Player player)
            {
                if (player.CheckForOverflow())
                {
                    Messages.LoseOverflow();
                    player.State = new OverflowState();
                    return;
                }


                if (player.CheckBlackJack())
                {
                    Messages.WinBlackJack();

                    player.State = new BlackJackState();
                    return;
                }
               

            }

            public void Default(Player player) { throw new NotImplementedException(); }
        }

        //
    }
}
