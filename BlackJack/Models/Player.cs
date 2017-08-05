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
            
            if (CardPool.Count(m => m.Name == "T") == 0)
            {
                return CardPool.Sum(pool => pool.Value);
            }
            else
            {
                var aces = CardPool.Where(c => c.Name == "T").ToList();
                var otherCards = CardPool.Where(c => c.Name != "T").ToList();
                var cardsWith11T = new List<Card>() { aces.First() };
                var cardsWith1T = new List<Card>();
                cardsWith11T.AddRange(otherCards);
                cardsWith1T.AddRange(otherCards);

                var aces1 = aces.Select(card => new Card()
                {
                    Name = card.Name,
                    Value = 1,
                    Suit = card.Suit
                }).ToList();

                cardsWith1T.AddRange(aces1);
                
                if (aces.Count == 1)
                {

                    var sum = cardsWith11T.Select(c => c.Value).ToArray().Sum();
                    if (maxValueWith11T < sum)
                    {
                        maxValueWith11T = sum;
                    }

                }
                else if (aces.Count > 1)
                {
                    cardsWith1T.Last().Value = 11;
                  
                    var sum = cardsWith1T.Select(c => c.Value).ToArray().Sum();
                    if (maxValueWith1T < sum)
                    {
                        maxValueWith1T = sum;
                    }

                }
            }
            
            if ((maxValueWith11T > maxValueWith1T))
            {
                return maxValueWith11T;
            }
            else
            {
                return maxValueWith1T;

            }

        }

        public bool CheckForOverflow()
        {
            if (CalculatePoints()>21)
            {
                return true;

            }
            return false;
        }

        public bool CheckBlackJack()
        {
            if (CalculatePoints()==21)
            {
                return true;
            }
            return false;
        }
       
    }
}
