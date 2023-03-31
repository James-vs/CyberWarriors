using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    private float countDownTime;
    public float startTime = 60f;
    private float timeElapsed = 0f;
    [SerializeField] private StSLevel1Manager stSLevel1Manager;

    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        countDownTime = startTime;

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver) {
            if (countDownTime > 0) {
                countDownTime -= 1 * Time.deltaTime;
                timeElapsed += 1 * Time.deltaTime;
                timerText.text = countDownTime.ToString("0");
            } else {
                stSLevel1Manager.OutOfTime(true);
                StopTimer();
            }
        }
    }

    public void StopTimer() {
        gameOver = true;
    }
}
