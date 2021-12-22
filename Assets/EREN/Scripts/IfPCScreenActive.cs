using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IfPCScreenActive : MonoBehaviour
{
    private GameObject secondCamera;
    [SerializeField]
    private GameObject dotCanvas;
    private void Start()
    {
        secondCamera = GameObject.FindGameObjectWithTag("SecondCamera");
        if (secondCamera.activeInHierarchy == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            dotCanvas.SetActive(false);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

}
