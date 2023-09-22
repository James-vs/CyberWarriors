using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class HoverTipManager : MonoBehaviour
{
    protected TextMeshProUGUI tipText;
    [SerializeField] protected GameObject tipWindow;

    public static Action<string, Vector2> OnMouseHover;
    public static Action OnMouseExitHover;

    // Start is called before the first frame update
    void Start()
    {
        tipText = tipWindow.GetComponentInChildren<TextMeshProUGUI>();
        HideTip();
    }

    private void OnEnable()
    {
        OnMouseHover += ShowTip;
        OnMouseExitHover += HideTip;
    }


    private void OnDisable()
    {
        OnMouseHover -= ShowTip;
        OnMouseExitHover -= HideTip;
    }

    private void ShowTip(string tip, Vector2 mousePos)
    {
        tipText.text = tip;
        tipWindow.GetComponent<RectTransform>().sizeDelta = new Vector2(tipText.preferredWidth > 400 ? 400 : tipText.preferredWidth, tipText.preferredHeight);

        tipWindow.SetActive(true);

        tipWindow.transform.position = new Vector2(mousePos.x + 20f, mousePos.y); // + tipWindow.GetComponent<RectTransform>().sizeDelta.x * 2
    }


    private void HideTip()
    {
        tipText.text = default;
        tipWindow.SetActive(false);
    }
}
