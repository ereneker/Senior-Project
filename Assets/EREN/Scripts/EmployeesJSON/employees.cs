[System.Serializable]
public class employees
{
    public string fullName;
    public string gender;
    public int salary;
    public skillPoints[] skills;

    [System.Serializable]
    public class skillPoints
    {
        public int programming;
        public int cybersecurity;
        public int salesmarketing;
        public int RnD;
    }

}
