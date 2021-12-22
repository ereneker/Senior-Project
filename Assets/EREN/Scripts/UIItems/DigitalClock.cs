using UnityEngine;
using UnityEngine.UI;

public class DigitalClock : MonoBehaviour
{

    public Text textClock;
    public Text dayText;
    private int day = 1;
    private float timeStarted = 0.0f;
    private int hour;
    private int minute;
    public Button continueButton;
    public GameObject dayEndCanvas;
    [SerializeField]
    private int finalDay = 81;
    private bool timeStopped = false;
    [SerializeField]
    private GameObject mainCam;
    [SerializeField]
    private GameObject secondCam;

    void Awake()
    {
        textClock = GetComponent<Text>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 2;
    }

    // Update is called once per frame
    void Update()
    {
        timeStarted += Time.deltaTime;
        displayTime();
        displayDay();
        resetTime();
        if (timeStopped)
        {
            if (dayEndCanvas.activeInHierarchy)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
        else
        {
            Button conButton = continueButton.GetComponent<Button>();
            conButton.onClick.AddListener(continueOnClick);
        }
    }

    void displayTime()
    {
        hour = Mathf.FloorToInt((timeStarted) / 60.0f);
        minute = Mathf.FloorToInt(timeStarted - hour * 60.0f);
        if ((9 + hour) < 12)
        {
            textClock.text = string.Format("{0:00}:{1:00} AM", (9 + hour), minute);
        }
        if ((9 + hour) == 12)
        {
            textClock.text = string.Format("{0:00}:{1:00} PM", (9 + hour), minute);
        }
        if ((9 + hour) > 12)
        {
            textClock.text = string.Format("{0:00}:{1:00} PM", (hour - 3), minute);
        }


    }
    void displayDay()
    {
        if ((9 + hour) == 10)
        {
            day++;
        }
        dayText.text = "Day:" + day + " / " + finalDay;
    }
    void resetTime()
    {
        if ((9 + hour) == 10)
        {
            timeStarted = 0.0f;
            pauseNewDay();
            timeStopped = true;
        }
    }
    void pauseNewDay()
    {
        Time.timeScale = 0;
        dayEndCanvas.SetActive(true);
    }

    void resumeNewDay()
    {
        Time.timeScale = 2;
        timeStopped = false;

    }
    void continueOnClick()
    {
        dayEndCanvas.SetActive(false);
        resumeNewDay();
        secondCam.SetActive(false);
        mainCam.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
