using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Models;

namespace BlackJack.Core
{
    public interface IGameResultState
    {
        void CheckRules(Player player);
        //void Lose(Player player);
        void Default(Player player);
    }
}
