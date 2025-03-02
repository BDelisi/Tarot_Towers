using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTester : MonoBehaviour
{
       public bool CheckForValidSpawn()
    {
        BoxCollider2D box = GetComponent<BoxCollider2D>();
        List<Collider2D> results = new List<Collider2D>();
        ContactFilter2D contactFilter = new ContactFilter2D();
        LayerMask layerMask = LayerMask.GetMask("Tower") + LayerMask.GetMask("Path");
        contactFilter.SetLayerMask(layerMask);
        if (box.OverlapCollider(contactFilter, results) != 0)
        {
            return false;
        }
        return true;
    }
}
