using UnityEngine;

public class MFASimplePassDestroyer : MFABrick
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("MFASimplePassDestoryer script start");
    }

    //method to Destroy the brick after a ball collides with it
    private void OnCollisionExit2D(Collision2D other) {
        if (!other.gameObject.CompareTag("Ball")) return;
        Destroy(gameObject);
        Instantiate(go, transform.position, transform.rotation);
    }

}
