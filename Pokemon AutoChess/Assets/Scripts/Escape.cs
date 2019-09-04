using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    //Loads Register scene
    //Indexing can be seen in Build settings -> Scenes to build
    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
