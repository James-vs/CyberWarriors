using Unity.VisualScripting;
using UnityEngine;

public class BlankInputBrick : MonoBehaviour
{
    protected GameObject InputWindow;
    protected BoxCollider2D boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        InputWindow = GameObject.FindGameObjectWithTag("Input Window");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        InputWindow.SetActive(true);
    }
}
