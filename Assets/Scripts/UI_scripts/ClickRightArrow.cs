using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRightArrow : MonoBehaviour
{
    public GameObject sheets;

    public void ChangeOrderShow()
    {
        sheets.transform.GetChild(0).GetComponent<Animator>().SetBool("show", true);
    }
    public void ChangeOrderHide()
    {
        sheets.transform.GetChild(sheets.transform.childCount - 1).GetComponent<Animator>().SetBool("hide", true);

    }
}
