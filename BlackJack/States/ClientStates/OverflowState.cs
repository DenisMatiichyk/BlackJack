using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Core;
using BlackJack.Models;

namespace BlackJack.States.ClientStates
{
    public class OverflowState : IGameResultState
    {
        public void CheckRules(Player player)
        {
            Console.WriteLine("You have overflow. Nothing to check.");
        }

        public void Default(Player player)
        {
            player.SetState(player.DefaultState);
        }
    }

}
