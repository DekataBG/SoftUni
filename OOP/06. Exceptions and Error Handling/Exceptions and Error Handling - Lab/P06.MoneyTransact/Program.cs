using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace P06.MoneyTransact
{
    class Program
    {
        static Dictionary<int, double> balanceDict = new Dictionary<int, double>();

        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");


            var info = Console.ReadLine().Split(',');

            foreach (var item in info)
            {
                var account = item.Split('-');

                balanceDict.Add(int.Parse(account[0]), double.Parse(account[1]));
            }

            var command = Console.ReadLine().Split();
            while (command[0] != "End")
            {
                try
                {
                var accountNumber = int.Parse(command[1]);
                var sum = double.Parse(command[2]);
                    switch (command[0])
                    {
                        case "Deposit":
                            Deposit(accountNumber, sum);
                            Console.WriteLine($"Account {accountNumber} has new balance: {balanceDict[accountNumber]:f2}");
                            break;
                        case "Withdraw":
                            Withdraw(accountNumber, sum);
                            Console.WriteLine($"Account {accountNumber} has new balance: {balanceDict[accountNumber]:f2}");
                            break;
                        default:
                            throw new ArgumentException("Invalid command!");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
                finally
                {
                    Console.WriteLine("Enter another command");
                    command = Console.ReadLine().Split();
                }
            }
        }

        static void Withdraw(int accountNumber, double sum)
        {
            if (balanceDict.ContainsKey(accountNumber))
            {
                if (balanceDict[accountNumber] < sum)
                {
                    throw new Exception("Insufficient balance!");
                }
                else
                {
                    balanceDict[accountNumber] -= sum;
                }
            }
            else
            {
                throw new ArgumentException("Invalid account!");
            }
        }

        static void Deposit(int number, double sum)
        {
            if(balanceDict.ContainsKey(number))
            {
                balanceDict[number] += sum;
            }
            else
            {
                throw new ArgumentException("Invalid account!");
            }
        }
    }
}
