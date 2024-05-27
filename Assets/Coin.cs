using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag != "Gnom")
        {
            Destroy(gameObject);
            
        }
    }

    void Update()
    {
        
    }
}
