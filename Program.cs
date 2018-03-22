using System;
using System.Collections.Generic;

namespace classes
{
    class Program
    {

        static private List<BankAccount> allBankAccounts = new List<BankAccount>();
        static void Main(string[] args)
        {
            
            double choice, exitFlag = 1;

            do{
                Console.WriteLine("1 - Create Account\n2 - Login Account");
                
                if(double.TryParse(Console.ReadLine(), out choice)){

                        switch(choice){
                            case 1: CreateAccount();
                            break;
                            case 2: LoginAccount();
                            break;
                            default: Console.WriteLine("Invalid input");
                            break;
                        }
                }
            }while(exitFlag == 1);
           /* var account = new BankAccount("Robin", 1000);

            account.MakeWithdrawal(500, DateTime.Now, "Rent Payment");
            Console.WriteLine(account.Balance);
            account.MakeDeposit(100, DateTime.Now, "friend paid me back");

            Console.WriteLine(account.Balance);

            try{
                var invalidAccount = new BankAccount("invalid", -55);
            }
            catch(ArgumentOutOfRangeException e){
                Console.WriteLine("Exception caught creating account with negative balance");
                Console.WriteLine(e.ToString());
            }

            try{
                account.MakeWithdrawal(750, DateTime.Now, "Attempt to overdraw");
            }
            catch(InvalidOperationException e){
                Console.WriteLine("Exception caught trying to overdraw");
                Console.WriteLine(e.ToString());
            }*/
        }
        static void CreateAccount(){
            var newBankAccount = new BankAccount();
            decimal amount;

            Console.WriteLine("creating account...");

            Console.WriteLine("Enter name: ");
            newBankAccount.Owner = Console.ReadLine();
            
            Console.WriteLine("Enter password: ");
            newBankAccount.password = Console.ReadLine();

            Console.WriteLine("Enter inital amount deposit: ");

            decimal.TryParse(Console.ReadLine(), out amount);
            var date = DateTime.Now;
            var makeAccount = new BankAccount(newBankAccount.Owner,amount, newBankAccount.password);

            allBankAccounts.Add(makeAccount);
            readAllAccounts();
        }
        static void LoginAccount(){
            Console.WriteLine("Logging in...");
        }

        static void readAllAccounts(){
            foreach(var account in allBankAccounts){
                Console.WriteLine($"{account.Owner}");
            }
        }
    }
}
