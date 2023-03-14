using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StSTutorialManager : MonoBehaviour
{
    [SerializeField] private GameObject success;
    private bool gameOver = false;
    [SerializeField] private bool m1First = false;
    [SerializeField] private bool m2First = false;
    [SerializeField] private bool match1_1 = false;
    [SerializeField] private bool match1_2 = false;
    [SerializeField] private bool match2_1 = false;
    [SerializeField] private bool match2_2 = false;
    [SerializeField] private GameObject button1_1;
    [SerializeField] private GameObject button1_2;
    [SerializeField] private GameObject button2_1;
    [SerializeField] private GameObject button2_2;
    private Color btn1_1Original;
    private Color btn1_2Original;
    private Color btn2_1Original;
    private Color btn2_2Original;

    private int matches = 0;
    [SerializeField] private TextMeshProUGUI matchesUI;

    

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("StSTutorialManager running");
        btn1_1Original = button1_1.GetComponent<Image>().color;
        btn1_2Original = button1_2.GetComponent<Image>().color;
        btn2_1Original = button2_1.GetComponent<Image>().color;
        btn2_2Original = button2_2.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver) {
            if (CheckComplete()) {
                Debug.Log("Both pairs matched");
                success.SetActive(true);
                gameOver = true;
            }
        }
        matchesUI.text = matches.ToString();
    }

    public bool CheckComplete() {
        //check for m1&m2 in all cases 
        if (m1First && m2First) {
            return true;
        } else if (m1First && !m2First){
            Match2Found();
            return false;
        } else if (!m1First && m2First) {
            Match1Found();
            return false;
        } else {
            Match1Found();
            Match2Found();
            return false;
        }
    }

    public bool Match1Found() {
        if (match1_1 && match1_2) {
            if (!m1First) {
                Debug.Log("First pair matched");
                matches += 1;
            }
            m1First = true;
            match1_1 = false;
            match1_2 = false;
            button1_1.GetComponent<Image>().color = Color.green;
            button1_2.GetComponent<Image>().color = Color.green;
            return true;
        } else {
            return false;
        }
    }


    public bool Match2Found() {
        if (match2_1 && match2_2) {
            if (!m2First) {
                Debug.Log("Second pair matched");
                matches += 1;
            }
            //match?_? added
            match2_1 = false;
            match2_2 = false;
            button2_1.GetComponent<Image>().color = Color.green;
            button2_2.GetComponent<Image>().color = Color.green;
            m2First = true;
            return true;
        } else {
            return false;
        }
    }

    public void Match11() {
        if (!m1First){
            if (!match2_1 && !match1_1) {
                Debug.Log("Button 1_1 selected");
                match1_1 = true;
                button1_1.GetComponent<Image>().color = Color.yellow;
            } else {
                match1_1 = false;
                button1_1.GetComponent<Image>().color = btn1_1Original;
            }
        }
    }

    public void Match12() {
        if (!m1First) {
            if (!match2_2 && !match1_2) {
                Debug.Log("Button 1_2 selected");
                match1_2 = true;
                button1_2.GetComponent<Image>().color = Color.yellow;
            } else {
                button1_2.GetComponent<Image>().color = btn1_2Original;
                match1_2 = false;
            }
        }
    }

    public void Match21 () {
        if (!m2First) {
            if (!match1_1 && !match2_1) {
                Debug.Log("Button 2_1 selected");
                match2_1 = true;
                button2_1.GetComponent<Image>().color = Color.yellow;
            } else {
                match2_1 = false;
                button2_1.GetComponent<Image>().color = btn2_1Original;
            }
        }
    }

    public void Match22 () {
        if (!m2First) {
            if (!match1_2 && !match2_2) {
                Debug.Log("Button 2_2 selected");
                match2_2 = true;
                button2_2.GetComponent<Image>().color = Color.yellow;
            } else {
                match2_2 = false;
                button2_2.GetComponent<Image>().color = btn2_2Original;
            }
        }
    }


/*
    public void Match22 () {
        if (((!match1_2) || m2First) && !match2_2) {
            Debug.Log("Button 2_2 selected");
            match2_2 = true;
        } else {
            match2_2 = false;
        }
    }
    */
}
