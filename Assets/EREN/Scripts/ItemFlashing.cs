using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFlashing : MonoBehaviour
{
    private GameObject pcScreen;
    public GameObject targetObject;
    public int whiteCol;
    public int grayCol;
    public int grayCol2;
    public bool lookingAtObject = false;
    public bool flashingItem = true;
    public bool flashingStarts = false;

    private void Update()
    {
        if (lookingAtObject == true)
        {
            pcScreen.GetComponent<Renderer>().material.color = new Color32((byte)whiteCol, (byte)grayCol, (byte)grayCol2, 255);
        }
    }

    void OnMouseOver()
    {
        pcScreen = GameObject.Find(RaycastingObject.selectedObject);
        lookingAtObject = true;
        if (flashingStarts == false)
        {
            flashingStarts = true;
            StartCoroutine(FlashObjects());
        }
    }
    private void OnMouseExit()
    {
        flashingStarts = false;
        lookingAtObject = false;
        StopCoroutine(FlashObjects());
        pcScreen.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
    }
    IEnumerator FlashObjects()
    {
        while (lookingAtObject == true)
        {
            yield return
                new WaitForSeconds(0.0f);
        }
    }
}
