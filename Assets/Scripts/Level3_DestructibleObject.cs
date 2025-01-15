using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3_DestructibleObject : MonoBehaviour
{
    public int maxHits = 20; // Adjust the number of hits required to collapse as needed
    private int currentHits = 0;

    public void TakeHit()
    {
        currentHits++;
        if (currentHits >= maxHits)
        {
            Collapse();
        }
    }

    private void Collapse()
    {
        // Add code here to make the object collapse or perform any desired destruction effect.
        Destroy(gameObject); // For simplicity, we destroy the object here.
    }
}
