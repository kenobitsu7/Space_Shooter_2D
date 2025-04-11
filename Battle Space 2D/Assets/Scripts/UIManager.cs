using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
  [SerializeField] private GameObject gameOverCanvas;
  [SerializeField] private TextMeshProUGUI label;
  [SerializeField] private Button restart;

        
    private void Start()
    {
        restart.onClick.AddListener(ResetTheGame);

    }
        
    public void GameOver(bool isDead)
    {
        gameOverCanvas.SetActive(true);
        if (isDead)
        {

            label.text = "Mission Failed!";

        }
        
        
    }
    private void ResetTheGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
