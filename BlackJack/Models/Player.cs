using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Models
{

    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Card> CardPool { get; }

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

            var maxValueWith11T = 0;
            var maxValueWith1T = 0;
            var maxValueWithAll1T = 0;
            var winPoints = 21;

            if (CardPool.Count(m => m.Name == CardNamesEnum.Ace.ToString()) == 0)
            {
                return CardPool.Sum(pool => pool.Value);
            }
            else
            {
                var aces = CardPool.Where(c => c.Name == CardNamesEnum.Ace.ToString()).ToList();
                var otherCards = CardPool.Where(c => c.Name != CardNamesEnum.Ace.ToString()).ToList();
                var cardsWith11T = new List<Card>() {aces.First() };
                var cardsWith1T = new List<Card>();
                var cardsWithAll1T = new List<Card>();
                cardsWith11T.AddRange(otherCards);
                cardsWith1T.AddRange(otherCards);
                cardsWithAll1T.AddRange(otherCards);

                var aces1 = aces.Select(card => new Card()
                {
                    Name = card.Name,
                    Value = 1,
                    Suit = card.Suit
                }).ToList();

                cardsWith1T.AddRange(aces1);
                cardsWithAll1T.AddRange(new List<Card>(aces1));

                int sum;

                // If ace points = 11
                if (aces.Count == 1)
                {

                    sum = cardsWith11T.Select(c => c.Value).ToArray().Sum();
                    maxValueWith11T = sum;

                    sum = cardsWith11T.Select(c => c.Value).ToArray().Sum()-10;

                    if (maxValueWith11T > winPoints)
                    {
                        maxValueWith11T = sum;
                    }

                }
                else if (aces.Count > 1)
                {
                    // If 1 ace = 11, other aces points = 1
                    sum = cardsWith1T.Select(c => c.Value).ToArray().Sum() + 10;
                    maxValueWith1T = sum;

                    //if all  ace = 1
                    sum = cardsWithAll1T.Select(c => c.Value).ToArray().Sum();
                    maxValueWithAll1T = sum;
                }



            }




            var result11T = winPoints - maxValueWith11T;
            var result1T = winPoints - maxValueWith1T;
            var resultAll1T = winPoints - maxValueWithAll1T;

            var result = new[] { result11T, result1T, resultAll1T }.Where(value => value >= 0);

            return winPoints - result.Min();



        }

        public bool CheckForOverflow()
        {
            if (CalculatePoints() > 21)
            {
                return true;

            }
            return false;
        }

        public bool CheckBlackJack()
        {
            if (CalculatePoints() == 21)
            {
                return true;
            }
            return false;
        }

    }
}
