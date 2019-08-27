using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Loads Register scene
    //Indexing can be seen in Build settings -> Scenes to build
    public void GoToRegister()
    {
        SceneManager.LoadScene(1);
    }

    //Loads Login Scene
    public void GoToLogin()
    {
        SceneManager.LoadScene(2);
    }

    //Loads Pokedex Scene
    public void GoToPokedex()
    {
        SceneManager.LoadScene(6);
    }

    //Loads Tutorial Scene
    public void GoToTutorial()
    {
        SceneManager.LoadScene(4);
    }

    //Loads Training Scene
    public void GoToTraining()
    {
        SceneManager.LoadScene(5);
    }

    //Loads Game Scene
    public void GoToPlayGame()
    {
        SceneManager.LoadScene(7);
    }
}
