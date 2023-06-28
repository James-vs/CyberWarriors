using UnityEngine;

public class MFASimplePassDestroyer : MonoBehaviour
{
    //new object to Instantiate
    public GameObject go;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("MFASimplePassDestoryer script start");
    }

    //method to Destroy the brick if a ball collides with it
    public void OnCollisionEnter2D(Collision2D other) {
        if (!other.gameObject.CompareTag("Ball")) return;
        // possibly dont need this function
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (!other.gameObject.CompareTag("Ball")) return;
        Destroy(gameObject);
        Instantiate(go, transform.position, transform.rotation);
    }

}
