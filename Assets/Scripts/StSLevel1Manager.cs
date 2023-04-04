using UnityEngine;
using UnityEngine.UI;

public class StSLevel1Manager : StSManager
{
    [SerializeField] private bool m1First = false;
    [SerializeField] private bool m2First = false;
    [SerializeField] private bool m3First = false;
    private bool[] elemHalf1;
    private bool[] elemHalf2;
    private bool match1_1 = false;
    private bool match1_2 = false;
    private bool match2_1 = false;
    private bool match2_2 = false;
    private bool match3_1 = false;
    private bool match3_2 = false;
    [SerializeField] private GameObject button1_1;
    [SerializeField] private GameObject button1_2;
    [SerializeField] private GameObject button2_1;
    [SerializeField] private GameObject button2_2;
    [SerializeField] private GameObject button3_1;
    [SerializeField] private GameObject button3_2;
    private Color btn1_1Original;
    private Color btn1_2Original;
    private Color btn2_1Original;
    private Color btn2_2Original;
    private Color btn3_1Original;
    private Color btn3_2Original;

    


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("StSLevel1Manager running");
        btn1_1Original = button1_1.GetComponent<Image>().color;
        btn1_2Original = button1_2.GetComponent<Image>().color;
        btn2_1Original = button2_1.GetComponent<Image>().color;
        btn2_2Original = button2_2.GetComponent<Image>().color;
        btn3_1Original = button3_1.GetComponent<Image>().color;
        btn3_2Original = button3_2.GetComponent<Image>().color;
        //matchList = new bool[]{m1First,m2First,m3First};
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver) {
            if (CheckComplete()) {
                Debug.Log("Both pairs matched");
                success.SetActive(true);
                gameOver = true;
                timer.StopTimer();
            }
        } else if (outOfTime) {
            fail.SetActive(true);
        }
        matchesUI.text = matches.ToString();
    }




    //function to handle when all matches have been found 
    public bool CheckComplete() {
        //check for m1&m2 in all cases 
        if (!Match1Found() || !Match2Found() || !Match3Found())
        {
            return false;
        }
        return true;
    }




    //functions to handle matches
    public bool Match1Found() {
        if (match1_1 && match1_2) {
            if (!m1First) {
                Debug.Log("First pair matched");
                matches += 1;
                m1First = true;
                match1_1 = false;
                match1_2 = false;
                button1_1.GetComponent<Image>().color = Color.green;
                button1_2.GetComponent<Image>().color = Color.green;
            }
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

    public bool Match3Found() {
        if (match3_1 && match3_2) {
            if (!m3First) {
                Debug.Log("Third pair matched");
                matches += 1;
            }
            //match?_? added
            match3_1 = false;
            match3_2 = false;
            button3_1.GetComponent<Image>().color = Color.green;
            button3_2.GetComponent<Image>().color = Color.green;
            m3First = true;
            return true;
        } else {
            return false;
        }
    }




    //functions to handle button colour changing + boolean value changing
    public void Match11() {
        float select = MatchItem(m1First,match2_1,match1_1,button1_1,btn1_1Original);
        if (select == 1) {
            match1_1 = true;
        } else if (select == 2) {
            match1_1 = false;
        }
    }

    public void Match12() {
        float select = MatchItem(m1First,match2_2,match1_2,button1_2,btn1_2Original);
        if (select == 1) {
            match1_2 = true;
        } else if (select == 2) {
            match1_2 = false;
        }
    }

    public void Match21 () {
        float select = MatchItem(m2First,match1_1,match2_1,button2_1,btn2_1Original);
        if (select == 1) {
            match2_1 = true;
        } else if (select == 2) {
            match2_1 = false;
        }
    }

    public void Match22 () {
        float select = MatchItem(m2First,match1_2,match2_2,button2_2,btn2_2Original);
        if (select == 1) {
            match2_2 = true;
        } else if (select == 2) {
            match2_2 = false;
        }
    }

    public void Match31 () {
        float select = MatchItemList(m3First,1,match3_1,button3_1,btn3_1Original);
        if (select == 1) {
            match3_1 = true;
        } else if (select == 2) {
            match3_1 = false;
        }
    }

    public void Match32 () {
        float select = MatchItemList(m3First,2,match3_2,button3_2,btn3_2Original);
        if (select == 1) {
            match3_2 = true;
        } else if (select == 2) {
            match3_2 = false;
        }
    }




    //function to select a given button
    public float MatchItem(bool mFirst, bool match1, bool match2, GameObject button, Color btnOriginal) {
        float isMatch = Match(mFirst,match1,match2);
        if (isMatch == 1) { 
            Debug.Log("Button selected");
            button.GetComponent<Image>().color = Color.yellow;
            return 1;
        } else if (isMatch == 2) {
            button.GetComponent<Image>().color = btnOriginal;
            return 2;
        }
        return 3;
    }

    public float MatchItemList(bool mFirst, float half, bool match2, GameObject button, Color btnOriginal) {
        bool[] match1;
        if (half == 1) {
            match1 = new bool[]{this.match1_1,this.match2_1,this.match3_1};
        } else {
            match1 = new bool[]{this.match1_2,this.match2_2,this.match3_2};
        }

        float isMatch = MatchMulti(mFirst,ItemsTrue(match1),match2);
        if (isMatch == 1) { 
            Debug.Log("Button selected");
            button.GetComponent<Image>().color = Color.yellow;
            return 1;
        } else if (isMatch == 2) {
            button.GetComponent<Image>().color = btnOriginal;
            return 2;
        }
        return 3;
    }

    //function to handle logic for matching and selecting of buttons
    public float MatchMulti(bool firstMatch, bool pair1, bool match1) {
        if (!firstMatch && !outOfTime) {
            if (!pair1 && !match1) {
                return 1; //if button selected
            } else {
                return 2; //if button deselected
            }
        }
        return 3; //do nothing
    }

    //function to check if any items are true in a list
    public bool ItemsTrue(bool[] pairs) {
        //bool result = true;
        foreach (var item in pairs) {
            if (item == true) return true;
        }
        return false;
    }




    //function to reset the game for a retry
    public void Retry() {
        match1_1 = false;
        match1_2 = false;
        match2_1 = false;
        match2_2 = false;
        match3_1 = false;
        match3_2 = false;
        m1First = false;
        m2First = false;
        m3First = false;
        OutOfTime(false);
        fail.SetActive(false);
        loadNextScene.ChangeScene(0);
    }

}
