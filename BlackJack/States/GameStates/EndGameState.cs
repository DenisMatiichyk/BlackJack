using System;
using BlackJack.Core;
using BlackJack.Models;

namespace BlackJack.States.GameStates
{
    public class EndGameState : IGameState
    {
        private readonly Game _game;

        public EndGameState(Game game)
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
            throw new NotImplementedException();
        }

        public void ComparePoints()
        {
           EndGame();
        }

        public void EndGame()
        {
            do
            {
                _game.Messages.AskOneMoreGame();
                var userInput = Console.ReadLine();
                if (userInput == UserCommands.Yes)
                {
                    _game.SetState(_game.SetupState);
                   _game.NewGame();


                    return;
                }
                if (userInput == UserCommands.No)
                {
                    Environment.Exit(0);

                }

                _game.Messages.UnknownCommand(); 


            } while (true);
            
        }
    }
}
