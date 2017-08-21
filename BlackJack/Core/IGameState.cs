using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Core
{
    public interface IGameState
    {
        void NewGame(Game game);
        void Start(Game game);
        void TakeCard(Game game);
        void EndGame(Game game);
    }
}
