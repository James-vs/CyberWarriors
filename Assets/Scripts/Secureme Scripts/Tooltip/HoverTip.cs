using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] protected string tipToShow;
    [SerializeField] protected float delayTime = 0.5f;


    public void OnPointerEnter(PointerEventData eventData)
    {
        //Debug.Log("HOVERED");
        StopAllCoroutines();
        StartCoroutine(DelayShowTip());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //Debug.Log("EXITED");
        StopAllCoroutines();
        HoverTipManager.OnMouseExitHover();
    }

    private void DisplayTipMessage()
    {
        HoverTipManager.OnMouseHover(tipToShow, Input.mousePosition);
    }

    private IEnumerator DelayShowTip()
    {
        yield return new WaitForSeconds(delayTime);

        DisplayTipMessage();
    }
}
