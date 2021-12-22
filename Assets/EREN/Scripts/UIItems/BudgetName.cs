using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;
public class BudgetName : MonoBehaviour
{
    public TextMeshProUGUI printedText;
    public TextMeshProUGUI textActualName;

    public void PasteText()
    {
        printedText.text = textActualName.text;
    }

}
