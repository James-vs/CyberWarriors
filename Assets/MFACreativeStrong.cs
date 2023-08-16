using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MFACreativeStrong : MFACreativeBrick
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("MFACreativeStrong script start");
        collisionCount = 2f;
    }

    //method to Destroy the brick after a ball collides with it 3 times
    private void OnCollisionExit2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Ball")) return;
        SpriteRenderer brick = GetComponent<SpriteRenderer>();
        if (collisionCount == 2)
        {
            var tmpCount = collisionCount;
            collisionCount = tmpCount - 1f;
            brick.color = new Color32(40, 180, 0, 255);
        }
        else if (collisionCount == 1)
        {
            var tmpCount = collisionCount;
            collisionCount = tmpCount - 1f;
            brick.color = new Color32(40, 180, 0, 100);
        }
        else
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
