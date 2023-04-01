/*using System;
using System.Drawing;
using System.Threading.Channels;

namespace VendingMachineProject
{
	public class Coin
	{
		private Dictionary<double, int> coinInventory;

        public Coin()
        {
			coinInventory = new Dictionary<double, int>();
			coinInventory.Add(2.0, 2);
            coinInventory.Add(1.0, 3);
            coinInventory.Add(0.5, 4);
            coinInventory.Add(0.2, 5);
            coinInventory.Add(0.1, 10);
			coinInventory.Add(0.05, 20);
        }

		public Dictionary<double, int> GetCoinInventory()
		{
			return coinInventory;
		}

        public void SetCoinInventory(Dictionary<double, int> newInventory)
        {
            coinInventory = newInventory;
        }

		public bool UpdateInventory(double key, int quantity)
		{
			int currentQuantity;

			if(coinInventory.TryGetValue(key, out currentQuantity))
			{
				coinInventory[key] = currentQuantity + quantity;
				return true;
			}
			return false;
		}

		public void Print()
		{
			foreach (KeyValuePair<double, int> kvp in coinInventory)
			{
				Console.WriteLine("Coin: {0} , Quantity: {1}", kvp.Key, kvp.Value);
			}
			
		}

        public double ChangeChecker(List<double> input, Snacks snack)
        {
            //if statement to check if equal to

            double total = input.Sum();

            double change = total - snack.getSnackPrice();

           return change;
        }

		public void ChangeToGive(double change)
		{
			List<double> changeCoins = new List<double>();
			double[] coinsss = { 2.0, 1.0, 0.5, 0.2, 0.1, 0.050 };

            //meant to be the reduced change as the program progresses.
            //without actually touching the actual change so that
            //change can be used as a parameter
            decimal changeHolder = Convert.ToDecimal(change);

			while (changeHolder > 0)
			{
                //double closest = coinsss[0];

                List<double> coinsLessThanCoinList = new List<double>();

                foreach (double coin in coinsss)
				{
					//put all values less than coin in a list
					if(coin <= Convert.ToDouble(changeHolder))
					{
                        coinsLessThanCoinList.Add(coin);
                    }
			
                }

                //assign the first variable as the change
                decimal actualChange = Convert.ToDecimal(coinsLessThanCoinList[0]);

                //add the first variable to list of change
                changeCoins.Add(Convert.ToDouble(actualChange));

                //minus [0] from change to update change
                changeHolder -= actualChange;

            }

            foreach (double number in changeCoins)
            {
                Console.WriteLine(number);
            }


            removeFromCoinInventory(changeCoins);
            //check if coin is in coin pool if not use next available coin

            //remove coin from pool when change is complete

            //method for if coin pool is finished therefore unable to provide change
        }

        public bool IsChangeComplete(double change)
        {
			List<double> changePool = new List<double>();

            double total = changePool.Sum();

            if (total < change)
			{
				return true;
			}
			else
			{
                return false;
            }
        }

        public void sumOfMoneyInPool()
        {
            List<decimal> sumOfEachCoin = new List<decimal>();
            //read dictionary of coin in money pool
            //return key x value to get total amount
            foreach (KeyValuePair<double, int> kvp in coinInventory)
            {
                decimal eachCoinValue = Convert.ToDecimal(kvp.Key) * Convert.ToDecimal(kvp.Value);
                sumOfEachCoin.Add(eachCoinValue);
            }

            Console.WriteLine(sumOfEachCoin.Sum());
        }

        public void removeFromCoinInventory(List<double>changeCoins)
        {
            foreach (double coin in changeCoins)
            {
                if (coinInventory.ContainsKey(coin))
                {
                    coinInventory[coin]--;
                    //Console.WriteLine("in here");
                    
                }
                //to see if coin is available for change
                else
                {
                    Console.WriteLine("Error: Coin not found in inventory!");
                }
            }


        }
    }
}

*/
using System;
using VendingMachineProject;

public class Coin : CoinHandler
{
    private Dictionary<double, int> coinInventory = new Dictionary<double, int>
        {
            {2.0, 10},
            {1.0, 10},
            {0.5, 10},
            {0.2, 10},
            {0.1, 10},
            {0.05, 10},
        };

    public void UpdateInventory(double coinValue, int coinAmount)
    {
        if (coinInventory.ContainsKey(coinValue))
        {
            coinInventory[coinValue] += coinAmount;
        }
    }

    public override void HandleCoin(double coinValue, int coinAmount, ref Dictionary<double, int> coinInventory)
    {
        if (coinInventory.ContainsKey(coinValue))
        {
            UpdateInventory(coinValue, coinAmount);
            Console.WriteLine("Coin accepted: {0}, amount: {1}", coinValue, coinAmount);

            if (Successor != null)
            {
                Successor.HandleCoin(coinValue, coinAmount, ref coinInventory);
            }
            else
            {
                Console.WriteLine("Coin not supported: {0}", coinValue);
            }
        }
    }
}