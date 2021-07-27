using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackSystem
{
    class Calculate
    {
        public static int CalculatePlayerValue(Player player)
        {
            player.handvalue = 0;
            foreach (var item in player.PlayerHand)
            {
                player.handvalue += item.facevalue;
            }
            return player.handvalue;
        }
        public static int Calculated(Player player)
        {
            player.handvalue = 0;
            foreach (var item in player.PlayerHand)
            {
                if (item.face == Face.Ace)
                {
                    item.facevalue = 1;
                }
                player.handvalue += item.facevalue;
            }
            return player.handvalue;
        }
        public static int Plus(Bet_Chip chip, int num)
        {
            return chip.Chip + (num*2);
        }
        public static int double_Plus(Bet_Chip chip, int num)
        {
            return chip.Chip + (num * 3);
        }
        public static int Minus(Bet_Chip chip, int num)
        {
            return chip.Chip - num;
        }
        
    }
}
