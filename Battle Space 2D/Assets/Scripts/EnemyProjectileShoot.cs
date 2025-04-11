using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileShoot : MonoBehaviour
{
    public GameObject projectilePrefab;

    public float fireDelay = 0.50f;
    float cooldownTimer = 0;

    public Vector3 projectileOffset = new Vector3(0, 0.25f, 0);

    Transform player;

    // Update is called once per frame
    void Update()
    {
       if(player == null) {
           GameObject go = GameObject.FindWithTag ("Player");

           if(go != null){
               player = go.transform;
           }
       }


       cooldownTimer -= Time.deltaTime;

       if(cooldownTimer <= 0 && player != null && Vector3.Distance(transform.position, player.position) < 4) {

          // Tir
          cooldownTimer = fireDelay;
       
          Vector3 offset = transform.rotation * projectileOffset;

          GameObject projectileGO = (GameObject)Instantiate(projectilePrefab, transform.position + offset, transform.rotation);
          projectileGO.layer = gameObject.layer;
       }
    }
}
