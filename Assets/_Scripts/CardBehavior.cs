using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBehavior : MonoBehaviour
{
   
    public Vector3 defaultLocation = Vector3.zero;
    public GameObject tower;
    public GameObject spawnTester;
    private bool touchingMouse = false;
    private bool dragging = false;

    private void Update()
    {
        if (!dragging)
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
            transform.position = defaultLocation;
            if (touchingMouse)
            {
                gameObject.transform.localScale = new Vector3 (.75f, .75f, .75f);
            } else
            {
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
        dragging= false;
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
        }
        Destroy(test);
    }
}
