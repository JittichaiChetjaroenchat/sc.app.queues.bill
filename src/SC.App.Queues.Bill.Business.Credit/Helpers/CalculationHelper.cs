using System;

namespace SC.App.Queues.Bill.Business.Credit.Helpers
{
    public class CalculationHelper
    {
        public static decimal Calculate(decimal balance, decimal amount)
        {
            return balance + amount;
        }

        public static int Calculate(int balance, decimal amount)
        {
            return Convert.ToInt32(balance + amount);
        }
    }
}