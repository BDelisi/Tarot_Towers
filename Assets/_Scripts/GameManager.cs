using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float playerHealth = 10f;
    public GameObject spades;

    private void Start()
    {
        Instantiate(spades);
    }

    public void PlayerHurt(float damage)
    {
        playerHealth -= damage;
        Debug.Log("The player took damage! They are at: " + playerHealth + " health!");
    }

    public void SpawnSpades()
    {
        Instantiate(spades);
    }
}
