using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace hm14_filesystem
{
    internal class CardOwner
    {
        public CardOwner(CreditCard card)
        {
            card.Deposited += HandleDeposit;
            card.Withdrawn += HandleWithdrawal;
            card.CreditStarted += HandleCreditStart;
            card.PINChanged += HandlePINChanged;
        }

        public void HandleDeposit(decimal amount)
        {
            string formatAmount = string.Format(new System.Globalization.CultureInfo("us-US"), "{0:C}", amount);

            Console.WriteLine($"Operation: Deposited {formatAmount}");
        }

        public void HandleWithdrawal(decimal amount)
        {
            string formatAmount = string.Format(new System.Globalization.CultureInfo("us-US"), "{0:C}", amount);

            Console.WriteLine($"Operation: Withdrawn {formatAmount}");
        }

        public void HandleCreditStart(decimal amount)
        {
            string formatAmount = string.Format(new System.Globalization.CultureInfo("us-US"), "{0:C}", amount);

            Console.WriteLine($"Operation: Withdrawn credit funds {formatAmount}");
        }
        public void HandlePINChanged(string newPIN)
        {
            Console.WriteLine($"Operation: PIN changed to {newPIN}");
        }
    }
}