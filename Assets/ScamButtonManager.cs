using UnityEngine;
using UnityEngine.UI;

public class ScamButtonManager : MonoBehaviour
{
    [SerializeField] protected Button yesButton;
    [SerializeField] protected Button noButton;
    protected Color32 selected;
    protected Color32 original;

    // Start is called before the first frame update
    void Start()
    {
        selected = new Color32(33,255,0,255);
        original = yesButton.GetComponent<Image>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectButton(bool value) {
        if (value == true) {
            yesButton.GetComponent<Image>().color = selected;
            noButton.GetComponent<Image>().color = original;
        } else {
            noButton.GetComponent<Image>().color = selected;
            yesButton.GetComponent<Image>().color = original;
        }
    }
}
