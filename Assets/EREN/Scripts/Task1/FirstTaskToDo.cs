using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Changed the purpose of this script
[System.Serializable]
public class FirstTaskToDo : MonoBehaviour
{
    [HideInInspector]
    public controllerEmployeeJson cEmpJson = new controllerEmployeeJson();
    public TextMeshProUGUI employeeCost;

    private int buttonIndex;
    [HideInInspector]
    public List<int> empSkillsTask1 = new List<int>();
    public void setButtonVariable(int k)
    {
        buttonIndex = k;
    }

    public void comparing()
    {

    }
}
