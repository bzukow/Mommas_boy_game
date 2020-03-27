using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hover_on_Bricks : MonoBehaviour, IPointerEnterHandler
{
    public bool cigareteChosen;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!cigareteChosen)
        {
            if (!transform.GetComponent<Animator>().GetBool("isHoverOnBrick"))
            {
                transform.GetComponent<Animator>().SetBool("isHoverOnBrick", true);
                Invoke("HideWhenThrowing", 2.0f);
            }
        }
    }
    public void ShowWhenThrowing()
    {
        cigareteChosen = true;
        if (!transform.GetComponent<Animator>().GetBool("isHoverOnBrick"))
        {
            transform.GetComponent<Animator>().SetBool("isHoverOnBrick", true);
        }
    }
    public void HideWhenThrowing()
    {
        if (transform.GetComponent<Animator>().GetBool("isHoverOnBrick"))
        {
            transform.GetComponent<Animator>().SetBool("isHoverOnBrick", false);
            cigareteChosen = false;
        }
    }
}
