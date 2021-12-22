using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class controllerEmployeeJson : MonoBehaviour
{
    public employeesList employeeList = new employeesList();
    public TextMeshProUGUI[] empText;
    public TextMeshProUGUI[] programmingText;
    public TextMeshProUGUI[] databaseText;
    public TextMeshProUGUI[] salesMarketingText;
    public TextMeshProUGUI[] rNDText;
    public TextMeshProUGUI[] employeeCost;



    List<string> empNames = new List<string>();
    [HideInInspector]
    public List<int> empSkillsProgramming = new List<int>();
    [HideInInspector]
    public List<int> empSkillsDatabase = new List<int>();
    [HideInInspector]
    public List<int> empSkillsSales = new List<int>();
    [HideInInspector]
    public List<int> empSkillsRND = new List<int>();
    [HideInInspector]
    public List<int> salaryCostsList = new List<int>();

    [HideInInspector]
    public int[] programmingSkill;
    [HideInInspector]
    public int[] databaseSkill;
    [HideInInspector]
    public int[] salesSkill;
    [HideInInspector]
    public int[] rndSkill;

    private int listItem = 0;
    private int listProgramming = 0;
    private int listDatabase = 0;
    private int listSalesMarketing = 0;
    private int listRnD = 0;
    private int buttonIndex;
    private void Awake()
    {
        employeeListDisplay();
        empDataOnScripts();
    }

    void Start()
    {
    }
    private void Update()
    {
    }
    //See which button pressed and paste cost
    public void setButtonVariable(int k)
    {
        buttonIndex = k;
    }
    public void copyPlannedCost()
    {
        int i = 0;
        if (i < salaryCostsList.Count)
        {
            employeeCost[i].text = salaryCostsList[buttonIndex].ToString();
        }
    }
    //Parsing Json Data
    public void employeeListDisplay()
    {
        this.programmingSkill = new int[9];
        this.databaseSkill = new int[9];
        this.salesSkill = new int[9];
        this.rndSkill = new int[9];
        TextAsset asset = Resources.Load("employees") as TextAsset;
        if (asset != null)
        {
            employeeList = JsonUtility.FromJson<employeesList>(asset.text);
            foreach (employees EmployeesLists in employeeList.employees)
            {
                empNames.Add(EmployeesLists.fullName);
                salaryCostsList.Add(EmployeesLists.salary);
                for (int i = 0; i < EmployeesLists.skills.Length; i++)
                {
                    empSkillsDatabase.Add(EmployeesLists.skills[i].cybersecurity);
                    empSkillsProgramming.Add(EmployeesLists.skills[i].programming);
                    empSkillsSales.Add(EmployeesLists.skills[i].salesmarketing);
                    empSkillsRND.Add(EmployeesLists.skills[i].RnD);
                }
            }
            for (int i = 0; i < empText.Length; i++)
            {
                empText[i].text = empNames[listItem];
                listItem++;
            }
            for (int i = 0; i < programmingText.Length; i++)
            {
                programmingText[i].text = empSkillsProgramming[listProgramming].ToString();
                //Debug.Log(empSkillsProgramming[listProgramming]);
                listProgramming++;
            }
            for (int i = 0; i < databaseText.Length; i++)
            {
                databaseText[i].text = empSkillsDatabase[listDatabase].ToString();
                //Debug.Log(empSkillsDatabase[i]);
                listDatabase++;
            }
            for (int i = 0; i < salesMarketingText.Length; i++)
            {
                salesMarketingText[i].text = empSkillsSales[listSalesMarketing].ToString();
                listSalesMarketing++;
            }
            for (int i = 0; i < rNDText.Length; i++)
            {
                rNDText[i].text = empSkillsRND[listRnD].ToString();
                listRnD++;
            }
        }
        else
        {
            print("Asset is null!");
        }
    }
    public void empDataOnScripts()
    {
        for (int i = 0; i < programmingSkill.Length; i++)
        {
            programmingSkill[i] = empSkillsProgramming[i];
            //Debug.Log(programmingSkill[i]);
        }

        for (int i = 0; i < databaseSkill.Length; i++)
        {
            databaseSkill[i] = empSkillsDatabase[i];
            //Debug.Log(databaseSkill[i]);
        }
        for(int i = 0; i < salesSkill.Length; i++)
        {
            salesSkill[i] = empSkillsSales[i];
        }

        for (int i = 0; i < rndSkill.Length; i++)
        {
            rndSkill[i] = empSkillsRND[i];
        }
    }
}
