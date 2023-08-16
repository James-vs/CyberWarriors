using TMPro;
using UnityEngine;

public abstract class MFACreativeBrick : MonoBehaviour
{
    // implementing variable to count collisions for stronger brick types
    protected float collisionCount = 0f;
    [SerializeField] protected GameObject InputBrick;

    /// <summary>
    /// function to save necessary details to spawn brick
    /// </summary>
    /// <param name="inputBrick">input brick to save</param>
    public abstract void SaveDetails(GameObject inputBrick);
    
}
