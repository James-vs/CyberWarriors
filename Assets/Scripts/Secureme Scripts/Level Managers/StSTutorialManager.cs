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
    private static bool bombaclart = false;


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
        //matchList1 = new (bool,GameObject)[] {(match1_1,button1_1), (match1_2,button1_2)};
        //matchList2 = new (bool,GameObject)[] {(match2_1,button2_1), (match2_2,button2_2)};
    }


    public void Something (int num)
    {
        //if (num == 0)
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
            if (!bombaclart) CheckForMissMatch();
            return false;
        }
    }

    //function to handle mismatches
    public void CheckForMissMatch()
    {
        //Debug.Log("CheckForMissMatch ran");
        // need to get a Call by Reference ting going here but dunno how :'(

        //ref bool _match1_1 = ref match1_1;
        //ref bool _match1_2 = ref match1_2;
        //ref bool _match2_1 = ref match2_1;
        //ref bool _match2_2 = ref match2_2;

        var matchList1 = new (bool, GameObject, Color)[] { (match1_1, button1_1, btn1_1Original), (match1_2, button1_2, btn1_2Original) };
        var matchList2 = new (bool, GameObject, Color)[] { (match2_1, button2_1, btn2_1Original), (match2_2, button2_2, btn2_2Original) };

        //ref match1_1 = ref matchList1[0].Item1;

        for (int i = 0; i < matchList1.Length; i++)
        {
            for (int j = 0; j < matchList2.Length; j++)
            {
                if (i == j) continue;
                Debug.Log(i + " : " + j);
                Debug.Log(matchList1[i].Item1.ToString() + " : " + matchList2[j].Item1.ToString());
                var element1 = matchList1[i]; var element2 = matchList2[j];
                if (element1.Item1 && element2.Item1)
                {
                    Debug.Log("Missmatch found");
                    flashEffect.StartFlash(ref element1.Item2, ref element2.Item2, element1.Item3, element2.Item3, 1f);
                    
                    //Tried to change the value of the match bools here but didnt work cause CBV!!!!!!! ffs
                    // ... may have to bite the bullet and make a new class...
                    element1.Item1 = false; element2.Item1 = false;
                    bombaclart = true;
                    ResetBool(1, i+1);
                    ResetBool(2, j+1);
                    Debug.Log($"Match values after Missmatch: m11 = {match1_1}, m12 = {match1_2}, m21 = {match2_1}, m22 = {match2_2}");
                    return;
                }
            }
            
        }

        Debug.Log($"Match values after Missmatch: m11 = {match1_1}, m12 = {match1_2}, m21 = {match2_1}, m22 = {match2_2}");
    }

    private void ResetBool(int matchList, int match)
    {
        // Chunky if/switch statement that resets the match___ variable associated with the match and matchlist number provided.
        switch (matchList)
        {
            case 1:
                // something
                switch (match)
                {
                    case 1:
                        match1_1 = false; break;
                    case 2:
                        match1_2 = false; break;
                    default: Debug.Log("Matches Error"); break;
                }
                break;
            case 2:
                // something else
                switch (match)
                {
                    case 1:
                        match2_1 = false; break;
                    case 2:
                        match2_2 = false; break;
                    default: Debug.Log("Matches Error"); break;
                }
                break;
            default:
                Debug.Log("MatchList Error"); break;
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




    //functions to handle button colour changing + boolean value changing
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
