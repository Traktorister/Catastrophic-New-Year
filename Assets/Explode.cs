using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public int gnomeDeath;
    public float timeSinceLastKill;

    private void Update()
    {
        timeSinceLastKill += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Gnom")
        {
            collision.collider.GetComponent<ParticleSystem>().Play();
            Destroy(gameObject);
            Destroy(collision.collider.gameObject);
            gnomeDeath++;
            timeSinceLastKill = 0;
        }
        if (collision.collider.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
