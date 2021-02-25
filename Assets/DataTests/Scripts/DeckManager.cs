using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : Singleton<DeckManager>
{
    private List<Deck> decks = new List<Deck>();

    public Deck GetDeck(string name)
    {
        foreach (Deck deck in decks)
        {
            if (deck.name == name)
            {
                return deck;
            }
        }

        return null;
    }

    public void CreateDeck(string name)
    {
        Deck d = new Deck(name);
    }

    public void CreateDeck(string name, int numCards)
    {
        List<Card> cards = new List<Card>();

        while (cards.Count < numCards)
        {
            int suit = Random.Range(0, 3);
            int rank = Random.Range(0, 11);
            cards.Add(new Card((Card.Suit)suit, (Card.Rank)rank));
        }
        
        Deck d = new Deck(name, cards.ToArray());
    }

    public Card Pick(string name)
    {
        return GetDeck(name).Pick();
    }
    
}
