using UnityEngine;
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
        } else {
            Debug.Log("Invlaid input or question number");
        }
    }

    
    /// <summary>
    /// function to mark a given question
    /// </summary>
    /// <param name="questNum">question number</param>
    public void CheckAnswers() {
        
        if (answer1.ToLower().Equals("c")) {
            Debug.Log("answer1 correct");
            ans1correct = true;
        } else {
            ans1correct = false;
        }
    
    
        if (answer2.ToLower().Equals("c")) {
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

        //yourAns1.text = "Your Answer: " + answer1.ToUpper();
        //yourAns2.text = "Your Answer: " + answer2.ToUpper();
        TextMeshProUGUI yourAns3Text = yourAns3.GetComponent<TextMeshProUGUI>();
        yourAns3Text.text = "Your Answer: " + answer3.ToUpper();
        
        //change background colour to green for answers

            
    }
        
}

