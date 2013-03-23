using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public abstract class Account
    {
        //Fields
        private Customer customer;
        private decimal balance;
        private decimal monthlyInterestRate;
        private DateTime startDate;

        //Properties
        public Customer Customer
        {
            get { return customer; }
            set { customer = value; }
        }

        public decimal Balance
        {
            get { return balance; }
            set { balance = value; }
        }      

        public decimal MonthlyInterestRate
        {
            get { return monthlyInterestRate; }
            set { monthlyInterestRate = value; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        //Constructor
        public Account(Customer customer, DateTime startDate, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.StartDate = startDate;
            this.Balance = balance;
            this.MonthlyInterestRate = interestRate;
        }

        //Methods
        public int CalculateMonths()
        {
            return (int)(DateTime.Now.Subtract(StartDate).TotalDays / 30);
        }

        public virtual decimal CalculateInterestAmount()
        {
            return CalculateMonths() * MonthlyInterestRate;
        }
    }
}
