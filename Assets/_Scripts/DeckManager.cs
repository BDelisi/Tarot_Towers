using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public List<GameObject> cardsInDeck = new List<GameObject>();
    public List<GameObject> drawPile = new List<GameObject>();
    public List<GameObject> hand = new List<GameObject>();
    public List<GameObject> discardPile = new List<GameObject>();
    public Vector3[] cardSlots;
    public Vector3 discardPilePos;
    public Vector3 drawPilePos;

    private void Start()
    {
        Deal();
    }

    public void Draw(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if (drawPile.Count >= 1 && hand.Count < cardSlots.Length)
            {
                hand.Add(drawPile[0]);
                drawPile.Remove(drawPile[0]);
                UpdateHandPos();

            } else
            {
                return;
            }
        }
    }

    public void Shuffle()
    {
        List<GameObject> shuffledDrawPile = new List<GameObject>();
        int cardAmount = drawPile.Count;
        for (int i = 0;i < cardAmount;i++)
        {
            int cardToMove = (int) (Random.Range(0, drawPile.Count) + .5f);
            shuffledDrawPile.Add(drawPile[cardToMove]);
            drawPile[cardToMove].transform.position = drawPilePos;
            drawPile.Remove(drawPile[cardToMove]);
        }
        drawPile = shuffledDrawPile;
    }

    public void Reshuffle()
    {
        if (discardPile.Count > 0)
        {
            for (int i = 0; i < discardPile.Count; i++)
            {
                drawPile.Add(discardPile[i]);
                discardPile.Remove(discardPile[i]);
                i--;
            }
            Shuffle();
        }
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
        Draw(5);
    }

    public void PlayCard (GameObject theCard)
    {
        discardPile.Add (theCard);
        hand.Remove(theCard);
        UpdateHandPos();
        theCard.transform.position = drawPilePos;
        if (drawPile.Count == 0)
        {
            Reshuffle();
        }
        Draw(1);
    }

    public void UpdateHandPos()
    {
        for (int i = 0; i < hand.Count; i++)
        {
            hand[i].transform.position = cardSlots[i];
        }
    }
}
