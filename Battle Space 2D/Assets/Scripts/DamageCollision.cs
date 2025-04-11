using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollision : MonoBehaviour
{
    public int health = 3;

    void OnTriggerEnter2D()
    {
        Debug.Log ("Damaged!");

        health--;        
    }

    void Update() {

      if(health <= 0) {
         Die();
      }
    }

    void Die() 
    {
      Destroy(gameObject);
    }
}
