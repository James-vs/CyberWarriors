using UnityEngine;
using UnityEngine.UI;

public class StSLevel1Manager : StSManager
{
    [SerializeField] protected bool m1First = false;
    [SerializeField] protected bool m2First = false;
    [SerializeField] protected bool m3First = false;
    [SerializeField] protected bool m4First = false;
    [SerializeField] protected bool m5First = false;
    protected bool match1_1 = false;
    protected bool match1_2 = false;
    protected bool match2_1 = false;
    protected bool match2_2 = false;
    protected bool match3_1 = false;
    protected bool match3_2 = false;
    protected bool match4_1 = false;
    protected bool match4_2 = false;
    protected bool match5_1 = false;
    protected bool match5_2 = false;
    [SerializeField] protected GameObject button1_1;
    [SerializeField] protected GameObject button1_2;
    [SerializeField] protected GameObject button2_1;
    [SerializeField] protected GameObject button2_2;
    [SerializeField] protected GameObject button3_1;
    [SerializeField] protected GameObject button3_2;
    [SerializeField] protected GameObject object4_1;
    [SerializeField] protected GameObject object4_2;
    [SerializeField] protected GameObject object5_1;
    [SerializeField] protected GameObject object5_2;
    protected Color btn1_1Original;
    protected Color btn1_2Original;
    protected Color btn2_1Original;
    protected Color btn2_2Original;
    protected Color btn3_1Original;
    protected Color btn3_2Original;
    protected Color img4_1Original;
    protected Color img4_2Original;
    protected Color img5_1Original;
    protected Color img5_2Original;
    protected (bool, GameObject, Color)[] matchList2;
    protected (bool, GameObject, Color)[] matchList1;
    [SerializeField] protected FlashEffect flashEffect;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("StSLevel1Manager running");
        //get the buttons' original colors
        GetButtonOriginColours();
        CheckForHighscore(highScoreKey);
        ResetScore();
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
                SaveScore(scoreKey,highScoreKey,matches);
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
    public virtual void AllMatched() {    
        Match1Found();
        Match2Found();
        Match3Found();
        Match4Found();
        Match5Found();
        CheckForMissMatch();
    }



    //function to handle miss matches
    protected virtual void CheckForMissMatch()
    {
        matchList1 = new (bool, GameObject, Color)[] { 
            (match1_1, button1_1, btn1_1Original), 
            (match2_1, button2_1, btn2_1Original),
            (match3_1, button3_1, btn3_1Original),
            (match4_1, object4_1, img4_1Original),
            (match5_1, object5_1, img5_1Original)
        };
        matchList2 = new (bool, GameObject, Color)[] { 
            (match1_2, button1_2, btn1_2Original), 
            (match2_2, button2_2, btn2_2Original),
            (match3_2, button3_2, btn3_2Original),
            (match4_2, object4_2, img4_2Original),
            (match5_2, object5_2, img5_2Original)
        };

        for (int i = 0; i < matchList1.Length; i++)
        {
            for (int j = 0; j < matchList2.Length; j++)
            {
                if (i == j) continue;
                //Debug.Log(i + " : " + j);
                //Debug.Log(matchList1[i].Item1.ToString() + " : " + matchList2[j].Item1.ToString());
                var element1 = matchList1[i]; var element2 = matchList2[j];
                if (element1.Item1 && element2.Item1)
                {
                    Debug.Log("Missmatch found");
                    flashEffect.StartFlash(element1.Item2, element2.Item2, element1.Item3, element2.Item3, 1f);
                    ResetBool(1, i + 1);
                    ResetBool(2, j + 1);
                    /*Debug.Log($"Match values after Missmatch: m11 = {match1_1}, m12 = {match1_2}, " +
                        $"m21 = {match2_1}, m22 = {match2_2}" +
                        $"m31 = {match3_1}, m32 = {match3_2}" +
                        $"m41 = {match4_1}, m42 = {match4_2}" +
                        $"m51 = {match5_1}, m52 = {match5_2}");*/
                    return;
                }
            }
        }
    }


    /// <summary>
    /// function to reset the match boolean variables of miss-matched elements
    /// </summary>
    /// <param name="matchList">the page the element is on</param>
    /// <param name="match">the index position of the match in the matchlist</param>
    protected virtual void ResetBool(int matchList, int match)
    {
        //Debug.Log($"matchlist = {matchList}, match = {match}");
        switch (matchList)
        {
            case 1: switch (match) {
                    case 1: match1_1 = false; break;
                    case 2: match2_1 = false; break;
                    case 3: match3_1 = false; break;
                    case 4: match4_1 = false; break;
                    case 5: match5_1 = false; break;
                    //default: Debug.Log("Matches Error"); break;
                }
                break;
            case 2: switch (match) {
                    case 1: match1_2 = false; break;
                    case 2: match2_2 = false; break;
                    case 3: match3_2 = false; break;
                    case 4: match4_2 = false; break;
                    case 5: match5_2 = false; break;
                    //default: Debug.Log("Matches Error"); break;
                }
                break;
        }
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
        Debug.Log("Match11 function");
        float select = MatchItemList(m1First,1,match1_1,button1_1,btn1_1Original);
        if (select == 1) {
            match1_1 = true;
        } else if (select == 2) {
            match1_1 = false;
        }
    }

    public void Match12() {
        Debug.Log("Match12 function");
        float select = MatchItemList(m1First,2,match1_2,button1_2,btn1_2Original);
        if (select == 1) {
            match1_2 = true;
        } else if (select == 2) {
            match1_2 = false;
        }
    }

    public void Match21 () {
        Debug.Log("Match21 function");
        float select = MatchItemList(m2First,1,match2_1,button2_1,btn2_1Original);
        if (select == 1) {
            match2_1 = true;
        } else if (select == 2) {
            match2_1 = false;
        }
    }

    public void Match22 () {
        Debug.Log("Match22 function");
        float select = MatchItemList(m2First,2,match2_2,button2_2,btn2_2Original);
        if (select == 1) {
            match2_2 = true;
        } else if (select == 2) {
            match2_2 = false;
        }
    }

    public void Match31 () {
        Debug.Log("Match31 function");
        float select = MatchItemList(m3First,1,match3_1,button3_1,btn3_1Original);
        if (select == 1) {
            match3_1 = true;
        } else if (select == 2) {
            match3_1 = false;
        }
    }

    public void Match32 () {
        Debug.Log("Match32 function");
        float select = MatchItemList(m3First,2,match3_2,button3_2,btn3_2Original);
        if (select == 1) {
            match3_2 = true;
        } else if (select == 2) {
            match3_2 = false;
        }
    }

    public void Match41 () {
        Debug.Log("Match41 function");
        float select = MatchItemList(m4First,1,match4_1,object4_1.transform.GetChild(0).gameObject,img4_1Original);
        if (select == 1) {
            match4_1 = true;
        } else if (select == 2) {
            match4_1 = false;
        }
    }

    public void Match42 () {
        Debug.Log("Match42 function");
        float select = MatchItemList(m4First,2,match4_2,object4_2.transform.GetChild(0).gameObject,img4_2Original);
        if (select == 1) {
            match4_2 = true;
        } else if (select == 2) {
            match4_2 = false;
        }
    }

    public void Match51 () {
        Debug.Log("Match51 function");
        float select = MatchItemList(m5First,1,match5_1,object5_1.transform.GetChild(0).gameObject,img5_1Original);
        if (select == 1) {
            match5_1 = true;
        } else if (select == 2) {
            match5_1 = false;
        }
    }

    public void Match52 () {
        Debug.Log("Match52 function");
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
