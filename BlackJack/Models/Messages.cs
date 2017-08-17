using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Core;

namespace BlackJack.Models
{
    public class Messages
    {

        public void Hello() { Console.WriteLine("Hello in BlackJack game!"); }
        public void WriteNewGame() { Console.WriteLine("Type <<new game>> for configure game."); }
        public void WriteName() { Console.WriteLine("Enter your name."); }
        public void AskDecksCount() { Console.WriteLine("How many decks will be in the game?"); }
        public void WriteStart() { Console.WriteLine("Type <<start>> for begin game!"); }
        public void GameStarted() { Console.WriteLine("Game started!"); }
        public void DistributionCards() { Console.WriteLine("Distribution cards..."); }
        public void ShowUserStartPool(Client client)
        {
            Console.WriteLine("Your points in card pool: {0}, Cards: {1} {2}, {3} {4}",
                client.CalculatePoints(),
                client.CardPool[0].Name,
                client.CardPool[0].Suit,
                client.CardPool[1].Name,
                client.CardPool[1].Suit);
        }
        public void AskNeedCard() { Console.WriteLine("Do you need the card? (yes/no)"); }
        public void ShowStatusAfterTakeCard(Client client)
        {
            Console.WriteLine("You take {0} {1}, your points now: {2}",
                client.CardPool.Last().Name,
                client.CardPool.Last().Suit,
                client.CalculatePoints());
        }
        public void UnknownCommand() { Console.WriteLine("Sorry, unknown command."); }
        public void CroupierThink() { Console.WriteLine("Croupier thinking..."); }

        public void ShowCardsCountCroupierTake(Croupier croupier)
        {
            Console.WriteLine("Croupier take {0} card(s)", croupier.Think());
        }

        public void ShowCroupierStatusAfterTakeCard(Croupier croupier)
        {
            Console.WriteLine("Croupier points " + croupier.CalculatePoints());
        }
        public void Calculating()
        {
            Console.WriteLine("Calculating result...");
        }
        public void WinPoints() { Console.WriteLine("You WIN! Croupier has a lot of points!"); }
        public void LosePoints() { Console.WriteLine("Defeat! You have a lot of points:("); }
        public void WinBlackJack() { Console.WriteLine("BLACK JACK! YOU WIN!"); }
        public void LoseBlackJack() { Console.WriteLine("Defeat! Croupier have Black Jack!"); }
        public void Push() { Console.WriteLine("PUSH!"); }
        public void AskOneMoreGame() { Console.WriteLine("Would you like one more game? (yes/no)"); }



    }
}
