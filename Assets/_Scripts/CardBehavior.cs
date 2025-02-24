using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBehavior : MonoBehaviour
{
    public bool dragging = false;
    public Vector3 defaultLocation = Vector3.zero;

    private void Update()
    {
        if (!dragging)
        {
            transform.position = defaultLocation;
        }
    }

    private void OnMouseEnter()
    {
        if (!dragging)
        {
            gameObject.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        }
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 5;
    }

    private void OnMouseDrag()
    {
        dragging = true;
        gameObject.transform.localScale = new Vector3(.5f, .5f, .5f);
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        dragging= false;
    }

    private void OnMouseExit()
    {
        if (!dragging)
        {
            gameObject.transform.localScale = Vector3.one;
        }
        gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }
}
