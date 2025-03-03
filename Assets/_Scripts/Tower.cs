using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public CircleCollider2D circleCollider;
    public List<GameObject> enemies = new List<GameObject>();
    public float attackCd = 1f;
    public GameObject projectile;

    private float Cd;

    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
    }

    private void Update()
    {
        if (Cd > 0)
        {
            Cd -= Time.deltaTime;
        } else if (enemies.Count > 0)
        {
            GameObject target = null;
            foreach (GameObject enemy in enemies)
            {
                float farthestDistance = 0;
                if (enemy.GetComponent<EnemyBehavior>().distance > farthestDistance)
                {
                    target = enemy;
                }    
            }
            GameObject temp = Instantiate(projectile, transform.position, Quaternion.identity);
            temp.GetComponent<Projectile>().aimAt(target);
            Cd = attackCd;
        }
    }

    public void OnEnemyDeath(GameObject theEnemy)
    {
        if (enemies.Contains(theEnemy))
        {
            enemies.Remove(theEnemy);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemies.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemies.Remove(collision.gameObject);
        }
    }

}
