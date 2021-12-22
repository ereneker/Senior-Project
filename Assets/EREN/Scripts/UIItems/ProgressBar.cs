using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]
public class ProgressBar : MonoBehaviour
{
    
    public controllerEmployeeJson cEmpJson = new controllerEmployeeJson();
    public controllerTaskJson cTaskJson = new controllerTaskJson();
    public int findIndex;
    private float targetProgress = 0;
    private float newValue = 10.0f;
    private float fillSpeed = 2;
    public GameObject panel;
    public Slider slider;
    List<int> programmingSkill = new List<int>();

    private int[] programmingSkills;
    private int[] databaseSkills;
    private int[] salesMarketingSkills;
    private int[] rNDSkills;
    private int[] reqProgramming;
    private int[] reqDatabase;
    private int[] reqSales;
    private int[] reqRND;

    Coroutine waitForJson;

    void Start()
    {
        
        transferData();
    }
    private void Update()
    {
        /*for(int i = 0; i < programmingSkills.Length; i++)
        {
             Debug.Log(cTaskJson.reqProgrammingSkills[i]);
        }*/
        if (slider.value < targetProgress)
        {
            slider.value += fillSpeed * Time.deltaTime;
        }
    }
    private void transferData()
    {
        this.programmingSkills = new int[9];
        this.databaseSkills = new int[9];
        this.salesMarketingSkills = new int[9];
        this.rNDSkills = new int[9];
        this.reqProgramming = new int[8];
        this.reqDatabase = new int[8];
        this.reqSales = new int[8];
        this.reqRND = new int[8];

        for (int i = 1; i < programmingSkills.Length; i++)
        {
            programmingSkills[i] = cEmpJson.programmingSkill[i];
            Debug.Log(programmingSkills[i]);
        }
        for (int i = 0; i < cEmpJson.databaseSkill.Length; i++)
        {
            databaseSkills[i] = cEmpJson.databaseSkill[i];
        }
        for (int i = 0; i < cEmpJson.salesSkill.Length; i++)
        {
            salesMarketingSkills[i] = cEmpJson.salesSkill[i];
        }
        for (int i = 0; i < cEmpJson.rndSkill.Length; i++)
        {
            rNDSkills[i] = cEmpJson.rndSkill[i];
        }
        for(int i = 0; i < cTaskJson.reqProgrammingSkills.Length; i++)
        {
            reqProgramming[i] = cTaskJson.reqProgrammingSkills[i];
            //Debug.Log(reqProgramming[i]);
        }
        for(int i = 0; i < cTaskJson.reqDatabaseSkills.Length; i++)
        {
            reqDatabase[i] = cTaskJson.reqDatabaseSkills[i];
        }
        for(int i = 0; i < cTaskJson.reqSalesMarketingSkills.Length; i++)
        {
            reqSales[i] = cTaskJson.reqSalesMarketingSkills[i];
        }
        for(int i = 0; i < cTaskJson.reqRNDSkills.Length; i++)
        {
            reqRND[i] = cTaskJson.reqRNDSkills[i];
        }
    }
    public void pasteButtonPressed(int k)
    {
        findIndex = k;
    }
    //Progress bar için deneme
    public void incrementProgressBar()
    {
        /*for(int i = 0; i < programmingSkills.Length; i++)
        {
            Debug.Log(programmingSkills[i]);
        }*/
        float newProgress = 50;
        for(int i = 0; i <= findIndex; i++)
        {
            if (i == findIndex)
            {
                Debug.Log(programmingSkills[i]);
            }
        }
        if (programmingSkills[findIndex] == reqProgramming[findIndex])
        {
            Debug.Log("Eþit");
            targetProgress = slider.value + newProgress;
        }
        if (databaseSkills[findIndex] == reqDatabase[findIndex])
        {
            targetProgress = slider.value + newProgress;
        }
    }

    IEnumerator WaitForJson()
    {
        Debug.Log("Start");
        yield return new WaitWhile(CheckIfPanelActive);
        if (!panel.activeInHierarchy)
        {
            yield break;
        }
    }
    private bool CheckIfPanelActive()
    {
        if (!panel.activeInHierarchy)
            return false;
        else
            return true;
    }
}
