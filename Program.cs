﻿using System;
namespace VendingMachineProject;

public class Program
{
    static void Main(string[] args)
    {
        Snacks cola = new Snacks("Cola", 1.50, 10);
        Snacks chocBar = new Snacks("Choc Bar", 1.25, 10);
        Snacks skittles = new Snacks("Skittles", 1.70, 8);
        Snacks bikkies = new Snacks("Bikkies", 1.25, 10);
        Snacks gala = new Snacks("Gala", 1.35, 4);

        Coin coinHandler = new Coin();
        coinHandler.Print();

        while (true)
        {
            Console.WriteLine("##################################");
            Console.WriteLine("#  Mecachrome Vending Merchant  #");
            Console.WriteLine(" #     Hawking Edible Wares    #");
            Console.WriteLine(" ################################ ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("   Snack      --Price   --Qty   ");
            Console.WriteLine($"1. {cola.getSnackName()}       --{cola.getSnackPrice()}     --{cola.getSnackQuantity()} ");
            Console.WriteLine($"2. {chocBar.getSnackName()}   --{chocBar.getSnackPrice()}    --{chocBar.getSnackQuantity()} ");
            Console.WriteLine($"3. {skittles.getSnackName()}   --{skittles.getSnackPrice()}     --{skittles.getSnackQuantity()} ");
            Console.WriteLine($"4. {bikkies.getSnackName()}    --{bikkies.getSnackPrice()}    --{bikkies.getSnackQuantity()} ");
            Console.WriteLine($"5. {gala.getSnackName()}       --{gala.getSnackPrice()}    --{gala.getSnackQuantity()} ");
            Console.WriteLine();
            Console.WriteLine("   Please enter your choice: ");


            int option = Convert.ToInt32(Console.ReadLine());


            switch (option)
            {
                case 1:
                    {
                        Input.AskForInput(cola, coinHandler);
                    }
                    break;

                case 2:
                    {
                        Input.AskForInput(chocBar, coinHandler);
                    }
                    break;

                case 3:
                    {
                        Input.AskForInput(skittles, coinHandler);
                    }
                    break;

                case 4:
                    {
                        Input.AskForInput(bikkies, coinHandler);
                    }
                    break;

                case 5:
                    {
                        Input.AskForInput(gala, coinHandler);
                    }
                    break;

                case 1011:
                    {
                        Console.WriteLine("Please enter password: ");

                        string password = Console.ReadLine();

                        switch (password)
                        {
                            case "A5144l":
                                {
                                    Console.WriteLine("##          ADMIN MENU         ##");
                                    Console.WriteLine("#################################");
                                    Console.WriteLine("#  Mecachrome Vending Merchant  #");
                                    Console.WriteLine(" #     Hawking Edible Wares    #");
                                    Console.WriteLine("#################################");
                                    Console.WriteLine();
                                    Console.WriteLine();
                                    Console.WriteLine("1. Change Snack Prices");
                                    Console.WriteLine("2. Increase Change Pool");
                                    Console.WriteLine("3. See Total Amount of Money in Machine");
                                    Console.WriteLine("4. Go Back To Customer Menu");
                                    Console.WriteLine();
                                    Console.WriteLine("   Please enter your choice: ");

                                    int adminOption = Convert.ToInt32(Console.ReadLine());

                                    switch (adminOption)
                                    {
                                        case 1:
                                            //case statement or tuple implementation
                                            string[] snackInventory = { "Cola", "Choc Bar", "Skittles", "Bikkies", "Gala" };


                                            Console.WriteLine("What snack would you like to increase the price of?");
                                            string snackToChange = Console.ReadLine();
                                            Snacks newSnack = new Snacks(snackToChange);

                                            Console.WriteLine("What would be the new price? ");
                                            double newPrice = Convert.ToDouble(Console.ReadLine());

                                            foreach (string snak in snackInventory)
                                            {
                                                if (snak == snackToChange)
                                                {
                                                    newSnack.setSnackPrice(newPrice);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid Snack Name");
                                                }
                                            }

                                            break;

                                        case 2:
                                            Coin addCoin = new Coin();
                                            Console.WriteLine("What coin would you like to increase the change pool of? ");
                                            double coinKey = Convert.ToDouble(Console.ReadLine());

                                            Console.WriteLine("How many would of this coin would you like to add? ");
                                            int coinAmount = Convert.ToInt32(Console.ReadLine());

                                            if (Input.CoinCheck(coinKey))
                                            {
                                                addCoin.UpdateInventory(coinKey, coinAmount);
                                                addCoin.Print();
                                            }
                                            else
                                            {
                                                Console.WriteLine("Unable To Update. Invalid Coin Type.");
                                            }

                                            break;

                                        case 3:
                                            coinn.sumOfMoneyInPool();
                                            break;

                                        case 4:
                                            //go back to customer menu with "if" statement below
                                            break;

                                        default:

                                            break;
                                    }
                                }
                                break;

                            default:
                                Console.WriteLine("Password incorrect");

                                //option to go to back menu maybe
                                break;
                        }

                    }
                    break;

                default:
                    Console.WriteLine("Please enter an option from 1 - 5");
                    break;
            }

        }
    }

}