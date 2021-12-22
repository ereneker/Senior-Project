using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class controllerTaskJson : MonoBehaviour
{
    public tasksList taskList = new tasksList();
    public TextMeshProUGUI[] taskText;
    public TextMeshProUGUI[] plannedCostText;


    List<string> taskNames = new List<string>();
    [HideInInspector]
    public List<int> reqSkillsProgramming = new List<int>();
    [HideInInspector]
    public List<int> reqSkillsDatabase = new List<int>();
    [HideInInspector]
    public List<int> reqSkillsSales = new List<int>();
    [HideInInspector]
    public List<int> reqSkillsRND = new List<int>();
    [HideInInspector]
    public List<int> plannedCostList = new List<int>();

    private int listTaskNames = 0;
    private int listCostText = 0;

    [HideInInspector]
    public int[] reqProgrammingSkills;
    [HideInInspector]
    public int[] reqDatabaseSkills;
    [HideInInspector]
    public int[] reqSalesMarketingSkills;
    [HideInInspector]
    public int[] reqRNDSkills;
    // Start is called before the first frame update
    private void Awake()
    {
        tasksListDispaly();
        transferData();
    }
    void Start()
    {
    }
    public void tasksListDispaly()
    {
        this.reqProgrammingSkills = new int[8];
        this.reqDatabaseSkills = new int[8];
        this.reqSalesMarketingSkills = new int[8];
        this.reqRNDSkills = new int[8];

        TextAsset assetTask = Resources.Load("tasks") as TextAsset;
        if (assetTask != null)
        {
            taskList = JsonUtility.FromJson<tasksList>(assetTask.text);
            foreach(tasks TasksLists in taskList.tasks)
            {
                taskNames.Add(TasksLists.taskName);
                plannedCostList.Add(TasksLists.plannedCost);
                print(TasksLists.taskName);
                for(int i = 0; i < TasksLists.requiredSkill.Length; i++)
                {
                    reqSkillsProgramming.Add(TasksLists.requiredSkill[i].programming);
                    reqSkillsDatabase.Add(TasksLists.requiredSkill[i].database);
                    reqSkillsSales.Add(TasksLists.requiredSkill[i].salesmarketing);
                    reqSkillsRND.Add(TasksLists.requiredSkill[i].RnD); 
                }
            }
            for (int i = 0; i < taskText.Length; i++)
            {
                taskText[i].text = taskNames[listTaskNames];
                listTaskNames++;
            }
            for(int i = 0; i < plannedCostText.Length; i++)
            {
                plannedCostText[i].text = plannedCostList[listCostText].ToString();
                listCostText++;
            }
        }
        else
        {
            print("Asset is null!");
        }
    }
    private void transferData()
    {
        for (int i = 0; i < reqProgrammingSkills.Length; i++)
        {
            reqProgrammingSkills[i] = reqSkillsProgramming[i];
            //Debug.Log(reqProgrammingSkills[i]);
        }
        for (int i = 0; i < reqDatabaseSkills.Length; i++)
        {
            reqDatabaseSkills[i] = reqSkillsDatabase[i];
        }
        for (int i = 0; i < reqSalesMarketingSkills.Length; i++)
        {
            reqSalesMarketingSkills[i] = reqSkillsSales[i];
        }
        for (int i = 0; i < reqRNDSkills.Length; i++)
        {
            reqRNDSkills[i] = reqSkillsRND[i];
        }
    }
}
