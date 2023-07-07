using UnityEngine;
using UnityEngine.UI;

public class PMRadialTimer : MonoBehaviour
{
    public Image radialTimer;
    public float maxTime = 5f;
    public float timeLeft = 0f;
    //public GameObject timesUpText;
    [SerializeField] private bool startTimer = false;
    [SerializeField] private PMManager PMManager;


    // Start is called before the first frame update
    void Start() {
        radialTimer.gameObject.SetActive(false);
        radialTimer = radialTimer.GetComponent<Image>();
        timeLeft = maxTime;
    }

    // Update is called once per frame
    void Update() => TimerLogic();

    private void TimerLogic() {
        if (!startTimer) return;
        if (timeLeft > 0 ) {
            timeLeft -= Time.deltaTime;
            radialTimer.fillAmount = timeLeft / maxTime;
        } else {
            //timesUpText.SetActive(true);
            radialTimer.gameObject.SetActive(false);
            PMManager.SetShield(false);
            //Time.timeScale = 0;
        }
    }

    public void StartPMRadialTimer() {
        Debug.Log("Start Timer");
        radialTimer.gameObject.SetActive(true);
        PMManager.SetShield(true);
        radialTimer.fillAmount = 1;
        timeLeft = maxTime;
        startTimer = true;
    }
}
