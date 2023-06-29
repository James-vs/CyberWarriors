using UnityEngine;

public abstract class MFABrick : MonoBehaviour
{
    // implementing variable to count collisions for stronger brick types
    protected float collisionCount = 0f;

    [Header("Brick to Spawn")]
    // variable to spawn a new medium brick
    public GameObject go;
}
