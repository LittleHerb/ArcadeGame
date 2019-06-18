using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausemenu : MonoBehaviour
{

    public static bool GameIsPaused = false;

    public GameObject PauseMenuUI;
    void Update() {

        if (Input.GetKeyDown(KeyCode.Escape))

        {
            if (GameIsPaused)
            {
                Resume();
                
            }else
            {
                pause();
            }
        }

                }

    public void Resume ()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
public void LoadMenu ()
{
        SceneManager.LoadScene("menu");
}
public void QuitGame()
{
  Debug.Log("quiting");
        Application.Quit();

}




}
