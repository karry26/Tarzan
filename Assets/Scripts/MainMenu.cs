using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
   static public int playBackground = 0;
   public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    public void setBackground0()
    {
        playBackground = 0;
    }
    public void setBackground1()
    {
        playBackground = 1;
        Debug.Log(playBackground);
    }
    public void setBackground2()
    {
        playBackground = 2;
    }
}
