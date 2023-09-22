using UnityEngine;

public class MFACreativeMedium : MFACreativeBrick
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("MFACreativeMedium script start");
        collisionCount = 1f;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Ball")) return;
        if (collisionCount == 0)
        { 
            Destroy(gameObject);
            InputBrick.SetActive(true);
        }
        else
        {
            var tmpCount = collisionCount;
            collisionCount = tmpCount - 1f;
            SpriteRenderer brick = GetComponent<SpriteRenderer>();
            brick.color = new Color32(140, 121, 0, 255);
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
