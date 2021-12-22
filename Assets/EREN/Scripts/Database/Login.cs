using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Login : MonoBehaviour
{
    public InputField userIdField;
    public Button loginButton;

    public void callLogin()
    {
        StartCoroutine(playerLogin());
    }

    IEnumerator playerLogin()
    {
        WWWForm form = new WWWForm();
        form.AddField("userID", userIdField.text);
        WWW www = new WWW("http://localhost/sqlconnect/login.php", form);
        yield return www;

        if (www.text[0] == '0')
        {
            DBManagement.userID = userIdField.text;
        }
        else
        {
            Debug.Log("Login Failed. Error #" + www.text);
        }
    }

    public void activateButtonPress()
    {
        loginButton.interactable = (userIdField.text.Length >= 10);
    }
}
