using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Knight_Game
{
    class Program
    {
        public static List<Knight> OrderKnights(string[] arr)
        {
            var knights = new List<Knight>();
            for (int i = 0; i < arr.Length; i++)
                for (int j = 0; j < arr.Length; j++)
                    if (arr[i][j] == 'K')
                        knights.Add(new Knight(i, j));

            foreach (var knight in knights)
            {
                int row = knight.Row;
                int col = knight.Col;
                try
                {
                    if (arr[row - 2][col - 1] == 'K')
                        knight.AttackingKnights.Add(knights.Where(r => r.Row == row - 2).Single(c => c.Col == col - 1));
                }
                catch (Exception) { }

                try
                {
                    if (arr[row - 1][col - 2] == 'K')
                        knight.AttackingKnights.Add(knights.Where(r => r.Row == row - 1).Single(c => c.Col == col - 2));
                }
                catch (Exception) { }

                try
                {
                    if (arr[row - 2][col + 1] == 'K')
                        knight.AttackingKnights.Add(knights.Where(r => r.Row == row - 2).Single(c => c.Col == col + 1));
                }
                catch (Exception) { }

                try
                {
                    if (arr[row - 1][col + 2] == 'K')
                        knight.AttackingKnights.Add(knights.Where(r => r.Row == row - 1).Single(c => c.Col == col + 2));
                }
                catch (Exception) { }

                try
                {
                    if (arr[row + 2][col - 1] == 'K')
                        knight.AttackingKnights.Add(knights.Where(r => r.Row == row + 2).Single(c => c.Col == col - 1));
                }
                catch (Exception) { }

                try
                {
                    if (arr[row + 1][col - 2] == 'K')
                        knight.AttackingKnights.Add(knights.Where(r => r.Row == row + 1).Single(c => c.Col == col - 2));
                }
                catch (Exception) { }

                try
                {
                    if (arr[row + 2][col + 1] == 'K')
                        knight.AttackingKnights.Add(knights.Where(r => r.Row == row + 2).Single(c => c.Col == col + 1));
                }
                catch (Exception) { }

                try
                {
                    if (arr[row + 1][col + 2] == 'K')
                        knight.AttackingKnights.Add(knights.Where(r => r.Row == row + 1).Single(c => c.Col == col + 2));
                }
                catch (Exception) { }
            }

            foreach (var knight in knights)
                knight.OrderAttackingKnights();

            knights = knights.OrderByDescending(k => k.AttackingKnights.Count)
                .ThenByDescending(k => k.MaxAttackingKnight).ToList();

            return knights;

        }

        public static string[] NewArr(string[] arr, int row, int col)
        {
            string[] newArr = new string[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                string currRow = "";
                for (int j = 0; j < arr.Length; j++)
                {
                    if (i == row && j == col)
                        currRow += "0";

                    else
                        currRow += arr[i][j];
                    newArr[i] = currRow;
                }
            }

            //Console.WriteLine($"row: {row}  col: {col}");
            //PrintArr(newArr);
            return newArr;
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] arr = new string[n];

            for (int i = 0; i < n; i++)
                arr[i] = Console.ReadLine();
            int initialKnights = OrderKnights(arr).Count;

            int ctr = 0;

            while (OrderKnights(arr)[0].AttackingKnights.Count != 0)
            {
                arr = NewArr(arr, OrderKnights(arr)[0].Row, OrderKnights(arr)[0].Col);
                ctr++;
            }

            Console.WriteLine(ctr);
        }
    }
    class Knight
    {
        public Knight(int row, int col)
        {
            Row = row;
            Col = col;
            AttackingKnights = new List<Knight>();
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public List<Knight> AttackingKnights { get; set; }
        public int MaxAttackingKnight { get; set; }

        public void OrderAttackingKnights()
        {
            AttackingKnights = AttackingKnights.OrderByDescending(k => k.AttackingKnights.Count).ToList();

            if (AttackingKnights.Count > 0)
                MaxAttackingKnight = AttackingKnights[0].AttackingKnights.Count;

            else
                MaxAttackingKnight = 0;
        }
    }
}
