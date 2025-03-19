using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Vector3[] waypoints = {new Vector3 (-8.5f,-.5f,0), new Vector3(-3.5f, -.5f, 0), new Vector3(-3.5f, 2.5f, 0), new Vector3(-.5f, 2.5f, 0), new Vector3(-.5f, -1.5f, 0), new Vector3(6.5f, -1.5f, 0), new Vector3(6.5f, 1.5f, 0), new Vector3(4.5f, 1.5f, 0), new Vector3(4.5f, 5.5f, 0),};
    public float speed = 2f;
    public float health = 3f;
    public float resist = 0f;
    public float damage = 1f;
    public bool debuffImmune = false;
    public float distance = 0f;


    private SpriteRenderer theRenderer;
    private int nextWaypoint = 1;
    private GameManager gameManager;
    private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        theRenderer = GetComponent<SpriteRenderer>();
        transform.position = waypoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 locationToMoveTo = Vector3.MoveTowards(transform.position, waypoints[nextWaypoint], Time.deltaTime * speed);
        distance += Vector3.Distance(transform.position, locationToMoveTo);
        transform.position = locationToMoveTo;
        if ( waypoints[nextWaypoint].x - transform.position.x < -.01f)
        {
            theRenderer.flipX = false;
        }
        else
        {
            theRenderer.flipX = true;
        }

        if (Vector3.Distance(transform.position, waypoints[nextWaypoint]) <= .00001f)
        {
            if (nextWaypoint + 1 >= waypoints.Length)
            {
                gameManager.PlayerHurt(damage);
                destroyThis();
            }
            else
            {
                nextWaypoint++;
            }
        }
    }


    public void takeDamage(float amount)
    {
        health -= amount - resist;
        if (health <= 0)
        {
           
            destroyThis();
        }
    }

    private void destroyThis()
    {
        if (!dead)
        {
            dead = true;
            if ((int)UnityEngine.Random.Range(0, 2) == 1)
            {
                gameManager.SpawnSpades();
            }
            else
            {
                gameManager.SpawnClubs();
            }
            Destroy(gameObject);
        }
    }
}
