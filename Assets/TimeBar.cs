using UnityEngine;
using UnityEngine.UI;

public class TimeBar : MonoBehaviour
{
    public Image linearTimerBar;
    public Image radialTimer;
    public float maxTime = 5f;
    public float timeLeft = 0f;
    public GameObject timesUpText;
    // Start is called before the first frame update
    void Start() {
        timesUpText.SetActive(false);
        linearTimerBar = GetComponent<Image>();
        radialTimer = radialTimer.GetComponent<Image>();
        timeLeft = maxTime;
        
    }

    // Update is called once per frame
    void Update() {
        if (timeLeft > 0 ) {
            timeLeft -= Time.deltaTime;
            linearTimerBar.fillAmount = timeLeft / maxTime;
            radialTimer.fillAmount = timeLeft / maxTime;
        } else {
            timesUpText.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
