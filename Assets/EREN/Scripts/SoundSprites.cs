using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSprites : MonoBehaviour
{

    [SerializeField]
    private Sprite SoundOff;
    [SerializeField]
    private Button button;

    public void changeImage()
    {
        button.image.sprite = SoundOff;
    }
}
