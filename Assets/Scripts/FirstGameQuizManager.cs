using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;

public class FirstGameQuizManager : MonoBehaviour
{
    private string answer1;
    private string answer2;
    private string answer3;
    [SerializeField] private GameObject question_1;
    [SerializeField] private GameObject question_2;
    [SerializeField] private GameObject question_3;
    [SerializeField] private GameObject q1invalid;
    [SerializeField] private GameObject q2invalid;
    [SerializeField] private GameObject q3invalid;
    [SerializeField] private GameObject results;
    [SerializeField] private GameObject yourAns1;
    [SerializeField] private GameObject yourAns2;
    [SerializeField] private GameObject yourAns3;
    private bool ans1correct;
    private bool ans2correct;
    private bool ans3correct;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // function to pass the answer into this script from the input field
    public void ReadAnswer1(string answer) {
        answer1 = answer;
        Debug.Log("Answer given: " + answer1);
    }
    public void ReadAnswer2(string answer) {
        answer2 = answer;
        Debug.Log("Answer given: " + answer2);
    }
    public void ReadAnswer3(string answer) {
        answer3 = answer;
        Debug.Log("Answer given: " + answer3);
    }


    /// <summary>
    /// function to check for valid input
    /// </summary>
    /// <param name="questNum">question number of input</param>
    public void CheckValidInput(int questNum){
        if (questNum == 1 && answer1.Length < 2 && Regex.IsMatch(answer1, @"^[a-cA-C]+$")) {
            // go to the next question
            question_1.SetActive(false);
            question_2.SetActive(true);
            //q2invalid.SetActive(false);
        } else if (questNum == 2 && answer2.Length < 2 && Regex.IsMatch(answer2, @"^[a-cA-C]+$")) {
            // go to the next question
            question_2.SetActive(false);
            question_3.SetActive(true);
            //q3invalid.SetActive(false);
        } else if (questNum == 3 && answer3.Length < 2 && Regex.IsMatch(answer3, @"^[a-cA-C]+$")) {
            // mark the answers
            // display results
            question_3.SetActive(false);
            results.SetActive(true);
            CheckAnswers();
        } else if (questNum == 1){ //invalid input cases
            q1invalid.SetActive(true);
        }else if (questNum == 2){
            q2invalid.SetActive(true);
        }else if (questNum == 3){
            q3invalid.SetActive(true);
        } else {
            Debug.Log("Invalid question number");
        }
    }

    
    /// <summary>
    /// function to mark the questions
    /// </summary>
    public void CheckAnswers() {
        if (answer1.ToLower().Equals("a")) {
            Debug.Log("answer1 correct");
            ans1correct = true;
        } else {
            ans1correct = false;
        }
    
        if (answer2.ToLower().Equals("b")) {
            Debug.Log("answer2 correct");
            ans2correct = true;
        } else {
            ans2correct = false;
        }

        if (answer3.ToLower().Equals("b")) {
            Debug.Log("answer3 correct");
            ans3correct = true;
        } else {
            ans3correct = false;
        }

        DisplayResults();

    }



    /// <summary>
    /// Displays the answers to the user in a human readable and obvious format
    /// </summary>
    private void DisplayResults() {
        TextMeshProUGUI yourAns1Text = yourAns1.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        yourAns1Text.text = "Your Answer: " + answer1.ToUpper();
        if (ans1correct) {
            yourAns1.transform.GetChild(0).GetComponent<Image>().color = Color.green;
        } else {
            yourAns1.transform.GetChild(0).GetComponent<Image>().color = Color.red;
        }
        TextMeshProUGUI yourAns2Text = yourAns2.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        yourAns2Text.text = "Your Answer: " + answer2.ToUpper();
        if (ans2correct) {
            yourAns2.transform.GetChild(0).GetComponent<Image>().color = Color.green;
        } else {
            yourAns2.transform.GetChild(0).GetComponent<Image>().color = Color.red;
        }
        TextMeshProUGUI yourAns3Text = yourAns3.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        yourAns3Text.text = "Your Answer: " + answer3.ToUpper();
        if (ans3correct) {
            yourAns3.transform.GetChild(0).GetComponent<Image>().color = Color.green;
        } else {
            yourAns3.transform.GetChild(0).GetComponent<Image>().color = Color.red;

        }
    }
        
}

