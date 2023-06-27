using UnityEngine;

public class HintManager : MonoBehaviour
{
    [SerializeField] private GameObject hintWindow;

    // function to handle opening/closing the hint window 
    public void GetHint(bool value) {
        hintWindow.SetActive(value);
    }
}
