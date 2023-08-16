using UnityEngine;

public class MFACreativeSimple : MFACreativeBrick
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("MFACreativeSimple script start");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ball")) return;
        if (collisionCount == 0)
        {
            Destroy(gameObject);
            InputBrick.SetActive(true);
        }
    }


    /// <summary>
    /// override for SaveDetails abstract function
    /// </summary>
    /// <param name="inputBrick">input brick to save</param>
    public override void SaveDetails(GameObject inputBrick)
    {
        InputBrick = inputBrick;
    }
}
