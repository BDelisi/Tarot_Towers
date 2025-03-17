using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public List<string> cardsInDeck = new List<string>();
    public List<string> drawPile = new List<string>();
    public List<string> hand = new List<string>();
    public List<string> discardPile = new List<string>();

    private void Start()
    {
        Deal();
    }

    public void Draw(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (drawPile.Count >= 1)
            {
                hand.Add(drawPile[0]);
                drawPile.Remove(drawPile[0]);
            } else
            {
                return;
            }
        }
    }

    public void Shuffle()
    {
        List<string> shuffledDrawPile = new List<string>();
        int cardAmount = drawPile.Count;
        for (int i = 0;i < cardAmount;i++)
        {
            int cardToMove = (int) (Random.Range(0, drawPile.Count) + .5f);
            shuffledDrawPile.Add(drawPile[cardToMove]);
            drawPile.Remove(drawPile[cardToMove]);
        }
        drawPile = shuffledDrawPile;
    }

    public void Deal()
    {
        drawPile.Clear();
        hand.Clear();
        discardPile.Clear();

        for (int i = 0; i < cardsInDeck.Count; i++)
        {
            drawPile.Add(cardsInDeck[i]);
        }
        Shuffle();
        Draw(3);
    }
}
