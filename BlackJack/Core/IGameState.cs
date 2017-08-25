using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Core
{
    public interface IGameState
    {
        void Setup();
        void Start();
        void GettingCards();
        void ComparePoints();
        void EndGame();
    }
}
