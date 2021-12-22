[System.Serializable]
public class tasks
{
    public string taskName;
    public int plannedCost;
    public skillRequired[] requiredSkill;

    [System.Serializable]
    public class skillRequired
    {
        public int programming;
        public int database;
        public int salesmarketing;
        public int RnD;
    }
}
