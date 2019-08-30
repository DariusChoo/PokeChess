using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Loads Register scene
    //Indexing can be seen in Build settings -> Scenes to build
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoToRegister()
    {
        SceneManager.LoadScene(1);
    }
}
