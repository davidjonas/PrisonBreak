using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Card : IComparable
{
    public enum Suit
    {
        Diamonds,
        Clubs,
        Hearts,
        Spades
    };

    public enum Rank
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Jack,
        Queen,
        King,
        Ace
    }

    public Suit suit;
    public Rank rank;

    public Card(Suit suit, Rank rank)
    {
        this.suit = suit;
        this.rank = rank;
    }

    public override string ToString()
    {
        return Enum.GetName(typeof(Rank), rank) + " of " +  Enum.GetName(typeof(Suit), suit);
    }

    public int CompareTo(object obj) {
        if (obj == null) return 1;

        if (obj is Card otherCard)
            return (int) rank - (int) otherCard.rank;
        else
            throw new ArgumentException("Trying to compare a Card to something else.");
    }

    public static bool operator >(Card c, Card d) {
        return c.CompareTo(d) > 0;
    }
    
    public static bool operator <(Card c, Card d) {
        return c.CompareTo(d) < 0;
    }
    
    public static bool operator >=(Card c, Card d) {
        return c.CompareTo(d) >= 0;
    }
    
    public static bool operator <=(Card c, Card d) {
        return c.CompareTo(d) <= 0;
    }
    
    public static bool operator ==(Card c, Card d) {
        return c.rank == d.rank && c.suit == d.suit;
    }
    
    public static bool operator !=(Card c, Card d) {
        return c.rank != d.rank || c.suit != d.suit;
    }

    public override bool Equals(object obj)
    {
        if (obj is Card)
        {
            return this == (Card) obj;
        }
        else
        {
            return false;
        }
    }
}
