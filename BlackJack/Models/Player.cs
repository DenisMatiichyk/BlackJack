using System;
using System.Collections.Generic;
using System.Linq;
using BlackJack.Core;

namespace BlackJack.Models
{

    public class Player :GameResultStates
    {
        public IGameResultState State { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Card> CardPool { get; }
      
        const int WinPoints = 21;

        protected Player()
        {
           CardPool = new List<Card>();
        }

     
        public void TakeCard(Card card)
        {
            CardPool.Add(card);
        }

        public int CalculatePoints()
        {

            var maxValueWithOneAce11Points = 0;
            var maxValueWithAce11PontsOther1Points = 0;
            var maxValueWithAllAce1Points = 0;

            if (!IsPoolContainsAce())
            {
                return CardPool.Sum(pool => pool.Value);
            }

            // Get aces.
            var aces = CardPool.Where(c => c.Name == CardNamesEnum.Ace.ToString()).ToList();

            // Get cards without aces.
            var otherCards = CardPool.Where(c => c.Name != CardNamesEnum.Ace.ToString()).ToList();

            var cardsWithOneAce11Points = new List<Card>() { aces.First() };
            var cardsWithAce11PontsOther1Points = new List<Card>();
            var cardsWithAllAce1Points = new List<Card>();

            cardsWithOneAce11Points.AddRange(otherCards);
            cardsWithAce11PontsOther1Points.AddRange(otherCards);
            cardsWithAllAce1Points.AddRange(otherCards);

            var aces1 = aces.Select(card => new Card()
            {
                Name = card.Name,
                Value = 1,
                Suit = card.Suit
            }).ToList();

            cardsWithAce11PontsOther1Points.AddRange(aces1);
            cardsWithAllAce1Points.AddRange(new List<Card>(aces1));

            if (aces.Count == 1)
            {
                // If ace points = 11.
                maxValueWithOneAce11Points = GetValueIfOneAce(cardsWithOneAce11Points, WinPoints);

            }
            else if (aces.Count > 1)
            {
                // If 1 ace = 11, other aces points = 1.
                maxValueWithAce11PontsOther1Points = GetValueIfOneAce11Points(cardsWithAce11PontsOther1Points);

                // If all  ace = 1.
                maxValueWithAllAce1Points = GetValueIfAllAce1Ponts(cardsWithAllAce1Points);
            }

            return GetNearestValue(maxValueWithOneAce11Points, maxValueWithAce11PontsOther1Points,
                                   maxValueWithAllAce1Points, WinPoints);

        }

        private int GetNearestValue(int maxValueWithOne11PointAce, int maxValueWithAce11PontsOther1Points,
                                    int maxValueWithAllAce1Points, int winPoints)
        {

            var result1T = winPoints - maxValueWithAce11PontsOther1Points;
            var resultAll1T = winPoints - maxValueWithAllAce1Points;

            var result = new[] { result1T, resultAll1T }.Where(value => value >= 0);

            if ((maxValueWithAce11PontsOther1Points == 0) && (maxValueWithAllAce1Points == 0))
            {
                return maxValueWithOne11PointAce;
            }

            try
            {
                return winPoints - result.Min();
            }
            catch (InvalidOperationException)
            {
                return maxValueWithAllAce1Points;
            }


        }

        private int GetValueIfAllAce1Ponts(List<Card> cardsWithAllAce1Ponts)
        {
            // If all  ace = 1.
            return cardsWithAllAce1Ponts.Select(c => c.Value).ToArray().Sum();
        }

        private int GetValueIfOneAce11Points(List<Card> cardsWithOneAce11Points)
        {
            // If 1 ace = 11, other aces points = 1.
            return cardsWithOneAce11Points.Select(c => c.Value).ToArray().Sum() + 10; // "+ 10" simulate one 
                                                                                      // ace with 11 points.
        }

        private int GetValueIfOneAce(List<Card> cardsWithOneAce, int winPoints)
        {
            var sum = cardsWithOneAce.Select(c => c.Value).ToArray().Sum();
            var result = sum;

            sum = cardsWithOneAce.Select(c => c.Value).ToArray().Sum() - 10; // "- 10" - because ace 
                                                                             // value = 11, but we need 
                                                                             // ace value = 1.

            if (result > winPoints)
            {
                result = sum;
            }
            return result;
        }

        private bool IsPoolContainsAce()
        {
            return CardPool.Count(m => m.Name == CardNamesEnum.Ace.ToString()) > 0;
        }

        public bool CheckForOverflow()
        {
            if (CalculatePoints() > WinPoints)
            {
               
                return true;

            }
            return false;
        }

        public bool CheckBlackJack()
        {
            if (CalculatePoints() == WinPoints)
            {
                return true;
            }
            return false;
        }
    }
}
