using System;
using System.Collections.Generic;

namespace P03.Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Card>();

            var cards = Console.ReadLine().Split(", ");

            foreach (var card in cards)
            {
                var newCard = card.Split();

                try
                {
                    list.Add(new Card(newCard[0], newCard[1]));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(String.Join(" ", list));
        }
    }

    class Card
    {
        private string face, suit;

        public Card(string face, string suit)
        {
            Face = face;
            Suit = suit;
        }

        public string Face
        {
            get => face;
            set
            {
                if (value == "2" || value == "3" || value == "4" || value == "5" ||
                    value == "6" || value == "7" || value == "8" || value == "9" ||
                    value == "10" || value == "J" || value == "Q" || value == "K" ||
                    value == "A")
                {
                    face = value;
                }
                else
                {
                    throw new Exception("Invalid card!");
                }
            }
        }
        public string Suit
        {
            get => suit;
            set
            {
                switch (value)
                {
                    case "S":
                        suit = "\u2660";
                        break;
                    case "H":
                        suit = "\u2665";
                        break;
                    case "D":
                        suit = "\u2666";
                        break;
                    case "C":
                        suit = "\u2663";
                        break;
                    default:
                        throw new Exception("Invalid card!");
                }
            }
        }

        public override string ToString()
        {
            return $"[{Face}{Suit}]";
        }
    }
}
