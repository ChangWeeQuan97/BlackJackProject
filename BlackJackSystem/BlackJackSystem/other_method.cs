using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlackJackSystem
{
    class other_method
    {
        public static void yellow_text(string s, string t)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine(s);
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.ResetColor();
            Console.WriteLine(t);
        }
        public static void red_text(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(s);
            Console.ResetColor();
        }
        public static void PrintforUser()
        {
            Console.Write("Press Y or any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public static void others(string s)
        {
            red_text(s);
            PrintforUser();
        }
        public static void PrintPlayerHand(Player player, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            foreach (var card in player.PlayerHand)
            {
                card.Printcard();
            }
            Console.ResetColor();
        }
        public static void Print_Card_And_Handvalue(Player player, Deck deck, Bet_Chip chip, int num)
        {
            Console.WriteLine(deck.deck.Count() + " Card");
            deck.Shuffle();
            Console.WriteLine("Shuffling....");
            Thread.Sleep(1000);
            Console.Clear();
            Bet_Chip.bet_chip(chip, num);
            Console.WriteLine($"{player.Name}'s Hand Card");
            player.PlayerHand.Add(deck.DealCard());
            player.PlayerHand.Add(deck.DealCard());
            Thread.Sleep(1000);
            PrintPlayerHand(player, ConsoleColor.Yellow);
            player.handvalue = Calculate.CalculatePlayerValue(player);
            Console.WriteLine($"{player.Name} Hand Value is { player.handvalue}");
        }
        public static void Print_Card_And_Handvalue_dealer(Player dealer, Deck deck)
        {
            Console.WriteLine($"{dealer.Name}'s Hand Card");
            dealer.PlayerHand.Add(deck.DealCard());
            PrintPlayerHand(dealer, ConsoleColor.Green);
            dealer.PlayerHand.Add(deck.DealCard());
            other_method.red_text("<Hidden Card>");
            Thread.Sleep(1000);
            dealer.handvalue = Calculate.CalculatePlayerValue(dealer);
            Console.WriteLine($"{dealer.Name} Hand Value is Unknown");
        }
        public static void Printing_Card_And_Handvalue(Player player, Deck deck, ConsoleColor color)
        {
            player.PlayerHand.Add(deck.DealCard());
            PrintPlayerHand(player, color);
            player.handvalue = Calculate.Calculated(player);
            Console.WriteLine($"{player.Name} Hand Value is {player.handvalue}");
        }
        public static void Print_Card_AndHandvalue(Player player, ConsoleColor color)
        {
            PrintPlayerHand(player, color);
            player.handvalue = Calculate.CalculatePlayerValue(player);
            Console.WriteLine($"{player.Name} Hand Value is {player.handvalue}");
        }

        public static void for_(Player player, Deck deck, ConsoleColor color)
        {
            for (int i = 0; i < 3; i++)
            {
                Printing_Card_And_Handvalue(player, deck, color);
                Thread.Sleep(1000);
                if (player.handvalue > 21)
                {
                    break;
                }
                else if (player.handvalue >= 16 && player.handvalue <= 21)
                {
                    break;
                }
                else
                {
                    if (i > 1)
                    {
                        Console.WriteLine($"{player.Name} WON cause of Five Card Charlie");
                        break;
                    }
                }
            }
        }
        public static void else_(Player player, Player dealer, ConsoleColor color, Bet_Chip chip, int num)
        {
            Print_Card_AndHandvalue(dealer, color);

            if (dealer.handvalue > player.handvalue)
            {
                Console.WriteLine($"{dealer.Name} won");
            }
            else if (dealer.handvalue == player.handvalue)
            {
                Console.WriteLine("This match is draw.");
            }
            else
            {
                Console.WriteLine($"{player.Name} won");
                chip.Chip = Calculate.Plus(chip, num);
            }
        }
        public static void else_player_busted(Player player, Player dealer, ConsoleColor color)
        {
            Print_Card_AndHandvalue(dealer, color);
            Console.WriteLine($"{player.Name} busted, {dealer.Name} won");
        }
        public static void dealer_handvalue_smaller_than_sixteen(Player player, Player dealer, Deck deck, ConsoleColor color, Bet_Chip chip, int num)
        {
            for_(dealer, deck, color);
            if (dealer.handvalue >= 16 && dealer.handvalue <= 21 && dealer.PlayerHand.Count() > 4)
            {
                Console.WriteLine($"{dealer.Name} WON cause of Five Card Charlie");
            }
            else if (dealer.handvalue > 21)
            {
                Console.WriteLine($"{dealer.Name} busted, {player.Name} won");
                chip.Chip = Calculate.Plus(chip, num);
            }
            else if (dealer.handvalue >= 16 && dealer.handvalue <= 21)
            {
                if (dealer.handvalue > player.handvalue)
                {
                    Console.WriteLine($"{dealer.Name} won");
                }
                else if (dealer.handvalue == player.handvalue)
                {
                    Console.WriteLine("This match is draw.");
                }
                else
                {
                    Console.WriteLine($"{player.Name} won");
                    chip.Chip = Calculate.Plus(chip, num);
                }
            }
            else
            {

            }
        }
        public static void dealer_handvalue_smaller_than_sixteen_but_player_busted(Player player, Player dealer, Deck deck, ConsoleColor color)
        {
            for_(dealer, deck, color);
            if (dealer.handvalue >= 16 && dealer.handvalue <= 21 && dealer.PlayerHand.Count() > 4)
            {
                Console.WriteLine($"{dealer.Name} WON cause of Five Card Charlie");
            }
            if (dealer.handvalue > 21)
            {
                Console.WriteLine($"{player.Name} and {dealer.Name} are both busted");
                Console.WriteLine("This match is draw.");
            }
            else if (dealer.handvalue >= 16 && dealer.handvalue <= 21)
            {
                Console.WriteLine($"{player.Name} busted, {dealer.Name} won");
            }
            else
            {

            }
        }
    }
}
