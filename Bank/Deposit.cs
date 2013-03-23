using System;
using System.Text;

namespace Bank
{
    public class Deposit : Account, IWithdrwable, IDepositable
    {
        public static int amountWithoutInterestRate = 1000;
        public static decimal depositInterestRate = 4.5m/100;

        //Constructor
        public Deposit(Customer customer, DateTime startDate, decimal balance) : base(customer, startDate, balance, depositInterestRate) { }

        public void WithdrawMoney(decimal amount)
        {
            if (amount <= Balance)
            {
                this.Balance = this.Balance - amount;
            }
            else
            {
                throw new ArgumentOutOfRangeException("You cannot withdraw an amount bigger than the account's balance!");
            }
        }

        public void DepositMoney(decimal amount)
        {
            this.Balance = this.Balance + amount;
        }

        public override decimal CalculateInterestAmount()
        {
            if (this.Balance > amountWithoutInterestRate)
            {
                return (this.Balance - amountWithoutInterestRate) * this.MonthlyInterestRate * this.CalculateMonths();
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            StringBuilder depositPrint = new StringBuilder();
            depositPrint.AppendLine("Deposit account information:");
            depositPrint.AppendFormat("Customer information: {0}", this.Customer.ToString());
            depositPrint.AppendLine();
            depositPrint.AppendFormat("Account type: {0}", this.GetType().Name);
            depositPrint.AppendLine();
            depositPrint.AppendFormat("Deposit start date: {0:F}", this.StartDate.ToString());
            depositPrint.AppendLine();
            depositPrint.AppendLine(new string ('-', 50));
            depositPrint.AppendFormat("Balance: {0:F2}",this.Balance.ToString());
            depositPrint.AppendLine();
            depositPrint.AppendFormat("Account interest amount as of today: {0:F2}", this.CalculateInterestAmount());
            depositPrint.AppendLine();
            depositPrint.AppendFormat("Total account balance: {0:F2}", this.Balance + this.CalculateInterestAmount());
            depositPrint.AppendLine();
            depositPrint.AppendLine(new string('-', 50));
           

            return depositPrint.ToString();
        }
    }
}
