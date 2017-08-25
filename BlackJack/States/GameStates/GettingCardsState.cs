using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using BlackJack.Core;
using BlackJack.Models;
using BlackJack.States.ClientStates;

namespace BlackJack.States.GameStates
{
    public class GettingCardsState : IGameState
    {
        private readonly Game _game;

       
        public GettingCardsState(Game game)
        {
            _game = game;
        }
        public void Setup()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }



        public void GettingCards()
        {
            if (_game.IsPlayersDefaultState())
            {

                do
                {
                    _game.Messages.AskNeedCard();
                    var userInput = Console.ReadLine();

                    if (userInput == UserCommands.Yes)
                    {
                        _game.Client.TakeCard(_game.Croupier.GiveCards(1).First());
                        _game.Messages.ShowStatusAfterTakeCard(_game.Client);
                        
                        _game.Client.CheckRules();
                        continue;
                    }

                    if (userInput == UserCommands.No)
                    {
                        break;
                    }
                    _game.Messages.UnknownCommand();
                    
                } while (_game.Client.GetState()is DefaultState);
             
                if (_game.IsPlayersDefaultState())//TODO:2
                {
                    _game.Messages.CroupierThink();

                    Thread.Sleep(2000);
                    _game.Messages.ShowCardsCountCroupierTake(_game.Croupier);

                    _game.Messages.Calculating();

                    Thread.Sleep(2000);
                    _game.Messages.ShowCroupierStatusAfterTakeCard(_game.Croupier);

                    _game.Croupier.CheckRules();
                    _game.Client.CheckRules();

                    // ComparePoints.
                    _game.SetState(_game.ComparePointsState);
                    //
                }
            }


            //_game.SetState(_game.EndGameState);
        }

        public void ComparePoints()
        {
            throw new NotImplementedException();
        }

        public void EndGame()
        {
            throw new NotImplementedException();
        }
    }
}
