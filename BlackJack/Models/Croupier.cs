using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Core;

namespace BlackJack.Models
{
    public class Croupier : Player
    {
        public Croupier(int nameIndex, IGameResultState gameState)
        {
            State = gameState;
            Name = ((CroupierNamesEnum)nameIndex).ToString();
        }

        private enum CroupierNamesEnum
        {
            John,
            Sindy,
            Bill,
            Leo
        }

        public int Think()
        {
            var takenCards = 0;
            while (true)
            {
                if (CalculatePoints() < 17)
                {
                    TakeCard(GiveCards(1).First());
                    takenCards++;
                }
                else
                {
                    break;
                }

            }

            return takenCards;


        }


        public List<Card> GiveCards(int count)
        {
            var cards = Game.Decks.Take(count).ToList();
            Game.Decks.RemoveRange(0, count);
            return cards;
        }


        public string ComparePoints(int clientPoints) //1 enum state?
        {
            var croupierPoints = CalculatePoints();

            if (clientPoints > croupierPoints)
            {
                State = new Client.WinPointsState();
                return "WIN!";
            }

            if (clientPoints == croupierPoints)
            {
                return "PUSH!";
            }

            return "LOSE!";
        }

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

        public class WinPointsState:IGameResultState
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
                   player.State = new OverflowState();
                    return;
                }
                
                if (player.CheckBlackJack())
                {
                    player.State = new BlackJackState();
                    return;
                }
               
            }

            public void Default(Player player) { throw  new NotImplementedException();}
        }

        //
    }
}
