using System;
using System.Text;

namespace Bank
{
    public class Mortgage : Account, IDepositable
    {
        public static int monthsHalfInterestIndividual = 6;
        public static int monthsHalfInterestCompany = 12;
        public static decimal mortgageInterestRate = 3.25m/100;

        //Constructor
        public Mortgage(Customer customer, DateTime startDate, decimal balance) : base(customer, startDate, balance, mortgageInterestRate) { }

        public void DepositMoney(decimal amount)
        {
            if (amount <= Balance)
            {
                this.Balance = this.Balance - amount;
            }
            else
            {
                throw new ArgumentOutOfRangeException("You give us too much money!");
            }
        }

        public override decimal CalculateInterestAmount()
        {
            int mortgageDuration = this.CalculateMonths();
            if ((this.Customer is Individual) && mortgageDuration > monthsHalfInterestIndividual)
            {
                return monthsHalfInterestIndividual * (this.MonthlyInterestRate / 2) * this.Balance + (mortgageDuration - monthsHalfInterestIndividual) * this.MonthlyInterestRate * this.Balance;
            }
            else if ((this.Customer is Individual) && mortgageDuration <= monthsHalfInterestIndividual)
            {
                return mortgageDuration * (this.MonthlyInterestRate / 2) * this.Balance;
            }
            else if ((this.Customer is Company) && mortgageDuration > monthsHalfInterestCompany)
            {
                return monthsHalfInterestCompany * (this.MonthlyInterestRate / 2) * this.Balance + (mortgageDuration - monthsHalfInterestCompany) * this.MonthlyInterestRate * this.Balance;
            }
            else if ((this.Customer is Company) && mortgageDuration <= monthsHalfInterestCompany)
            {
                return mortgageDuration * (this.MonthlyInterestRate / 2) * this.Balance;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            StringBuilder mortgagePrint = new StringBuilder();
            mortgagePrint.AppendLine("Mortgage account information:");
            mortgagePrint.AppendFormat("Customer information: {0}", this.Customer.ToString());
            mortgagePrint.AppendLine();
            mortgagePrint.AppendFormat("Account type: {0}", this.GetType().Name);
            mortgagePrint.AppendLine();
            mortgagePrint.AppendFormat("Mortgage start date: {0:F}", this.StartDate.ToString());
            mortgagePrint.AppendLine();
            mortgagePrint.AppendLine(new string('-', 50));
            mortgagePrint.AppendFormat("Balance: {0:F2}", this.Balance.ToString());
            mortgagePrint.AppendLine();
            mortgagePrint.AppendFormat("Account interest amount as of today: {0:F2}", this.CalculateInterestAmount());
            mortgagePrint.AppendLine();
            mortgagePrint.AppendFormat("Total account balance: {0:F2}", this.Balance + this.CalculateInterestAmount());
            mortgagePrint.AppendLine();
            mortgagePrint.AppendLine(new string('-', 50));


            return mortgagePrint.ToString();
        }
    }
}
