using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hover_on_paper : MonoBehaviour, IPointerEnterHandler
{
    public Transform listOfThings;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!listOfThings.GetComponent<Sheet_cotroller>().isTabClicked &&
            !transform.GetComponent<Animator>().GetBool("isHoverOnPaper"))
        {
            transform.GetComponent<Animator>().SetBool("isHoverOnPaper", true);
        }
    }

    public void PointerExit()
    {
        transform.GetComponent<Animator>().SetBool("isHoverOnPaper", false);
    }
}
