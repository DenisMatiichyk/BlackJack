using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BlackJack.Core;
using BlackJack.Models;


namespace BlackJack
{
    class Program
    {
        private static readonly Game _game = new Game();
       
        static void Main(string[] args)
        {
            Run();
        }

        private static string GetUserInput()
        {
            return Console.ReadLine();
        }
        
        private static void Run()
        {
            _game.Messages.Hello();

            _game.Messages.WriteNewGame();

            while (true)
            {
                
                if (GetUserInput() == UserCommands.NewGame)
                {
                    _game.NewGame();

                    while (true)
                    {
                        _game.Messages.WriteStart();

                        if (GetUserInput() == UserCommands.Start)
                        {
                            do
                            {
                                // Start
                                _game.Start();
                                //

                                // TakeCard
                                _game.GettingCards();
                                //
                                _game.ComparePoints(); //?
                                // EndGame
                                _game.EndGame();
                                //

                            } while (true);
                        }
                        else
                        { _game.Messages.UnknownCommand(); }

                    }
                    
                }
            }
        }
    }
}
