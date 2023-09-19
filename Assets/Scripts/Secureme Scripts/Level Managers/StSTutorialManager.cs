using UnityEngine;
using UnityEngine.UI;

public class StSTutorialManager : StSManager
{
    [SerializeField] private bool m1First = false;
    [SerializeField] private bool m2First = false;
    private bool match1_1 = false;
    private bool match1_2 = false;
    private bool match2_1 = false;
    private bool match2_2 = false;
    [SerializeField] private GameObject button1_1;
    [SerializeField] private GameObject button1_2;
    [SerializeField] private GameObject button2_1;
    [SerializeField] private GameObject button2_2;
    private Color btn1_1Original;
    private Color btn1_2Original;
    private Color btn2_1Original;
    private Color btn2_2Original;
    private (bool, GameObject, Color)[] matchList2;
    private (bool, GameObject, Color)[] matchList1;
    [SerializeField] protected FlashEffect flashEffect;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("StSTutorialManager running");
        btn1_1Original = button1_1.GetComponent<Image>().color;
        btn1_2Original = button1_2.GetComponent<Image>().color;
        btn2_1Original = button2_1.GetComponent<Image>().color;
        btn2_2Original = button2_2.GetComponent<Image>().color;
        CheckForHighscore(highScoreKey);
        ResetScore();
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
                SaveScore(scoreKey,highScoreKey,matches);
            }
        } else if (outOfTime) {
            fail.SetActive(true);
        }
        matchesUI.text = matches.ToString();
    }




    //function to handle when all matches have been found 
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
            CheckForMissMatch();
            return false;
        }
    }

    //function to handle miss matches
    protected void CheckForMissMatch()
    {
        matchList1 = new (bool, GameObject, Color)[] { (match1_1, button1_1, btn1_1Original), (match2_1, button2_1, btn2_1Original) };
        matchList2 = new (bool, GameObject, Color)[] { (match1_2, button1_2, btn1_2Original), (match2_2, button2_2, btn2_2Original) };

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
                    ResetBool(1, i+1);
                    ResetBool(2, j+1);
                    //Debug.Log($"Match values after Missmatch: m11 = {match1_1}, m12 = {match1_2}, m21 = {match2_1}, m22 = {match2_2}");
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
    protected void ResetBool(int matchList, int match)
    {
        switch (matchList)
        {
            case 1: switch (match) {
                    case 1: match1_1 = false; break;
                    case 2: match2_1 = false; break;
                    //default: Debug.Log("Matches Error"); break;
                }
                break;
            case 2: switch (match) {
                    case 1: match1_2 = false; break;
                    case 2: match2_2 = false; break;
                    //default: Debug.Log("Matches Error"); break;
                }
                break;
        }
    }




    //functions to handle matches
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




    //functions to handle button colour + boolean value changing (not including miss-matches)
    public void Match11() {
        float isMatch = Match(m1First,match2_1,match1_1);
        if (isMatch == 1) {
            Debug.Log("Button 1_1 selected");
            match1_1 = true;
            button1_1.GetComponent<Image>().color = Color.yellow;
        } else if (isMatch == 2) {
            match1_1 = false;
            button1_1.GetComponent<Image>().color = btn1_1Original;
        }
    }

    public void Match12() {
        float isMatch = Match(m1First,match2_2,match1_2);
        if (isMatch == 1) {
            Debug.Log("Button 1_2 selected");
            match1_2 = true;
            button1_2.GetComponent<Image>().color = Color.yellow;
        } else if (isMatch == 2) {
            match1_2 = false;
            button1_2.GetComponent<Image>().color = btn1_2Original;
        }
    }

    public void Match21 () {
        float isMatch = Match(m2First,match1_1,match2_1);
        if (isMatch == 1) {
            Debug.Log("Button 2_1 selected");
            match2_1 = true;
            button2_1.GetComponent<Image>().color = Color.yellow;
        } else if (isMatch == 2) {
            match2_1 = false;
            button2_1.GetComponent<Image>().color = btn2_1Original;
        }
    }

    public void Match22 () {
        float isMatch = Match(m2First,match1_2,match2_2);
        if (isMatch == 1) {
            Debug.Log("Button 2_2 selected");
            match2_2 = true;
            button2_2.GetComponent<Image>().color = Color.yellow;
        } else if (isMatch == 2) {
            match2_2 = false;
            button2_2.GetComponent<Image>().color = btn2_2Original;
        }
    }




    //function to reset the game for a retry
    public void Retry() {
        match1_1 = false;
        match1_2 = false;
        match2_1 = false;
        match2_2 = false;
        m1First = false;
        m2First = false;
        OutOfTime(false);
        fail.SetActive(false);
        loadNextScene.ChangeScene(0);
    }
    
}
