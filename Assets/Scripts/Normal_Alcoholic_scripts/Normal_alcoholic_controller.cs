using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_alcoholic_controller : MonoBehaviour
{
    Animator anim;
    GameObject cigaretteCatched;
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

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Cigarette"))
        {
            LoadSleeping();
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
    }
}
