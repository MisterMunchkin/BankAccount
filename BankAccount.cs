using System;
using System.Collections.Generic;

namespace classes
{
    public class BankAccount
    {
        private static int accountNumberSeed = 1234567890;
        public string Number {get; }
        public string Owner {get; set; }
        public decimal Balance{
            get
            {
                decimal balance = 0;
                foreach(var item in allTransactions){
                    balance += item.Amount;
                }

                return balance;
            }
        }

        public string password {get;set;}

        private List<Transaction> allTransactions = new List<Transaction>();
        public BankAccount(string name, decimal initialBalance, string password)
        {
            this.Owner = name;
            MakeDeposit(initialBalance, DateTime.Now, "Initial Balance");
            
            this.Number = accountNumberSeed.ToString();
            accountNumberSeed++;

            this.password = password;
        }

        public BankAccount(){}
        public void MakeDeposit(decimal amount, DateTime date, string note){
            if(amount <= 0){
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be negative");
            }
            var deposit = new Transaction(amount,date,note);
            allTransactions.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note){
            if(amount <= 0){
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if(Balance - amount < 0){
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }

            var withdrawal = new Transaction(-amount, date,note);
            allTransactions.Add(withdrawal);
        }
    }
}