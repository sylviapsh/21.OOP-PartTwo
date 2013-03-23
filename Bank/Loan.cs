using System;
using System.Text;

namespace Bank
{
    public class Loan : Account, IDepositable
    {
        public static int freeOfInterestMonthsIndividual = 3;
        public static int freeOfInterestMonthsCompany = 2;
        public static decimal loanInterestRate = 3.25m/100;

        //Constructor
        public Loan(Customer customer, DateTime startDate, decimal balance) : base(customer, startDate, balance, loanInterestRate) { }

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
            int loanDuration = this.CalculateMonths();
            if ((this.Customer is Individual) && loanDuration > freeOfInterestMonthsIndividual)
            {
                return (loanDuration - freeOfInterestMonthsIndividual) * this.MonthlyInterestRate * this.Balance;
            }
            else if ((this.Customer is Company) && loanDuration > freeOfInterestMonthsCompany)
            {
                return (loanDuration - freeOfInterestMonthsCompany) * this.MonthlyInterestRate * this.Balance;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            StringBuilder loanPrint = new StringBuilder();
            loanPrint.AppendLine("Loan account information:");
            loanPrint.AppendFormat("Customer information: {0}", this.Customer.ToString());
            loanPrint.AppendLine();
            loanPrint.AppendFormat("Account type: {0}", this.GetType().Name);
            loanPrint.AppendLine();
            loanPrint.AppendFormat("Loan start date: {0:F}", this.StartDate.ToString());
            loanPrint.AppendLine();
            loanPrint.AppendLine(new string('-', 50));
            loanPrint.AppendFormat("Balance: {0:F2}", this.Balance.ToString());
            loanPrint.AppendLine();
            loanPrint.AppendFormat("Account interest amount as of today: {0:F2}", this.CalculateInterestAmount());
            loanPrint.AppendLine();
            loanPrint.AppendFormat("Total account balance: {0:F2}", this.Balance + this.CalculateInterestAmount());
            loanPrint.AppendLine();
            loanPrint.AppendLine(new string('-', 50));


            return loanPrint.ToString();
        }
    }
}
