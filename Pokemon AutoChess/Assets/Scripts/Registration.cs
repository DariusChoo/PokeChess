using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Registration : MonoBehaviour
{
    //Get the Name and Password from the scene, and then the Button to submit the values
    public InputField nameField;
    public InputField pwdField;
    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        //Creates the form and Fields
        WWWForm Form = new WWWForm();
        Form.AddField("name", nameField.text);
        Form.AddField("password", pwdField.text);

        //Finds the php route where data is stored
        WWW www = new WWW("http://localhost/sqlconnect/register.php");
        yield return www;

        //Error Handling
        if (www.text == "0")
        {
            Debug.Log("User created successfully.");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("User creation failed. Error #" + www.text);
        }
    }

    //Don't allow Registration unless both Name and Password is more than 8 characters
    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 8 && pwdField.text.Length >= 8);
    }
}
