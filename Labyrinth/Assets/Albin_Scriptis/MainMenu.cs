using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    // Albin
    
    public void PlayGame()
    {
        SceneManager.LoadScene("TheGame");
    }


   

    public void QuitGame ()
    {

        Application.Quit();
    }

 


}
