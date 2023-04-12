using UnityEngine;
using UnityEngine.UI;

public class StSLevel1Manager : StSManager
{
    [SerializeField] private bool m1First = false;
    [SerializeField] private bool m2First = false;
    [SerializeField] private bool m3First = false;
    [SerializeField] private bool m4First = false;
    [SerializeField] private bool m5First = false;
    private bool match1_1 = false;
    private bool match1_2 = false;
    private bool match2_1 = false;
    private bool match2_2 = false;
    private bool match3_1 = false;
    private bool match3_2 = false;
    private bool match4_1 = false;
    private bool match4_2 = false;
    private bool match5_1 = false;
    private bool match5_2 = false;
    [SerializeField] private GameObject button1_1;
    [SerializeField] private GameObject button1_2;
    [SerializeField] private GameObject button2_1;
    [SerializeField] private GameObject button2_2;
    [SerializeField] private GameObject button3_1;
    [SerializeField] private GameObject button3_2;
    [SerializeField] private GameObject object4_1;
    [SerializeField] private GameObject object4_2;
    [SerializeField] private GameObject object5_1;
    [SerializeField] private GameObject object5_2;
    private Color btn1_1Original;
    private Color btn1_2Original;
    private Color btn2_1Original;
    private Color btn2_2Original;
    private Color btn3_1Original;
    private Color btn3_2Original;
    private Color img4_1Original;
    private Color img4_2Original;
    private Color img5_1Original;
    private Color img5_2Original;
    


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("StSLevel1Manager running");
        //get the buttons' original colors
        GetButtonOriginColours();
        CheckForHighscore("stslevel1highscore");
    }




    // Update is called once per frame
    void Update()
    {
        if (!this.gameOver) {
            if (CheckComplete()) {
                Debug.Log("All pairs matched");
                success.SetActive(true);
                this.gameOver = true;
                timer.StopTimer();
                SaveScore("stslevel1score","stslevel1highscore");
            }
        } else if (outOfTime) {
            fail.SetActive(true);
        }
        matchesUI.text = matches.ToString();
    }




    //function to get the colors of all buttons
    public void GetButtonOriginColours(){
        btn1_1Original = button1_1.GetComponent<Image>().color;
        btn1_2Original = button1_2.GetComponent<Image>().color;
        btn2_1Original = button2_1.GetComponent<Image>().color;
        btn2_2Original = button2_2.GetComponent<Image>().color;
        btn3_1Original = button3_1.GetComponent<Image>().color;
        btn3_2Original = button3_2.GetComponent<Image>().color;
        img4_1Original = object4_1.transform.GetChild(0).GetComponent<Image>().color;
        img4_2Original = object4_2.transform.GetChild(0).GetComponent<Image>().color;
        img5_1Original = object5_1.transform.GetChild(0).GetComponent<Image>().color;
        img5_2Original = object5_2.transform.GetChild(0).GetComponent<Image>().color;
    }




    //function to handle when all matches have been found 
    public bool CheckComplete() {
        AllMatched();
        if (m1First && m2First && m3First && m4First && m5First) {
            Debug.Log("CheckComplete return true");
            return true;
        } else {
            return false;
        }
    }




    //function to check for matches for all pairs
    public void AllMatched() {    
        Match1Found();
        Match2Found();
        Match3Found();
        Match4Found();
        Match5Found();
    }




    //functions to handle matches of pairs 
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

    public bool Match4Found() {
        if (match4_1 && match4_2) {
            if (!m4First) {
                Debug.Log("Fourth pair matched");
                matches += 1;
            }
            //match?_? added
            match4_1 = false;
            match4_2 = false;
            object4_1.transform.GetChild(0).GetComponent<Image>().color = Color.green;
            object4_2.transform.GetChild(0).GetComponent<Image>().color = Color.green;
            m4First = true;
            return true;
        } else {
            return false;
        }
    }

    public bool Match5Found() {
        if (match5_1 && match5_2) {
            if (!m5First) {
                Debug.Log("Fifth pair matched");
                matches += 1;
            }
            //match?_? added
            match5_1 = false;
            match5_2 = false;
            object5_1.transform.GetChild(0).GetComponent<Image>().color = Color.green;
            object5_2.transform.GetChild(0).GetComponent<Image>().color = Color.green;
            m5First = true;
            return true;
        } else {
            return false;
        }
    }




    //functions to handle button colour changing + boolean value changing
    public void Match11() {
        float select = MatchItemList(m1First,1,match1_1,button1_1,btn1_1Original);
        if (select == 1) {
            match1_1 = true;
        } else if (select == 2) {
            match1_1 = false;
        }
    }

    public void Match12() {
        float select = MatchItemList(m1First,2,match1_2,button1_2,btn1_2Original);
        if (select == 1) {
            match1_2 = true;
        } else if (select == 2) {
            match1_2 = false;
        }
    }

    public void Match21 () {
        float select = MatchItemList(m2First,1,match2_1,button2_1,btn2_1Original);
        if (select == 1) {
            match2_1 = true;
        } else if (select == 2) {
            match2_1 = false;
        }
    }

    public void Match22 () {
        float select = MatchItemList(m2First,2,match2_2,button2_2,btn2_2Original);
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

    public void Match41 () {
        float select = MatchItemList(m4First,1,match4_1,object4_1.transform.GetChild(0).gameObject,img4_1Original);
        if (select == 1) {
            match4_1 = true;
        } else if (select == 2) {
            match4_1 = false;
        }
    }

    public void Match42 () {
        float select = MatchItemList(m4First,2,match4_2,object4_2.transform.GetChild(0).gameObject,img4_2Original);
        if (select == 1) {
            match4_2 = true;
        } else if (select == 2) {
            match4_2 = false;
        }
    }

    public void Match51 () {
        float select = MatchItemList(m5First,1,match5_1,object5_1.transform.GetChild(0).gameObject,img5_1Original);
        if (select == 1) {
            match5_1 = true;
        } else if (select == 2) {
            match5_1 = false;
        }
    }

    public void Match52 () {
        float select = MatchItemList(m5First,2,match5_2,object5_2.transform.GetChild(0).gameObject,img5_2Original);
        if (select == 1) {
            match5_2 = true;
        } else if (select == 2) {
            match5_2 = false;
        }
    }



    // function to select or deselect a given button
    public float MatchItemList(bool mFirst, float page, bool match2, GameObject imageObject, Color btnOriginal) {
        bool[] itemList = getItemPageList(page);
        float isMatch = Match(mFirst,ItemsTrue(itemList),match2);
        if (isMatch == 1) { 
            Debug.Log("Button selected");
            imageObject.GetComponent<Image>().color = Color.yellow;
            return 1;
        } else if (isMatch == 2) {
            imageObject.GetComponent<Image>().color = btnOriginal;
            return 2;
        }
        return 3;
    }




    // function to return bool list of all elements from relative page number
    public bool[] getItemPageList(float page) {
        if (page == 1) {
            return new bool[]{this.match1_1,this.match2_1,this.match3_1,this.match4_1,this.match5_1};
        } else {
            return new bool[]{this.match1_2,this.match2_2,this.match3_2,this.match4_2,this.match5_2};
        }
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
        match4_1 = false;
        match4_2 = false;
        match5_1 = false;
        match5_2 = false;
        m1First = false;
        m2First = false;
        m3First = false;
        m4First = false;
        m5First = false;
        OutOfTime(false);
        fail.SetActive(false);
        loadNextScene.ChangeScene(0);
    }

}
