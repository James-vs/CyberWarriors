using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    private float countDownTime;
    public float startTime = 60f;
    private float timeElapsed = 0f;

    // Start is called before the first frame update
    void Start()
    {
        countDownTime = startTime;

    }

    // Update is called once per frame
    void Update()
    {
        if (countDownTime > 0) {
            countDownTime -= 1 * Time.deltaTime;
            timeElapsed += 1 * Time.deltaTime;
            timerText.text = countDownTime.ToString("0");
        }
    }
}
