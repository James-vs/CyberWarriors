using UnityEngine;

public class InstructionsPaneController : MonoBehaviour
{
    [SerializeField] private GameObject instPane;
    [SerializeField] private GameObject button;

    public Vector2 visiblePosition;
    public bool isVisible;

    // Start is called before the first frame update
    void Start()
    {
        visiblePosition = new Vector2(transform.position.x - 185f,transform.position.y - 440f);
        isVisible = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangePositions() {
        if (isVisible) {
            instPane.transform.position = new Vector2(transform.position.x + 300, transform.position.y - 440);
            isVisible = false;
        } else {
            instPane.transform.position = visiblePosition;
            isVisible = true;
        }
        
    }
}
