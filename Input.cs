using System;
using VendingMachineProject;

namespace VendingMachineProject
{

    public static class Input
    {
        public static bool AskForInput(Snacks snack, CoinHandler coinHandler)
        {
            List<double> inputList = new List<double>();
            double price = snack.getSnackPrice();

            if (snack.getSnackQuantity() == 0)
            {
                Console.WriteLine("OUT OF STOCK");
            }
            else
            {
                while (IsSumLowerThanPrice(inputList, price))
                {
                    Console.Write("Please enter coins that total to less than £10: ");

                    double coinsToAdd = Convert.ToDouble(Console.ReadLine());

                    if (CoinCheck(coinsToAdd))
                    {
                        if (IsGreaterThan10(coinsToAdd, inputList))
                        {
                            Console.WriteLine("Coin will not be added, {0} is greater than 10", coinsToAdd + inputList.Sum());
                        }
                        else
                        {
                            inputList.Add(coinsToAdd);
                            coinHandler.HandleCoin(coinsToAdd, 1);
                            snack.reduceSnackQuantity();
                            double change = ChangeChecker(inputList, snack);
                            ChangeToGive(change, coinHandler);
                            Print(coinHandler);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid Coin:");
                    }
                }
            }
            return true;
        }

        private static bool IsGreaterThan10(double numberToAdd, List<double> inputList)
        {
            return numberToAdd + inputList.Sum() > 10;
        }

        private static bool IsSumLowerThanPrice(List<double> inputList, double price)
        {
            return inputList.Sum() < price;
        }

        public static bool CoinCheck(double coinInput)
        {
            double[] coinsss = { 2.0, 1.0, 0.5, 0.2, 0.1, 0.05 };

            if (coinsss.Contains(coinInput))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double ChangeChecker(List<double> inputList, Snacks snack)
        {
            double change = inputList.Sum() - snack.getSnackPrice();
            return change;
        }

        public void ChangeToGive(double change, CoinHandler coinHandler)
        {
            Console.WriteLine($"Change to give: {change}");
        }

        public void Print(CoinHandler coinHandler)
        {
            foreach (var item in coinInventory)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
        