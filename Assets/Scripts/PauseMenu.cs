using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused = false;

    // In other scripts handleing inputs, wrap with
    // if ( PauseMenu.isPaused){}

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(isPaused )
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void GoToCostumeMenu()
    {
        Time.timeScale = 1;
        print("Remember to make Costume Menu if you have time <3");
        //ScenceManager.LoadScene("CostumeMenu");
    }

    public void GoToCityMenu()
    {
        Time.timeScale = 1;
        print("The city/ environment menu isn't done :p");
        //ScenceManager.LoadScene("CityMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
