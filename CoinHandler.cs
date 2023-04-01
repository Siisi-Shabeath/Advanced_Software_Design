using System;
using System.Collections.Generic;
using System.Linq;
using VendingMachineProject;

namespace VendingMachineProject
{
    public abstract class CoinHandler
    {
        protected CoinHandler Successor;

        public void SetSuccessor(CoinHandler successor)
        {
            Successor = successor;
        }

        public abstract void HandleCoin(double coinValue, int quantity, ref Dictionary<double, int> coinInventory);
    }
}

