using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 1f;
    public float speed = 1f;

    public void aimAt(GameObject target)
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
        else
        {
            Vector3 targ = target.transform.position;
            targ.z = 0f;

            Vector3 objectPos = transform.position;
            targ.x = targ.x - objectPos.x;
            targ.y = targ.y - objectPos.y;

            float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            
            GetComponent<Rigidbody2D>().velocity = transform.right * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyBehavior>().takeDamage(damage);
            Destroy(gameObject);
        }
    }
}
