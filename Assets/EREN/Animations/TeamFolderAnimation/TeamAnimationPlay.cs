using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamAnimationPlay : MonoBehaviour
{

    public GameObject TeamPanel;
    public Animator panelAnim;

    private void Awake()
    {
        TeamPanel.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnMouseEnter()
    {
        panelAnim = GetComponent<Animator>();
        panelAnim.enabled = true;
    }
    private void OnMouseExit()
    {
        panelAnim.enabled = false;
    }
    public void TeamPanelOpen()
    {
            panelAnim.Play("TeamFolderOpening", -1, 0f);
    }
    void TeamPanelClose()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            panelAnim.Play("TeamFolderClosing", -1, 0f);
        }
    }
}
