using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour

{
    public float maxSpeed = 5f;
    public float rotSpeed =180f;

    float shipBoundaryRadius = 0.5f;


    // Update is called once per frame
    void Update()
    {
     // Rotate the ship

     // Grab the rotation quaternion
     Quaternion rot = transform.rotation;

     // Grab the Z euler angle
     float z = rot.eulerAngles.z;

     // Change the Z angle based on input
     z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;

     // Recreate the quaternion
     rot = Quaternion.Euler( 0,0, z );

     // Feed the quaternion into the rotation
     transform.rotation = rot;

     // Move the ship
     Vector3 pos = transform.position;

     Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);

     pos += rot * velocity;

     // RESTRICT the player to the camera boundaries

     // Vertical axe limit
     if(pos.y+shipBoundaryRadius > Camera.main.orthographicSize) {
         pos.y = Camera.main.orthographicSize - shipBoundaryRadius;
     }

     if(pos.y-shipBoundaryRadius < -Camera.main.orthographicSize) {
         pos.y = -Camera.main.orthographicSize + shipBoundaryRadius;
     }
     
     // Calcul of the orthographic width based on the screen ratio
     float screenRatio = (float)Screen.width / (float)Screen.height;
     float width0rtho = Camera.main.orthographicSize * screenRatio;

     // Horizontal axe limit
     if(pos.x+shipBoundaryRadius > width0rtho) {
         pos.x = width0rtho - shipBoundaryRadius;
     }

     if(pos.x-shipBoundaryRadius < -width0rtho) {
         pos.x = -width0rtho + shipBoundaryRadius;
     }

     //Update the position
     transform.position = pos;
    }
}
