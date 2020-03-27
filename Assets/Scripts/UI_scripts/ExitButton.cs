using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void InvokeExit()
    {
        StartCoroutine(Exit());
    }
    IEnumerator Exit()
    {
        float fadeTime = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        Application.Quit();
    }
}
