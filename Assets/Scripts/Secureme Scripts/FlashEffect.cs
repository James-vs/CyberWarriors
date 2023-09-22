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

    public void StartFlash(GameObject go1, GameObject go2, Color oc1, Color oc2, float time)
    {
        // public void StartFlash(ref GameObject go1, ref GameObject go2, Color oc1, Color oc2, float time)
        fObject1 = go1;
        fObject2 = go2;
        originalColor1 = oc1;
        originalColor2 = oc2;
        duration = time;
        StartCoroutine(FlashObject());
    }


    public IEnumerator FlashObject()
    {
        if (fObject1.GetComponent<Image>() != null && fObject1.GetComponent<Button>() != null)
        {
            fObject1.GetComponent<Button>().interactable = false;
            fObject1.GetComponent<Image>().color = flashColor;
        } 
        else if (fObject1.GetComponent<Image>() != null)
        {
            fObject1.transform.parent.GetChild(fObject1.transform.parent.childCount - 1).GetComponent<Button>().interactable = false;
            fObject1.transform.parent.GetChild(0).GetComponent<Image>().color = flashColor;
        }
        else
        {
            fObject1.transform.GetChild(fObject1.transform.childCount-1).GetComponent<Button>().interactable = false;
            fObject1.transform.GetChild(0).GetComponent<Image>().color = flashColor;
        }

        if (fObject2.GetComponent<Image>() != null && fObject2.GetComponent<Button>() != null)
        {
            fObject2.GetComponent<Button>().interactable = false;
            fObject2.GetComponent<Image>().color = flashColor;
        }
        else if (fObject2.GetComponent<Image>() != null)
        {
            fObject2.transform.parent.GetChild(fObject2.transform.parent.childCount - 1).GetComponent<Button>().interactable = false;
            fObject2.transform.parent.GetChild(0).GetComponent<Image>().color = flashColor;
        }
        else
        {
            fObject2.transform.GetChild(fObject2.transform.childCount - 1).GetComponent<Button>().interactable = false;
            fObject2.transform.GetChild(0).GetComponent<Image>().color = flashColor;
        }

        yield return new WaitForSeconds(duration);

        if (fObject1.GetComponent<Image>() != null && fObject1.GetComponent<Button>() != null)
        {
            fObject1.GetComponent<Button>().interactable = true;
            fObject1.GetComponent<Image>().color = originalColor1;
            Debug.Log("fObject1 switched back to original colour");
        }
        else if (fObject1.GetComponent<Image>() != null)
        {
            fObject1.transform.parent.GetChild(fObject1.transform.parent.childCount - 1).GetComponent<Button>().interactable = true;
            fObject1.transform.parent.GetChild(0).GetComponent<Image>().color = originalColor1;
            Debug.Log("fObject1 switched back to original colour");
        }
        else
        {
            fObject1.transform.GetChild(fObject1.transform.childCount - 1).GetComponent<Button>().interactable = true;
            fObject1.transform.GetChild(0).GetComponent<Image>().color = originalColor1;
            Debug.Log("fObject1 switched back to original colour");
        }

        if (fObject2.GetComponent<Image>() != null && fObject2.GetComponent<Button>() != null)
        {
            fObject2.GetComponent<Button>().interactable = true;
            fObject2.GetComponent<Image>().color = originalColor2;
            Debug.Log("fObject2 switched back to original colour");
        }
        else if (fObject2.GetComponent<Image>() != null)
        {
            fObject2.transform.parent.GetChild(fObject2.transform.parent.childCount - 1).GetComponent<Button>().interactable = true;
            fObject2.transform.parent.GetChild(0).GetComponent<Image>().color = originalColor1;
            Debug.Log("fObject2 switched back to original colour");
        }
        else
        {
            fObject2.transform.GetChild(fObject2.transform.childCount - 1).GetComponent<Button>().interactable = true;
            fObject2.transform.GetChild(0).GetComponent<Image>().color = originalColor2;
            Debug.Log("fObject2 switched back to original colour");
        }
    }
}
