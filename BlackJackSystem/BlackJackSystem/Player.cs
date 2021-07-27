using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlackJackSystem
{
    class Player
    {
        public string Name { get; set; }
        public int handvalue { get; set; }
       
        public List<Card> PlayerHand { get; set; }


        public Player(string name)
        {
            Name = name;
            PlayerHand = new List<Card>();
        }



        public void Card_Charlie(Bet_Chip chip, int num)
        {
            Console.WriteLine($"{Name} WON cause of Five Card Charlie");
            chip.Chip = Calculate.Plus(chip, num);
        }
    }
}
