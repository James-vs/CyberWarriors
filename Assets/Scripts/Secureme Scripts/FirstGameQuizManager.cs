using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;

public class FirstGameQuizManager : MonoBehaviour
{
    protected string answer1;
    protected string answer2;
    protected string answer3;
    [SerializeField] protected GameObject question_1;
    [SerializeField] protected GameObject question_2;
    [SerializeField] protected GameObject question_3;
    [SerializeField] protected GameObject q1invalid;
    [SerializeField] protected GameObject q2invalid;
    [SerializeField] protected GameObject q3invalid;
    [SerializeField] protected GameObject results;
    [SerializeField] protected GameObject yourAns1;
    [SerializeField] protected GameObject yourAns2;
    [SerializeField] protected GameObject yourAns3;
    protected bool ans1correct;
    protected bool ans2correct;
    protected bool ans3correct;
    [SerializeField] private string gameProgression = "SMProgression";




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
        } else if (questNum == 2 && answer2.Length < 2 && Regex.IsMatch(answer2, @"^[a-cA-C]+$")) {
            // go to the next question
            question_2.SetActive(false);
            question_3.SetActive(true);
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
    public virtual void CheckAnswers() {
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
    protected void DisplayResults() {
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

    /// <summary>
    /// function to unlock the next game for the player
    /// </summary>
    public void UnlockEmailsGame()
    {
        if (PlayerPrefs.GetInt(gameProgression) < 1) PlayerPrefs.SetInt(gameProgression, 1);
    }
        
}

