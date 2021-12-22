using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CharacterItemPickup : MonoBehaviour
{
    [SerializeField]
    private Camera characterCamera;
    [SerializeField]
    private Camera pcCamera;
    // Reference for item that picked up
    private PickableItem pickedItem;
    [SerializeField]
    private GameObject dotCenter;
    void Start()
    {
    }

    private void Update()
    {
        // Check if player picked some item already
        if (pickedItem)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                pcCamera.gameObject.SetActive(false);
                characterCamera.gameObject.SetActive(true);
            }
        }
            if (!pickedItem)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    var ray = characterCamera.ViewportPointToRay(Vector3.one * 0.5f);
                    RaycastHit hit;
                    //Raycast detection of object
                    if (Physics.Raycast(ray, out hit, 1.5f))
                    {
                        var pickable = hit.transform.GetComponent<PickableItem>();

                        if (pickable)
                        {
                            PickItem(pickable);

                        }
                }
            }
        }
    }
    private void PickItem(PickableItem item)
    {
        characterCamera.gameObject.SetActive(false);
        pcCamera.gameObject.SetActive(true);
        dotCenter.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

}