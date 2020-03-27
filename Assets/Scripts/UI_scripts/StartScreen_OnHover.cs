using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StartScreen_OnHover : MonoBehaviour, IPointerEnterHandler
{
    public RawImage bubbleImage;
    public Text bubbleText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        bubbleImage.enabled = true;
        bubbleText.enabled = true;
        Invoke("HideTheBubble", 3f);

    }
    public void HideTheBubble()
    {
        bubbleImage.enabled = false;
        bubbleText.enabled = false;
    }
}
