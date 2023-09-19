using UnityEngine;

public class StSLevel3Manager : StSLevel2Manager
{
    [SerializeField] protected GameObject shareWithFriends1;
    [SerializeField] protected GameObject shareWithFriends2;




    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("StSLevel3Manager running");
        //get the buttons' original colors
        //assigning btn1 to btn3 to get rid of unassignedReferenceException for it
        //resetting the cookies and score
        button3_1 = button1_1;
        button3_2 = button1_1;
        GetButtonOriginColours();
        CheckForHighscore(highScoreKey);
        ResetCookiesAndSettings();
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
    /// function to reset the saved cookies and browser settings for the level
    /// </summary>
    protected void ResetCookiesAndSettings() {
        PlayerPrefs.SetInt(cookie1,0);
        PlayerPrefs.SetInt(cookie2,0);
        PlayerPrefs.SetInt("l3DNT",0);
        PlayerPrefs.SetInt("l3Inc",0);
        PlayerPrefs.SetInt("l3PS",0);
    }




    //function to handle when all matches have been found 
    public new bool CheckComplete() {
        AllMatched();
        if (goodCookieChoice) {
            if (m1First && m4First && m5First) {
                Debug.Log("CheckComplete return true");
                return true;
            } else {
                return false;
            }
        } else {
            if (m1First && m2First && m4First && m5First) {
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
    protected new void CheckGoodCookie() {
        if (PlayerPrefs.GetInt(cookie1) == 2 && PlayerPrefs.GetInt(cookie2) == 2) {
            shareWithFriends1.SetActive(false);
            shareWithFriends2.SetActive(false);
            totalMatches = 3f;
            goodCookieChoice = true;
            checkedGoodCookie = true;
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
        float settingsScore = (PlayerPrefs.GetInt("l3DNT") * 1000) + (PlayerPrefs.GetInt("l3Inc") * 1000) + (PlayerPrefs.GetInt("l3PS") * 1000);
        float cookieScore = (PlayerPrefs.GetInt(cookie1) * 1000) + (PlayerPrefs.GetInt(cookie2) * 1000);
        float score = matches * (1000 + (timer.GetValue() * 10)) + cookieScore + settingsScore;
        PlayerPrefs.SetFloat(scoreKey,score);

        if (PlayerPrefs.GetFloat(highScoreKey) < score) {
            PlayerPrefs.SetFloat(highScoreKey,score);
        }
    }

}
