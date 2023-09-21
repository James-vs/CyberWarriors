using UnityEngine;

public class StSLevel2Manager : StSLevel1Manager
{
    [SerializeField] protected float totalMatches = 4;
    protected bool goodCookieChoice = false;
    protected bool checkedGoodCookie = false;
    [SerializeField] protected string cookie1;
    [SerializeField] protected string cookie2;




    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("StSLevel2Manager running");
        //get the buttons' original colors
        //assigning btn1 to btn3 to get rid of unassignedReferenceException for it
        button3_1 = button1_1;
        button3_2 = button1_1;
        GetButtonOriginColours();
        CheckForHighscore(highScoreKey);
        ResetCookies();
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
                PlayerPrefs.SetInt(browserProgression, 3);
                SaveScore(scoreKey,highScoreKey,matches);
            }
        } else if (outOfTime) {
            fail.SetActive(true);
        }
        matchesUI.text = matches.ToString() + " / " + totalMatches.ToString();
        
        if (!checkedGoodCookie) CheckGoodCookie();
    }




    /// <summary>
    /// function to reset the saved cookies for the level
    /// </summary>
    protected void ResetCookies() {
        PlayerPrefs.SetInt(cookie1,0);
        PlayerPrefs.SetInt(cookie2,0);
    }




    //function to handle when all matches have been found 
    public new bool CheckComplete() {
        AllMatched();
        if (goodCookieChoice) {
            if (m1First && m4First && m5First) { // && m3First
                Debug.Log("CheckComplete return true");
                return true;
            } else {
                return false;
            }
        } else {
            if (m1First && m2First && m4First && m5First) { // && m3First
                Debug.Log("CheckComplete return true");
                return true;
            } else {
                return false;
            }
        }   
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
        matchList2 = new (bool, GameObject, Color)[] {
            (match1_2, button1_2, btn1_2Original),
            (match2_2, button2_2, btn2_2Original),
            //(match3_2, button3_2, btn3_2Original),
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
                        //$"m31 = {match3_1}, m32 = {match3_2}" +
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
    protected override void ResetBool(int matchList, int match)
    {
        Debug.Log($"matchlist = {matchList}, match = {match}");
        switch (matchList)
        {
            case 1: switch (match) {
                    case 1: match1_1 = false; break;
                    case 2: match2_1 = false; break;
                    //case 3: match3_1 = false; break;
                    case 3: match4_1 = false; break;
                    case 4: match5_1 = false; break;
                    //default: Debug.Log("Matches Error"); break;
                }
                break;
            case 2: switch (match) {
                    case 1: match1_2 = false; break;
                    case 2: match2_2 = false; break;
                    //case 3: match3_2 = false; break;
                    case 3: match4_2 = false; break;
                    case 4: match5_2 = false; break;
                    //default: Debug.Log("Matches Error"); break;
                }
                break;
        }
    }


    /// <summary>
    /// function to check if the best cookie setting has been selected and adjust settings and ui accordingly
    /// </summary>
    protected void CheckGoodCookie() {
        if (PlayerPrefs.GetInt(cookie1) == 2 && PlayerPrefs.GetInt(cookie2) == 2) {
            button2_1.transform.parent.gameObject.SetActive(false);
            button2_2.transform.parent.gameObject.SetActive(false);
            totalMatches = 3f;
            goodCookieChoice = true;
            checkedGoodCookie = true;
        }
    }




    //function to check for matches for all visible pairs
    public override void AllMatched() {
        if (goodCookieChoice) {
            Match1Found();
            Match4Found();
            Match5Found();
            CheckForMissMatch();
        } else {
            Match1Found();
            Match2Found();
            Match4Found();
            Match5Found();
            CheckForMissMatch();
        }
    }




    // function to return bool list of all elements from relative page number
    public new bool[] getItemPageList(float page) {
        if (goodCookieChoice) {
            if (page == 1) {
                return new bool[]{this.match1_1,this.match4_1,this.match5_1};
            } else {
                return new bool[]{this.match1_2,this.match4_2,this.match5_2};
            }
        } else {
            if (page == 1) {
                return new bool[]{this.match1_1,this.match2_1,this.match4_1,this.match5_1};
            } else {
                return new bool[]{this.match1_2,this.match2_2,this.match4_2,this.match5_2};
            }
        }
        
    }




    //function to reset the game for a retry
    public new void Retry() {
        match1_1 = false;
        match1_2 = false;
        match2_1 = false;
        match2_2 = false;
        match4_1 = false;
        match4_2 = false;
        match5_1 = false;
        match5_2 = false;
        m1First = false;
        m2First = false;
        m3First = false;
        m5First = false;
        OutOfTime(false);
        fail.SetActive(false);
        loadNextScene.ChangeScene(0);
    }




    // function to save the score + append the highscore
    protected new void SaveScore(string scoreKey, string highScoreKey, int matches){
        matches = 4;
        float cookieScore = (PlayerPrefs.GetInt(cookie1) * 1000) + (PlayerPrefs.GetInt(cookie2) * 1000);
        float score = matches * (1000 + (timer.GetValue() * 10)) + cookieScore;
        PlayerPrefs.SetFloat(scoreKey,score);

        if (PlayerPrefs.GetFloat(highScoreKey) < score) {
            PlayerPrefs.SetFloat(highScoreKey,score);
        }
    }

}
