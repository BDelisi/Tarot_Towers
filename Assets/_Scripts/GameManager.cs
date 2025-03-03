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
    public void EnemyDeath(GameObject theEnemy)
    {
        foreach (GameObject theTower in GameObject.FindGameObjectsWithTag("Tower"))
        {
           theTower.GetComponentInChildren<Tower>().OnEnemyDeath(theEnemy);
        }
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
