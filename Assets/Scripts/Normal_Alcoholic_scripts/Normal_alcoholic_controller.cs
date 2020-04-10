using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class Normal_alcoholic_controller : MonoBehaviour
{
    Animator anim;
    GameObject cigaretteCatched;
    public Transform[] particleSystems;
    public Transform fog;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("CheckDrinking", 2);
    }

    void StopDrinking()
    {
        anim.SetBool("isDrinking", false);
    }

    void CheckDrinking()
    {
        float random = Random.Range(0.0f, 1.0f);

        if (random > 0.999f && !anim.GetBool("isDrinking"))
        {
            anim.SetBool("isDrinking", true);
        }
    }
    ChromaticAberration chromaticAberration = null;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Cigarette"))
        {
            foreach (Transform particleSystem in particleSystems)
            {
                particleSystem.GetComponent<ParticleSystem>().Stop();
            }
            LoadSleeping();
            GameObject.FindGameObjectWithTag("PPV").GetComponent<PostProcessVolume>().profile.TryGetSettings(out chromaticAberration);
            chromaticAberration.active = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("isInSmoke", false);
            cigaretteCatched = collider.gameObject;
        }
    }
    
    void StopDancing()
    {
        anim.SetBool("isAttackedWithMachete", false);
    }

    void DeleteCigarette()
    {
        Destroy(cigaretteCatched);
    }
    public void LoadSleeping()
    {
        anim = transform.GetComponent<Animator>();
        anim.SetBool("isAttackedWithCigarette", true);
        transform.GetComponent<BoxCollider>().enabled = false;
        transform.GetComponent<CapsuleCollider>().enabled = false;
        fog.GetComponent<SphereCollider>().enabled = false;
        foreach (Transform particleSystem in particleSystems)
        {
            particleSystem.GetComponent<ParticleSystem>().Stop();
        }
        if (fog.GetComponent<Alco_fog_controller>().graphicContainer != null)
        {
            fog.GetComponent<Alco_fog_controller>().graphicContainer.gameObject.SetActive(false);
        }
    }
}
