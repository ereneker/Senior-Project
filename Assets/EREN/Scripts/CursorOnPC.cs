using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorOnPC : MonoBehaviour
{
    [SerializeField]
    private GameObject pcCamera;
    [SerializeField]
    private Texture2D customCursor;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;

    void Update()
    {
        if (pcCamera.activeInHierarchy)
        {
            Cursor.SetCursor(customCursor, hotSpot, cursorMode);
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }
    }
}
