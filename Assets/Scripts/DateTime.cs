using UnityEngine;
using TMPro;

public class DateTime : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI tmp;

    // Start is called before the first frame update
    void Start()
    {
        //get the current date and time
        tmp.text = System.DateTime.Now.ToString("HH:mm\nMM-dd-yyyy");
    }

    // Update is called once per frame
    void Update()
    {
        //refresh date and time
        tmp.text = System.DateTime.Now.ToString("HH:mm\nMM-dd-yyyy");
    }
}
