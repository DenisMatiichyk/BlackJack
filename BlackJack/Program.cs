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
        private static bool _isEnd;
        private static bool _isOverflow;
        private static bool _isBlackJack;
        private static bool _isPush;

       

        static void Main(string[] args)
        {
            Run();
        }
        private static void CheckRules()
        {
            if (_game.Croupier.CheckForOverflow() && !_game.Client.CheckForOverflow())
            {
                Console.WriteLine("You WIN! Croupier has a lot of points!");
                _isOverflow = true;
            }
            else if (!_game.Croupier.CheckForOverflow() && _game.Client.CheckForOverflow())
            {
                Console.WriteLine("Defeat! You have a lot of points:(");
                _isOverflow = true;
            }

            if (!_game.Croupier.CheckBlackJack() && _game.Client.CheckBlackJack())
            {
                Console.WriteLine("BLACK JACK! YOU WIN!");
                _isBlackJack = true;
            }
            else if (_game.Croupier.CheckBlackJack() && !_game.Client.CheckBlackJack())
            {
                Console.WriteLine("Defeat! Croupier have Black Jack!");
                _isBlackJack = true;
            }
            else if (_game.Croupier.CheckBlackJack() && _game.Client.CheckBlackJack())
            {
                Console.WriteLine("PUSH!");
                _isPush = true;
            }
        }
        private static void Run()
        {

            Console.WriteLine("Hello in BlackJack game!");
            Console.WriteLine("Type <<new game>> for configure game.");
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "new game"/*"new game"*/:
                        Console.WriteLine("Enter your name.");
                        _game.Client.Name = Console.ReadLine();


                        while (true)
                        {
                            Console.WriteLine("How many decks will be in the game?");
                            try
                            {
                                _game.DecksCount = Convert.ToInt32(Console.ReadLine());
                                break;
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Sorry, unknown command.");

                            }

                        }

                        _game.NewGame();
                        while (true)
                        {
                            Console.WriteLine("Type <<start>> for begin game!");
                            if (Console.ReadLine() == "start")
                            {
                                do
                                {
                                    _isEnd = false;
                                    _isOverflow = false;
                                    _isBlackJack = false;
                                    _isPush = false;

                                    Console.WriteLine("Game started!");
                                    Thread.Sleep(1000);
                                    Console.WriteLine("Distribution cards...");
                                    Thread.Sleep(1500);

                                    _game.Client.TakeCard(_game.Croupier.GiveCards(1).First());
                                    _game.Client.TakeCard(_game.Croupier.GiveCards(1).First());
                                    Console.WriteLine("Your points in card pool: {0}, Cards: {1} {2}, {3} {4}",
                                        _game.Client.CalculatePoints(),
                                        _game.Client.CardPool[0].Name,
                                        _game.Client.CardPool[0].Suit,
                                        _game.Client.CardPool[1].Name,
                                        _game.Client.CardPool[1].Suit);

                                    _game.Croupier.TakeCard(_game.Croupier.GiveCards(1).First());
                                    _game.Croupier.TakeCard(_game.Croupier.GiveCards(1).First());

                                    CheckRules();


                                    if ((!_isPush) && (!_isOverflow) && (!_isBlackJack))
                                    {

                                        do
                                        {
                                            Console.WriteLine("Do you need the card? (yes/no)");
                                            switch (Console.ReadLine())
                                            {
                                                case "yes":
                                                    _game.Client.TakeCard(_game.Croupier.GiveCards(1).First());
                                                    Console.WriteLine("You take {0} {1}, your points now: {2}",
                                                        _game.Client.CardPool.Last().Name,
                                                        _game.Client.CardPool.Last().Suit,
                                                        _game.Client.CalculatePoints());

                                                    CheckRules();
                                                    if (_isOverflow)
                                                    {
                                                        _isEnd = true;
                                                    }

                                                    if (_isBlackJack)
                                                    {
                                                        _isEnd = true;
                                                    }
                                                    break;
                                                case "no":
                                                    _isEnd = true;
                                                    break;
                                                default:
                                                    Console.WriteLine("Sorry, unknown command.");

                                                    break;
                                            }

                                        } while (!_isEnd);
                                        _isEnd = false;

                                        if ((!_isPush) && (!_isOverflow) && (!_isBlackJack))
                                        {

                                            Console.WriteLine("Croupier thinking...");
                                            Thread.Sleep(2000);

                                            Console.WriteLine("Croupier take {0} card(s)",
                                                _game.Croupier.Think());
                                            Console.WriteLine("Calculating result...");
                                            Thread.Sleep(2000);

                                            Console.WriteLine("Croupier points " + _game.Croupier.CalculatePoints());

                                            CheckRules();

                                            if ((!_isPush) && (!_isOverflow) && (!_isBlackJack))
                                            {

                                                switch (_game.Croupier.ComparePoints(_game.Client.CalculatePoints()))
                                                {
                                                    case "WIN!":
                                                        Console.WriteLine("You WIN!");
                                                        break;
                                                    case "LOSE!":
                                                        Console.WriteLine("You LOSE!");
                                                        break;
                                                    default:
                                                        Console.WriteLine("PUSH!");
                                                        break;
                                                }
                                            }
                                        }
                                    }

                                    do
                                    {
                                        Console.WriteLine("Would you like one more game? (yes/no)");
                                        switch (Console.ReadLine())
                                        {
                                            case "yes":
                                                _game.NewGame();
                                                _isEnd = true;
                                                break;
                                            case "no":
                                                //isEnd = true;
                                                Environment.Exit(0);
                                                break;
                                            default:
                                                Console.WriteLine("Sorry, unknown command.");
                                                break;
                                        }


                                    } while (!_isEnd);

                                } while (true);
                            }else { Console.WriteLine("Sorry, unknown command."); }
                        }
                        

                    default: Console.WriteLine("Sorry, unknown command."); break;
                }
            }
        }
    }
}
