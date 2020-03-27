using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartScreen_Button : MonoBehaviour
{
    public Transform arrows;

    public void ActivateArrows()
    {
        Invoke("WaitHighlighted", 0.4f);
    }
    public void DesactivateArrows()
    {
        Invoke("WaitNormal", 0.4f);
    }

    public void WaitHighlighted()
    {
        if (transform.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Highlighted"))
        {
            arrows.gameObject.SetActive(true);
        }
    }
    public void WaitNormal()
    {
        if (transform.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Normal"))
        {
            arrows.gameObject.SetActive(false);
        }
    }
}
