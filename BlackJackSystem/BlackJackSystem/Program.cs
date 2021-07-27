using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlackJackSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Bet_Chip bet_Chip = new Bet_Chip();
            while (true)
            {
                string hit = "HIT", stand = "STAND", no = "N";
                Deck deck = new Deck();
                deck.CreateDeck();
                other_method.yellow_text("       Welcome to BlackJack Game", "\nPlease enter your name: ");
                Player player = new Player(Console.ReadLine());
                Console.WriteLine($"Enter Your Bet: \t Available Chip:{bet_Chip.Chip}");
                bool check=int.TryParse(Console.ReadLine(), out int bet);
                if (check == false)
                {
                    other_method.others("Can't insert alphabet");
                }
                else
                {
                    if (bet < 0)
                    {
                        other_method.others("Can't insert negative no");
                    }
                    else
                    {
                        other_method.Print_Card_And_Handvalue(player, deck, bet_Chip, bet);
                        Player dealer = new Player("Dealer");
                        other_method.Print_Card_And_Handvalue_dealer(dealer, deck);

                        if ((player.handvalue == 21 && dealer.handvalue == 21) || (player.handvalue == 22 && dealer.handvalue == 22) || (player.handvalue == 21 && dealer.handvalue == 22) || (player.handvalue == 22 && dealer.handvalue == 21))
                        {
                            other_method.Print_Card_AndHandvalue(dealer, ConsoleColor.Green);
                            Console.WriteLine($"{player.Name} and {dealer.Name} are both got BLACKJACK");
                            Console.WriteLine("This match is draw.");
                        }
                        else if (player.handvalue == 21 || player.handvalue == 22)
                        {
                            Console.WriteLine($"{player.Name} got BLACKJACK, {player.Name} won");
                            bet_Chip.Chip = Calculate.double_Plus(bet_Chip, bet);
                        }
                        else if (dealer.handvalue == 21 || dealer.handvalue == 22)
                        {
                            other_method.Print_Card_AndHandvalue(dealer, ConsoleColor.Green);
                            Console.WriteLine($"{dealer.Name} got BLACKJACK, {dealer.Name} won");
                            bet_Chip.Chip = Calculate.Minus(bet_Chip, bet);
                        }
                        else if (player.handvalue < 16)
                        {
                            while (true)
                            {
                                Console.WriteLine("Minimum card value is 16, Please type HIT to get a card.");
                                string opt = Console.ReadLine();
                                if (opt != hit.ToLower() && opt != hit)
                                {
                                    Console.WriteLine($"Please select {hit} or {stand} ");
                                }
                                else
                                {
                                    other_method.for_(player,deck, ConsoleColor.Yellow);
                                    if (player.handvalue >= 16 && player.handvalue <= 21 && player.PlayerHand.Count() > 4)
                                    {
                                        player.Card_Charlie( bet_Chip, bet);
                                        break;
                                    }
                                    else if (player.handvalue >= 16 && player.handvalue <= 21)
                                    {
                                        Console.WriteLine($"{hit} or {stand}");
                                        string hit_stand = Console.ReadLine();

                                        if (hit_stand == stand.ToLower() || hit_stand == stand)
                                        {
                                            if (dealer.handvalue < 16)
                                            {
                                                other_method.dealer_handvalue_smaller_than_sixteen(player, dealer, deck, ConsoleColor.Green, bet_Chip, bet);
                                            }
                                            else
                                            {
                                                other_method.else_(player, dealer, ConsoleColor.Green, bet_Chip, bet);
                                            }
                                            break;
                                        }
                                        else
                                        {
                                            if (player.PlayerHand.Count < 4)
                                            {
                                                other_method.Printing_Card_And_Handvalue(player, deck, ConsoleColor.Yellow);

                                                if (player.handvalue > 21)
                                                {
                                                    if (dealer.handvalue < 16)
                                                    {
                                                        other_method.dealer_handvalue_smaller_than_sixteen_but_player_busted(player, dealer, deck, ConsoleColor.Green);
                                                    }
                                                    else
                                                    {
                                                        other_method.else_player_busted(player, dealer, ConsoleColor.Green);
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"{hit} or {stand}");
                                                    hit_stand = Console.ReadLine();

                                                    if (hit_stand == stand.ToLower() || hit_stand == stand)
                                                    {
                                                        if (dealer.handvalue < 16)
                                                        {
                                                            other_method.dealer_handvalue_smaller_than_sixteen(player, dealer, deck, ConsoleColor.Green, bet_Chip, bet);
                                                        }
                                                        else
                                                        {
                                                            other_method.else_(player, dealer, ConsoleColor.Green, bet_Chip, bet);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        other_method.Printing_Card_And_Handvalue(player, deck, ConsoleColor.Yellow);

                                                        if (player.handvalue > 21)
                                                        {
                                                            if (dealer.handvalue < 16)
                                                            {
                                                                other_method.dealer_handvalue_smaller_than_sixteen_but_player_busted(player, dealer, deck, ConsoleColor.Green);
                                                            }
                                                            else
                                                            {
                                                                other_method.else_player_busted(player, dealer, ConsoleColor.Green);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            player.Card_Charlie( bet_Chip, bet);
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                other_method.Printing_Card_And_Handvalue(player, deck, ConsoleColor.Yellow);

                                                if (player.handvalue > 21)
                                                {
                                                    if (dealer.handvalue < 16)
                                                    {
                                                        other_method.dealer_handvalue_smaller_than_sixteen_but_player_busted(player, dealer, deck, ConsoleColor.Green);
                                                    }
                                                    else
                                                    {
                                                        other_method.else_player_busted(player, dealer, ConsoleColor.Green);
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    player.Card_Charlie( bet_Chip, bet);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    else if (player.handvalue > 21)
                                    {
                                        if (dealer.handvalue < 16)
                                        {
                                            other_method.dealer_handvalue_smaller_than_sixteen_but_player_busted(player, dealer, deck, ConsoleColor.Green);
                                        }
                                        else
                                        {
                                            other_method.else_player_busted(player, dealer, ConsoleColor.Green);
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        bet_Chip.Chip = Calculate.Plus(bet_Chip, bet);
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            while (true)
                            {
                                Console.WriteLine($"{hit} or {stand}");
                                string opt = Console.ReadLine();

                                if (opt == hit.ToLower() || opt == hit)
                                {
                                    other_method.for_(player,deck, ConsoleColor.Yellow);
                                    if (player.handvalue >= 16 && player.handvalue <= 21 && player.PlayerHand.Count() > 4)
                                    {
                                        player.Card_Charlie( bet_Chip, bet);
                                        break;
                                    }
                                    else if (player.handvalue > 21)
                                    {
                                        if (dealer.handvalue < 16)
                                        {
                                            other_method.dealer_handvalue_smaller_than_sixteen_but_player_busted(player, dealer, deck, ConsoleColor.Green);
                                        }
                                        else
                                        {
                                            other_method.else_player_busted(player, dealer, ConsoleColor.Green);
                                        }
                                        break;
                                    }
                                    else if (player.handvalue >= 16 && player.handvalue <= 21)
                                    {
                                        Console.WriteLine($"{hit} or {stand}");
                                        string hit_stand = Console.ReadLine();

                                        if (hit_stand == stand.ToLower() || hit_stand == stand)
                                        {
                                            if (dealer.handvalue < 16)
                                            {
                                                other_method.dealer_handvalue_smaller_than_sixteen(player, dealer, deck, ConsoleColor.Green, bet_Chip, bet);
                                            }
                                            else
                                            {
                                                other_method.else_(player, dealer, ConsoleColor.Green, bet_Chip, bet);
                                            }
                                            break;
                                        }
                                        else
                                        {
                                            if (player.PlayerHand.Count < 4)
                                            {
                                                other_method.Printing_Card_And_Handvalue(player, deck, ConsoleColor.Yellow);

                                                if (player.handvalue > 21)
                                                {
                                                    if (dealer.handvalue < 16)
                                                    {
                                                        other_method.dealer_handvalue_smaller_than_sixteen_but_player_busted(player, dealer, deck, ConsoleColor.Green);
                                                    }
                                                    else
                                                    {
                                                        other_method.else_player_busted(player, dealer, ConsoleColor.Green);
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    Console.WriteLine($"{hit} or {stand}");
                                                    hit_stand = Console.ReadLine();

                                                    if (hit_stand == stand.ToLower() || hit_stand == stand)
                                                    {
                                                        if (dealer.handvalue < 16)
                                                        {
                                                            other_method.dealer_handvalue_smaller_than_sixteen(player, dealer, deck, ConsoleColor.Green, bet_Chip, bet);
                                                        }
                                                        else
                                                        {
                                                            other_method.else_(player, dealer, ConsoleColor.Green, bet_Chip, bet);
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        other_method.Printing_Card_And_Handvalue(player, deck, ConsoleColor.Yellow);

                                                        if (player.handvalue > 21)
                                                        {
                                                            if (dealer.handvalue < 16)
                                                            {
                                                                other_method.dealer_handvalue_smaller_than_sixteen_but_player_busted(player, dealer, deck, ConsoleColor.Green);
                                                            }
                                                            else
                                                            {
                                                                other_method.else_player_busted(player, dealer, ConsoleColor.Green);
                                                            }
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            player.Card_Charlie( bet_Chip, bet);
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                other_method.Printing_Card_And_Handvalue(player, deck, ConsoleColor.Yellow);

                                                if (player.handvalue > 21)
                                                {
                                                    if (dealer.handvalue < 16)
                                                    {
                                                        other_method.dealer_handvalue_smaller_than_sixteen_but_player_busted(player, dealer, deck, ConsoleColor.Green);
                                                    }
                                                    else
                                                    {
                                                        other_method.else_player_busted(player,dealer, ConsoleColor.Green);
                                                    }
                                                    break;
                                                }
                                                else
                                                {
                                                    player.Card_Charlie( bet_Chip, bet);
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        bet_Chip.Chip = Calculate.Plus(bet_Chip, bet);
                                        break;
                                    }
                                }
                                else if (opt == stand.ToLower() || opt == stand)
                                {
                                    if (dealer.handvalue < 16)
                                    {
                                        other_method.dealer_handvalue_smaller_than_sixteen(player, dealer, deck, ConsoleColor.Green, bet_Chip, bet);
                                    }
                                    else
                                    {
                                        other_method.else_(player,dealer, ConsoleColor.Green, bet_Chip, bet);
                                    }
                                    break;
                                }
                            }
                        }
                        Console.WriteLine("Do you want to play again? (Y/N)");
                        string yn = Console.ReadLine();
                        if (yn == no.ToLower() || yn == no)
                        {
                            System.Environment.Exit(0);
                        }
                        Console.Clear();
                    }
                }
            }
        }
    }
}
