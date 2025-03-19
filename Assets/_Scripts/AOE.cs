using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOE : MonoBehaviour
{
    public float damage = 1f;
    public float lifespan = .5f;
    public float startSize = .5f;
    public float endSize = 1f;
    public float growSpeedMultiplier = 1f;

    private float remainingLifeSpan;

    // Start is called before the first frame update
    void Start()
    {
        remainingLifeSpan = lifespan;
        transform.localScale = new Vector3(startSize, startSize, startSize);
    }

    // Update is called once per frame
    void Update()
    {
        float amountToGrow = (endSize - startSize)/lifespan * Time.deltaTime *growSpeedMultiplier;
        if (transform.localScale.x < endSize)
        {
            transform.localScale += new Vector3(amountToGrow, amountToGrow, amountToGrow);
        }
        remainingLifeSpan -= Time.deltaTime;
        if (remainingLifeSpan <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyBehavior>().takeDamage(damage);
        }
    }
}
