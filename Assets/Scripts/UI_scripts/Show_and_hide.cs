using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Show_and_hide : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void Show()
    {
        transform.SetAsLastSibling();
    }

    // Update is called once per frame
    public void Hide()
    {
        //unable buttons hile anim is playeds
        transform.SetAsFirstSibling();
    }

    public void AnimatorHideFalse()
    {
        anim.SetBool("hide", false);
    }
    public void AnimatorShowFalse()
    {
        anim.SetBool("show", false);
    }
}
