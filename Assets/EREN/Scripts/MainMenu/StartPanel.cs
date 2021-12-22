using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    public GameObject diffPanel;
    public Animator panelAnim;
    public bool buttonClicked = false;

    private void Start()
    {
    }

    public bool pressedState()
    {
         return buttonClicked = true;
    }

    private void Update()
    {
        mouseOverButton();
    }
    public void OnMouseDown()
    {
        if (diffPanel.activeInHierarchy == false)
        {
            diffPanel.SetActive(true);
        }
    }
    private void mouseOverButton()
    {
        if (diffPanel.activeInHierarchy)
        {
            panelAnim = GetComponent<Animator>();
            panelAnim.enabled = true;
            panelAnim.Play("StartOpen");
            if (buttonClicked)
            {
                panelAnim.Play("StartClose");
                diffPanel.SetActive(false);
            }
        }
    }
}
