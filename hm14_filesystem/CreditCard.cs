using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace hm14_filesystem
{
    public class CreditCard
    {
        public string CardNumber { get; init; }
        public string CardholderName { get; init; }
        public string ExpiryDate { get; init; }
        public string PIN { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal Balance { get; set; }



        public event Action<decimal> Deposited;
        public event Action<decimal> Withdrawn;
        public event Action<decimal> CreditStarted;
        public event Action<string> PINChanged;



        public CreditCard(string cardNumber, string cardholderName, string expiryDate, string pin, decimal creditLimit, decimal balance)
        {
            CardNumber = cardNumber;
            CardholderName = cardholderName;
            ExpiryDate = expiryDate;
            PIN = pin;
            CreditLimit = creditLimit;
            Balance = balance;
        }



        public void Deposit(decimal amount)
        {
            Balance += amount;
            Deposited?.Invoke(amount);
        }
        public void Withdraw(decimal amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                Withdrawn?.Invoke(amount);
            }
            else
            {
                decimal creditWithdraw = amount - Balance;
                decimal balanceWithdraw = amount - creditWithdraw;

                Balance -= balanceWithdraw;

                Withdrawn?.Invoke(balanceWithdraw);

                StartCredit(creditWithdraw);
            }
        }
        private void StartCredit(decimal amount)
        {
            if (Balance == 0)
            {
                CreditLimit -= amount;
                CreditStarted?.Invoke(amount);
            }
        }
        public void ChangePIN(string newPIN)
        {
            PIN = newPIN;
            PINChanged?.Invoke(newPIN);
        }



        public override string ToString()
        {
            return
                $"card number: {CardNumber}\n" +
                $"card holder name: {CardholderName}\n" +
                $"expiration: {ExpiryDate}\n" +
                $"pin code: {PIN}\n" +
                $"credit funds: {CreditLimit}\n" +
                $"balance: {Balance}";
        }
    }
}
