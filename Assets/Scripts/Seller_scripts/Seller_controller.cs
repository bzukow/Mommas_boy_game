using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
public class Seller_controller : MonoBehaviour
{
    string sentence;
    Animator anim;
    AudioSource[] audiosources;

    void Start()
    {
        audiosources = GetComponents<AudioSource>();
        anim = transform.parent.GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            sentence = collider.GetComponent<Character_controller>().CheckIfEverythingIsCollected();
            ShowEnding();
        }

    }
    void ShowEnding()
    {
        audiosources[0].Play();
        switch (sentence)
        {
            case "selfish":
                anim.SetBool("isFinished", true);
                StartCoroutine(SelfishEnding());
                break;
            case "chicken_soup_is_better":
                anim.SetBool("winner", true);
                StartCoroutine(ChickenSoupEnding());
                break;
            case "im_not_your_housekeeper":
                anim.SetBool("isFinished", true);
                StartCoroutine(HousekeeperEnding());
                break;
            case "useless_pasta":
                anim.SetBool("isFinished", true);
                StartCoroutine(UselessPastaEnding());
                break;
        }
    }
    IEnumerator SelfishEnding()
    {
        float fadeTime = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("SelfishScene");
    }
    IEnumerator ChickenSoupEnding()
    {
        
        float fadeTime = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("ChickenSoupScene");
    }
    IEnumerator HousekeeperEnding()
    {
        float fadeTime = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("HousekeeperScene");
    }
    IEnumerator UselessPastaEnding()
    {
        float fadeTime = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("UselessPastaScene");
    }
}
