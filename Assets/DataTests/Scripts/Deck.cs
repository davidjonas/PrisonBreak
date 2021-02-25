using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    private Stack<Card> cards;
    public string name;

    public Deck(string name)
    {
        this.name = name;
        cards = new Stack<Card>();
    }

    public Deck(string name, Card[] cards) : this(name)
    {
        for (int i = 0; i < cards.Length; i++)
        {
            this.cards.Push(cards[i]);
        }
    }

    public void Shuffle()
    {
        List<Card> tmp = new List<Card>();

        while (cards.Count > 0)
        {
            tmp.Add(cards.Pop());
        }

        while (tmp.Count > 0)
        {
            int randomCardIndex = Random.Range(0, tmp.Count - 1);
            cards.Push(tmp[randomCardIndex]);
            tmp.RemoveAt(randomCardIndex);
        }
    }

    public Card Pick()
    {
        return cards.Pop();
    }

    public void Lay(Card c)
    {
        cards.Push(c);
    }

    public bool Contains(Card c)
    {
        return cards.Contains(c);
    }
}
