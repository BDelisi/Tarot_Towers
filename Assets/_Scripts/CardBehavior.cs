using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBehavior : MonoBehaviour
{
    public GameObject tower;
    public GameObject spawnTester;
    public DeckManager deckManager;
    private bool touchingMouse = false;
    private bool dragging = false;

    private void Start()
    {
        deckManager = gameObject.GetComponentInParent<DeckManager>();
    }

    private void Update()
    {
        if (!dragging)
        {
            if (touchingMouse)
            {
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
                gameObject.transform.localScale = new Vector3 (1.1f, 1.1f, 1.1f);
            } else
            {
                gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
                gameObject.transform.localScale = Vector3.one;
            }
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
            gameObject.transform.localScale = new Vector3 (.5f, .5f, .5f);
        }
    }

    private void OnMouseEnter()
    {
        touchingMouse = true;
    }

    private void OnMouseDrag()
    {
        dragging = true;
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        if (dragging)
        {
            placeTower();
        }
        dragging = false;
    }

    private void OnMouseExit()
    {
        touchingMouse= false;
    }

    public void placeTower()
    {
        float xpos = Mathf.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition).x - .5f) +.5f;
        float ypos = Mathf.RoundToInt(Camera.main.ScreenToWorldPoint(Input.mousePosition).y - .5f) +.5f;
        Debug.Log(xpos + " " + ypos);
        GameObject test = Instantiate(spawnTester, new Vector3(xpos, ypos, 0), Quaternion.identity);
        if(test.GetComponent<SpawnTester>().CheckForValidSpawn())
        {
            Instantiate(tower, new Vector3(xpos, ypos, 0), Quaternion.identity);
            deckManager.PlayCard(gameObject);
        } else
        {
            deckManager.UpdateHandPos();
        }
        Destroy(test);
        touchingMouse = false;
    }
}
