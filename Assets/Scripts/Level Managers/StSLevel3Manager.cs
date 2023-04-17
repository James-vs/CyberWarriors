using UnityEngine;

public class StSLevel3Manager : StSLevel2Manager
{
    /*[SerializeField] protected float totalMatches = 4;
    protected bool goodCookieChoice = false;
    protected bool checkedGoodCookie = false;
    [SerializeField] protected string cookie1;
    [SerializeField] protected string cookie2;*/




    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("StSLevel3Manager running");
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
    /*protected void ResetCookies() {
        PlayerPrefs.SetInt(cookie1,0);
        PlayerPrefs.SetInt(cookie2,0);
    }*/




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



    /// <summary>
    /// function to check if the best cookie setting has been selected and adjust settings and ui accordingly
    /// </summary>
    /*protected void CheckGoodCookie() {
        if (PlayerPrefs.GetInt(cookie1) == 2 && PlayerPrefs.GetInt(cookie2) == 2) {
            button2_1.transform.parent.gameObject.SetActive(false);
            button2_2.transform.parent.gameObject.SetActive(false);
            totalMatches = 3f;
            goodCookieChoice = true;
            checkedGoodCookie = true;
        }
    }*/




    //function to check for matches for all visible pairs
    public new void AllMatched() {
        if (goodCookieChoice) {
            Match1Found();
            Match4Found();
            Match5Found();
        } else {
            Match1Found();
            Match2Found();
            Match4Found();
            Match5Found();
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