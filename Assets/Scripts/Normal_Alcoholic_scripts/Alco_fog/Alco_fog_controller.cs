using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Alco_fog_controller : MonoBehaviour
{
    Transform player;
    Animator animator;
    bool left;
    public Transform graphicContainer;

    void Start()
    {
        animator = transform.GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider collider)
    {
        //show C key
        if (collider.CompareTag("Player"))
        {
            if(graphicContainer != null)
            {
                graphicContainer.gameObject.SetActive(true);
            }
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && !left)
        {
            GameObject.FindGameObjectWithTag("PPV").GetComponent<PostProcessVolume>().profile.TryGetSettings(out chromaticAberration);
            chromaticAberration.active = true;
            chromaticAberration.intensity.value = intensity;
            other.transform.GetComponent<Animator>().SetBool("isInSmoke", true);
        }
    }
    public float intensity = 0.87f;
    ChromaticAberration chromaticAberration = null;
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !left)
        {
            if (graphicContainer != null)
            {
                graphicContainer.gameObject.SetActive(false);
            }
            left = true;
            Invoke("WaitWithDebuff", 6);
        }
    }

    void WaitWithDebuff()
    {
        //wylacz efekt
        GameObject.FindGameObjectWithTag("PPV").GetComponent<PostProcessVolume>().profile.TryGetSettings(out chromaticAberration);
        chromaticAberration.active = false;        
        left = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Character_controller>().canAttack = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("isInSmoke", false);
    }
}
