using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FlashEffect : MonoBehaviour
{
    [SerializeField] protected GameObject fObject1;
    [SerializeField] protected GameObject fObject2;
    [SerializeField] protected Color originalColor1;
    [SerializeField] protected Color originalColor2;
    [SerializeField] protected Color flashColor = Color.red;
    [SerializeField] protected float duration;

    public void StartFlash(ref GameObject go1, ref GameObject go2, float time)
    {
        fObject1 = go1;
        fObject2 = go2;
        originalColor1 = fObject1.GetComponent<Image>().color;
        originalColor2 = fObject2.GetComponent<Image>().color;
        duration = time;
        StartCoroutine(FlashObject());
    }


    public IEnumerator FlashObject()
    {
        fObject1.GetComponent<Image>().color = flashColor;
        fObject2.GetComponent<Image>().color = flashColor;

        yield return new WaitForSeconds(duration);

        fObject1.GetComponent<Image>().color = originalColor1;
        fObject2.GetComponent<Image>().color = originalColor2;
    }
}
