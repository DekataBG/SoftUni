using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

public class Board : IBoard
{
    private Dictionary<string, Card> cards;

    public Board()
    {
        cards = new Dictionary<string, Card>();
    }

    public bool Contains(string name)
    {
        return cards.ContainsKey(name);
    }

    public int Count()
    {
        return cards.Count;
    }

    public void Draw(Card card)
    {
        if (Contains(card.Name))
        {
            throw new ArgumentException();
        }

        cards[card.Name] = card;
    }

    public IEnumerable<Card> GetBestInRange(int start, int end)
    {
        var cardsInRange = cards
            .Where(c => c.Value.Score >= start && c.Value.Score <= end)
            .Select(c => c.Value)
            .OrderByDescending(c => c.Level);

        return cardsInRange;
    }

    public void Heal(int health)
    {
        var carWithLowestHeal = cards
            .Select(c => new
            {
                Name = c.Value.Name,
                Health = c.Value.Health
            })
            .OrderBy(c => c.Health)
            .ToArray()[0];

        var oldCard = cards[carWithLowestHeal.Name];
        oldCard.Health += health;

        cards[carWithLowestHeal.Name] = oldCard;
    }

    //TODO
    public IEnumerable<Card> ListCardsByPrefix(string prefix)
    {
        var cardsWithPrefix = cards
            .Where(c => c.Value.Name.StartsWith(prefix))
            .Select(c => c.Value)
            .OrderBy(c => c.Name[c.Name.Length - 1])
            .ThenBy(c => c.Level);
            ;

        return cardsWithPrefix;
    }

    public void Play(string attackerCardName, string attackedCardName)
    {
        Card attacker, attacked;

        try
        {
            attacker = cards[attackerCardName];
            attacked = cards[attackedCardName];
        }
        catch (Exception)
        {
            throw new ArgumentException();
        }

        if (attacker.Level != attacked.Level)
        {
            throw new ArgumentException();
        }

        if (attacked.Health > 0)
        {
            attacked.Health -= attacker.Damage;

            if (attacked.Health <= 0)
            {
                attacker.Score += attacked.Level;
            }
        }
    }

    public void Remove(string name)
    {
        if (cards.Remove(name) == false)
        {
            throw new ArgumentException();
        }
    }

    public void RemoveDeath()
    {
        var list = new List<string>();

        cards
        .Where(c => c.Value.Health <= 0)
        .Select(c => c.Value.Name)
        .ToList()
        .ForEach(c => list.Add(c));

        foreach (var card in list)
        {
            Remove(card);
        }
    }

    //TODO
    public IEnumerable<Card> SearchByLevel(int level)
    {
        var cardsWithLevel = cards
            .Where(c => c.Value.Level == level)
            .Select(c => c.Value)
            .OrderByDescending(c => c.Score);

        return cardsWithLevel;
    }
}