using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameObjectCreator : MonoBehaviour
{
    public List<Sprite> Sprites = new List<Sprite>();
    public GameObject ParentPanel;

    // Start is called before the first frame update
    void Start()
    {
        gameObjectCreate();
    }

    public void gameObjectCreate()
    {
        foreach(Sprite currentSprite in Sprites)
        {
            GameObject newObj = new GameObject();
            Image newImage = newObj.AddComponent<Image>();
            newImage.sprite = currentSprite;
            newObj.GetComponent<RectTransform>().SetParent(ParentPanel.transform);
            newObj.SetActive(true);
        }
    }
}
