using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSystem
{
    class Bet_Chip
    {
        public int Chip { get; set; }

        public Bet_Chip()
        {
            Chip = 1000;
        }
        public static void bet_chip(Bet_Chip chip, int num)
        {
            chip.Chip = Calculate.Minus(chip, num);
            Console.WriteLine($"Bet : {num}\t Chip : {chip.Chip}"); 
        }
    }
}
