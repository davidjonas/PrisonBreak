using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGameTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Card c = new Card(Card.Suit.Hearts, Card.Rank.Queen);
        Debug.Log(c);
        Card c2 = new Card(Card.Suit.Spades, Card.Rank.Two);
        Debug.Log(c2);
        Debug.Log(c > c2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
