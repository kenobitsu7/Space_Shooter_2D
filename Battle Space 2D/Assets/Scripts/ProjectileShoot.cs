using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public GameObject projectilePrefab;

    public Vector3 projectileOffset = new Vector3(0, 0.25f, 0);

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {

            Vector3 offset = transform.rotation * projectileOffset;

            GameObject projectileGO = (GameObject)Instantiate(projectilePrefab, transform.position + offset, transform.rotation);
            projectileGO.layer = gameObject.layer;

        }
    }
}
