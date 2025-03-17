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
            float farthestDistance = 0;
            for (int i = 0; i < enemies.Count; i++)
            {
                GameObject enemy = enemies[i];
                if (enemy != null)
                {
                    if (enemy.GetComponent<EnemyBehavior>().distance > farthestDistance)
                    {
                        target = enemy;
                    }
                }
                else
                {
                    enemies.Remove(enemy);
                    i--;
                }
            }
            GameObject temp = Instantiate(projectile, transform.position, Quaternion.identity);
            temp.GetComponent<Projectile>().aimAt(target);
            Cd = attackCd;
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
