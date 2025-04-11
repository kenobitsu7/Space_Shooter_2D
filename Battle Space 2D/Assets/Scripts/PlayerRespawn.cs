using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject playerPrefab;
    GameObject playerInstance;

    float respawnTimer;

    public int numLives = 3;

    public UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    void SpawnPlayer() {
        numLives--;
        respawnTimer = 1;
        playerInstance = Instantiate(playerPrefab, transform.position, Quaternion.identity);      
    }

    // Update is called once per frame
    void Update()
    {
       if(playerInstance == null && numLives > 0) {
           respawnTimer -= Time.deltaTime;

           if(respawnTimer <= 0) {
               SpawnPlayer();
           }
       }

        if (playerInstance == null && numLives <= 0)
        {
            uiManager.GameOver(false);
        }

    }

    void OnGUI() {

        if(numLives > 0 || playerInstance!= null) {

             GUI.Label(new Rect(0, 0, 100, 50), "Available Ship :" + numLives); 
        }

        /*else
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50), "Mission Failed!");
        }*/
    }
}
