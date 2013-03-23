using System;
using System.Collections.Generic;

namespace Bank
{
    class TestBankProgram
    {
        static void Main()
        {
            //Create some customers
            List<Customer> customersList = new List<Customer> 
                                           {
                                            new Individual(1, "Ivan Ivanov", "Sofia", "888888888"),
                                            new Individual(2, "Petar Jotov", "Sofia", "777777777"),
                                            new Company(3, "Elit LTD", "Sofia", "555555555"),
                                            new Company(4, "Gama LTD", "Sofia", "222222222")
                                           };

            //Associate the customers with some accounts
            List<Account> accountsList = new List<Account> 
            {
                 new Deposit(customersList[0], new DateTime(2013, 1, 16), 2000),
                 new Deposit(customersList[0], new DateTime(2013, 2, 20), 500),
                 new Deposit(customersList[1], new DateTime(2013, 2, 1), 2000),
                 new Loan(customersList[2], new DateTime(2013, 1, 5), 2000),
                 new Loan(customersList[3], new DateTime(2012, 1, 5), 10000),
                 new Mortgage(customersList[2], new DateTime(2011, 10, 5), 70000),
            };

            //Calculate interest rates
            Console.WriteLine("Interest rates for all accounts report:");
            foreach (var account in accountsList)
            {
                Console.WriteLine("{0} interest amount is: {1:F2}", account.GetType().Name, account.CalculateInterestAmount());
            }

            //Add money to a deposit
            Console.WriteLine();
            Console.WriteLine("Example that adds money to a deposit account:");
            Deposit deposit1 = new Deposit(customersList[0], new DateTime(2013, 1, 16), 2000);
            Console.WriteLine("The deposit balance is: {0}", deposit1.Balance);
            deposit1.DepositMoney(300);
            Console.WriteLine("Deposit money were added to the account!");
            Console.WriteLine("The new deposit balance is: {0}", deposit1.Balance);
            Console.WriteLine();
            
            //Get the info for all accounts
            foreach (var account in accountsList)
            {
                Console.WriteLine(account.ToString());
                Console.WriteLine(new string('-', 50));
            }
        }
    }
}
