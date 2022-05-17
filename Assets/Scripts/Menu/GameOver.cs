using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    

    // Start is called before the first frame update
    public void Start()
    {
    
    }
    public void Restart()
    {
        SceneManager.LoadScene("Menu");
    }

  
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
