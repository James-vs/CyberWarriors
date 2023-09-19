using UnityEngine;
using UnityEngine.UI;

public class PermissionsManager : StSLevel1Manager
{
    private bool fake1 = false;
    private bool fake2 = false;
    [SerializeField] protected GameObject fake1Object;
    [SerializeField] protected GameObject fake2Object;


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
        matchesUI.text = matches.ToString() + " / 4";
    }




    //function to get the colors of all buttons
    public new void GetButtonOriginColours(){
        btn1_1Original = button1_1.transform.GetChild(0).GetComponent<Image>().color;
        btn1_2Original = button1_2.transform.GetChild(0).GetComponent<Image>().color;
        btn2_1Original = button2_1.transform.GetChild(0).GetComponent<Image>().color;
        btn2_2Original = button2_2.transform.GetChild(0).GetComponent<Image>().color;
        img4_1Original = object4_1.transform.GetChild(0).GetComponent<Image>().color;
        img4_2Original = object4_2.transform.GetChild(0).GetComponent<Image>().color;
        img5_1Original = object5_1.transform.GetChild(0).GetComponent<Image>().color;
        img5_2Original = object5_2.transform.GetChild(0).GetComponent<Image>().color;

        // colour for fakes
        btn3_1Original = button3_1.transform.GetChild(0).GetComponent<Image>().color;
    }




    //function to handle when all matches have been found 
    public new bool CheckComplete() {
        AllMatched();
        if (m1First && m2First && m4First && m5First) {
            Debug.Log("CheckComplete return true");
            return true;
        } else {
            return false;
        }
    }



    //overriden function to check for matches for all pairs
    public new void AllMatched() {    
        Match1Found();
        Match2Found();
        Match4Found();
        Match5Found();
        CheckForMissMatch();
    }


    //function to handle miss matches
    protected override void CheckForMissMatch()
    {
        matchList1 = new (bool, GameObject, Color)[] {
            (match1_1, button1_1, btn1_1Original),
            (match2_1, button2_1, btn2_1Original),
            //(match3_1, button3_1, btn3_1Original),
            (match4_1, object4_1, img4_1Original),
            (match5_1, object5_1, img5_1Original)
        };

        // this assignment needs rethinking...
        matchList2 = new (bool, GameObject, Color)[] {
            (match1_2, button1_2, btn1_2Original),
            (match2_2, button2_2, btn2_2Original),
            (match4_2, object4_2, img4_2Original),
            (match5_2, object5_2, img5_2Original),
            (match3_2, button3_2, btn3_1Original),
            (fake1, fake1Object, btn3_1Original),
            (fake2, fake2Object, btn3_1Original)
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
                    flashEffect.StartFlash(ref element1.Item2, ref element2.Item2, element1.Item3, element2.Item3, 1f);

                    element1.Item1 = false; element2.Item1 = false;
                    //bombaclart = true;
                    ResetBool(1, i + 1);
                    ResetBool(2, j + 1);
                    Debug.Log($"Match values after Missmatch: m11 = {match1_1}, m12 = {match1_2}, " +
                        $"m21 = {match2_1}, m22 = {match2_2}," +
                        //$"m31 = {match3_1}, m32 = {match3_2}" +
                        $"m41 = {match4_1}, m42 = {match4_2}," +
                        $"m51 = {match5_1}, m52 = {match5_2}");
                    return;
                }
            }
        }

        //Debug.Log($"Match values after Missmatch: m11 = {match1_1}, m12 = {match1_2}, m21 = {match2_1}, m22 = {match2_2}");
    }



    protected override void ResetBool(int matchList, int match)
    {
        Debug.Log($"matchlist = {matchList}, match = {match}");
        // Chunky switch statement that resets the match___ variable associated with the match and matchlist number provided.
        // Had to use this method - couldn't figure out how to call the match bools by reference rather than value in CheckForMissMatch()
        switch (matchList)
        {
            case 1:
                switch (match)
                {
                    case 1: match1_1 = false; break;
                    case 2: match2_1 = false; break;
                    //case 3: match3_1 = false; break;
                    case 3: match4_1 = false; break;
                    case 4: match5_1 = false; break;
                    default: Debug.Log("Matches Error"); break;
                }
                break;
            case 2:
                switch (match)
                {
                    case 1: match1_2 = false; break;
                    case 2: match2_2 = false; break;
                    //case 3: match3_2 = false; break;
                    case 3: match4_2 = false; break;
                    case 4: match5_2 = false; break;
                    case 5: match3_2 = false; break;
                    case 6: fake1 = false; break;
                    case 7: fake2 = false; break;
                    default: Debug.Log("Matches Error"); break;
                }
                break;
                //default:
                //Debug.Log("MatchList Error"); break;
        }
    }


    // overridden functions to handle matches of pairs
    public new bool Match1Found() {
        if (match1_1 && match1_2) {
            if (!m1First) {
                Debug.Log("First pair matched");
                matches += 1;
                m1First = true;
                match1_1 = false;
                match1_2 = false;
                button1_1.transform.GetChild(0).GetComponent<Image>().color = Color.green;
                button1_2.transform.GetChild(0).GetComponent<Image>().color = Color.green;
            }
            return true;
        } else {
            return false;
        }
    }

    public new bool Match2Found() {
        if (match2_1 && match2_2) {
            if (!m2First) {
                Debug.Log("Second pair matched");
                matches += 1;
            }
            //match?_? added
            match2_1 = false;
            match2_2 = false;
            button2_1.transform.GetChild(0).GetComponent<Image>().color = Color.green;
            button2_2.transform.GetChild(0).GetComponent<Image>().color = Color.green;
            m2First = true;
            return true;
        } else {
            return false;
        }
    }



    // overriden functions to handle button colour changing + boolean value changing
    public new void Match11() {
        float select = MatchItemList(m1First,1,match1_1,button1_1.transform.GetChild(0).gameObject,btn1_1Original);
        if (select == 1) {
            match1_1 = true;
        } else if (select == 2) {
            match1_1 = false;
        }
    }

    public new void Match12() {
        float select = MatchItemList(m1First,2,match1_2,button1_2.transform.GetChild(0).gameObject,btn1_2Original);
        if (select == 1) {
            match1_2 = true;
        } else if (select == 2) {
            match1_2 = false;
        }
    }

    public new void Match21 () {
        float select = MatchItemList(m2First,1,match2_1,button2_1.transform.GetChild(0).gameObject,btn2_1Original);
        if (select == 1) {
            match2_1 = true;
        } else if (select == 2) {
            match2_1 = false;
        }
    }

    public new void Match22 () {
        float select = MatchItemList(m2First,2,match2_2,button2_2.transform.GetChild(0).gameObject,btn2_2Original);
        if (select == 1) {
            match2_2 = true;
        } else if (select == 2) {
            match2_2 = false;
        }
        Debug.Log("Match22");
    }

    // Match41 and Match51 not called as they dont need to reference the new MatchItemList function to behave correctly
    public new void Match42 () {
        float select = MatchItemList(m4First,2,match4_2,object4_2.transform.GetChild(0).gameObject,img4_2Original);
        if (select == 1) {
            match4_2 = true;
        } else if (select == 2) {
            match4_2 = false;
        }
    }

    public new void Match52 () {
        float select = MatchItemList(m5First,2,match5_2,object5_2.transform.GetChild(0).gameObject,img5_2Original);
        if (select == 1) {
            match5_2 = true;
        } else if (select == 2) {
            match5_2 = false;
        }
    }


    // functions to simulate a real match item by changing the color when selected
    public void FakeMatch1(GameObject obj) {
        if (button3_2 == null) button3_2 = obj;
        float select = MatchItemList(m3First,2,match3_2,obj,btn3_1Original);
        if (select == 1) {
            match3_2 = true;
        } else if (select == 2) {
            match3_2 = false;
        }
    }

    public void FakeMatch2(GameObject obj) {
        if (fake1Object == null) fake1Object = obj;
        float select = MatchItemList(m3First,2,fake1,obj,btn3_1Original);
        if (select == 1) {
            fake1 = true;
        } else if (select == 2) {
            fake1 = false;
        }
    }

    public void FakeMatch3(GameObject obj) {
        if (fake2Object == null) fake2Object = obj;
        float select = MatchItemList(m3First,2,fake2,obj,btn3_1Original);
        if (select == 1) {
            fake2 = true;
        } else if (select == 2) {
            fake2 = false;
        }
    }



    // overriden function to select or deselect a given button
    public new float MatchItemList(bool mFirst, float page, bool match2, GameObject imageObject, Color btnOriginal) {
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
    public new bool[] getItemPageList(float page) {
        if (page == 1) {
            return new bool[]{this.match1_1,this.match2_1,this.match4_1,this.match5_1};
        } else {
            return new bool[]{this.match1_2,this.match2_2,this.match3_2,fake1,fake2,this.match4_2,this.match5_2};
        }
    }




    //overriden function to reset the game for a retry
    public new void Retry() {
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
        fake1 = false;
        fake2 = false;
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
