using UnityEngine;
using UnityEngine.UI;

public class DifficultySliderManager : MonoBehaviour
{

    [SerializeField] private Slider slider;
    [SerializeField] private Color32 normalColour;
    

    // Start is called before the first frame update
    void Start()
    {
        normalColour = slider.colors.normalColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
