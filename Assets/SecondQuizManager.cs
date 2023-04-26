using UnityEngine;

public class SecondQuizManager : FirstGameQuizManager
{

    public override void CheckAnswers() {
        if (answer1.ToLower().Equals("b")) {
            Debug.Log("answer1 correct");
            ans1correct = true;
        } else {
            ans1correct = false;
        }
    
        if (answer2.ToLower().Equals("a")) {
            Debug.Log("answer2 correct");
            ans2correct = true;
        } else {
            ans2correct = false;
        }

        if (answer3.ToLower().Equals("c")) {
            Debug.Log("answer3 correct");
            ans3correct = true;
        } else {
            ans3correct = false;
        }

        DisplayResults();
    }
}
