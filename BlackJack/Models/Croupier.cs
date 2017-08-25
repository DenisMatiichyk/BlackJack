using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Core;
using BlackJack.States.ClientStates;

namespace BlackJack.Models
{
    public class Croupier : Player
    {
        private readonly Game _game;
        public Croupier(Game game, int nameIndex)
        {
            _game = game;
            Name = ((CroupierNamesEnum)nameIndex).ToString();

            DefaultState = new DefaultState(_game);
            BlackJackState = new BlackJackState();
            WinPointsState = new WinPointsState();
            LosePointsState = new LosePointsState();
            PushState = new PushState();
            OverflowState = new OverflowState();

            SetState(DefaultState);
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
            var cards = _game.Decks.Take(count).ToList();
            _game.Decks.RemoveRange(0, count);
            return cards;
        }


        public void  ComparePoints(int clientPoints) //1 enum state?
        {
            var croupierPoints = CalculatePoints();

            if (clientPoints > croupierPoints)
            {
                this.SetState(this.LosePointsState);
                _game.Client.SetState(_game.Client.WinPointsState);
                _game.Messages.WinPoints();
                return;
            }

            if (clientPoints == croupierPoints)
            {
                this.SetState(this.PushState);
                _game.Client.SetState(_game.Client.PushState);
                _game.Messages.Push();
                return;
            }

            this.SetState(this.WinPointsState);
            _game.Client.SetState(_game.Client.LosePointsState);
            _game.Messages.LosePoints();
            
        }
      

    }
}
