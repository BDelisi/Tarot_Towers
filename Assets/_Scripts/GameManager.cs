using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float playerHealth = 10f;
    public GameObject spades;
    public GameObject clubs;
    private void Start()
    {
        Instantiate(spades);
        Instantiate(clubs);
    }

    public void PlayerHurt(float damage)
    {
        playerHealth -= damage;
        Debug.Log("The player took damage! They are at: " + playerHealth + " health!");
        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void SpawnSpades()
    {
        Instantiate(spades);
    }

    public void SpawnClubs()
    {
        Instantiate(clubs);
    }
}
