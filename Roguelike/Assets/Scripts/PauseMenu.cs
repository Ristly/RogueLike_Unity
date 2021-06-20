using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public RoomPlacer reset; 

    // Start is called before the first frame update


    public void StartNewGame()
    {
        Time.timeScale = 1;
        reset.Init();
        gameObject.SetActive(false);
    }

    public void ContinueBtn()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);

    }

    public void PauseMainMenuBtn() 
    {
        Time.timeScale = 1;

        PlayerPrefs.SetInt("Current", reset.player.score);
        PlayerPrefs.Save();

        SceneManager.LoadScene("Main_menu");
    }

    public void MainMenuBtn()
    {
        Time.timeScale = 1;
        
      
        SceneManager.LoadScene("Main_menu");

    }
}
