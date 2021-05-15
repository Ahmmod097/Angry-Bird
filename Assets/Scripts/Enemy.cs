using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject burstEffect;
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 particlePosition = transform.position;
        particlePosition.z = -2;
        if (collision.collider.GetComponent<BirdMovement>())
        {
            
            Instantiate(burstEffect, particlePosition, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (collision.contacts[0].normal.y < 0.5)
        {
            Instantiate(burstEffect, particlePosition, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
