using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grandma_controller : MonoBehaviour
{
    public Vector3 startPos;
    public Transform target;
    public float speed = 2f;
    public bool moveUp;
    public Animator anim;
    public float lives = 2f;
    public bool canMove;
    public BoxCollider[] boxColliders;
    public Transform hatCannon;
    public Transform playerTarget;
    public Deadly_hat hatPrefab;
    public bool canTakeGrandmaLive;
    bool enterOnce;

    public BoxCollider hatArea_BoxCollider;
    void Start()
    {
        canMove = true;
        anim = transform.GetComponent<Animator>();
        startPos = transform.position;
        moveUp = true;
        canTakeGrandmaLive = true;
        enterOnce = true;
    }
    void Update()
    {
        float step = speed * Time.deltaTime;
        if (transform.position == target.position)
        {
            if (GameObject.FindGameObjectWithTag("Beret") != null)
            {
                Destroy(GameObject.FindGameObjectWithTag("Beret"));
            }
            var angle = transform.eulerAngles;
            angle.y = 90;
            transform.eulerAngles = angle;

            moveUp = false;
            //rotate the boxcollider
            hatArea_BoxCollider.center = new Vector3(6.5f, 1.9f, 0f);

        }
        else if (transform.position == startPos)
        {
            if (GameObject.FindGameObjectWithTag("Beret") != null)
            {
                Destroy(GameObject.FindGameObjectWithTag("Beret"));
            }
            var angle = transform.eulerAngles;
            angle.y = -90;
            transform.eulerAngles = angle;
            moveUp = true;
            hatArea_BoxCollider.center = new Vector3(-6.5f, 1.9f, 0f);
        }
        if (moveUp == false && canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPos, step);
            
        }
        else if (moveUp && canMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }
    public bool isStunned = false;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.CompareTag("Machete"))
        {
            if (canTakeGrandmaLive)
            {
                canTakeGrandmaLive = false;
                

                if (lives == 0)
                {
                    canMove = false;
                    foreach (BoxCollider boxCollider in boxColliders)
                    {
                        boxCollider.enabled = false;
                    }
                    if (GameObject.FindGameObjectWithTag("Beret") != null)
                    {
                        Destroy(GameObject.FindGameObjectWithTag("Beret"));
                    }
                    anim.SetBool("isDead", true);
                }
                else if(enterOnce)
                {
                    canMove = false;
                    anim.SetBool("isHitted", true);
                    Invoke("OpenPlayersDialog", 1f);
                    foreach (BoxCollider boxCollider in boxColliders)
                    {
                        boxCollider.enabled = true;
                    }
                    enterOnce = false;
                }
                Invoke("TakeGrandmaLife", 1f);
            }
        }
    }
    void OpenPlayersDialog()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Character_controller>().OpenDialogBubble("Wow what\nthat one is strong");
        Invoke("ClosePlayersDialog", 2f);
    }
    void ClosePlayersDialog()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Character_controller>().CloseDialogBubble();
    }
    void TakeGrandmaLife()
    {
        lives--;
        canTakeGrandmaLive = true;
    }
    public ParticleSystem puffDying;
    public void WaitAndDelete()
    {
        Invoke("TurnOffMesh", 0.3f);
        puffDying.transform.SetParent(null);
        puffDying.Play();
    }
    public void TurnOffMesh()
    {
        gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
    }
    public void DyingGrandma()
    {
        Destroy(puffDying.gameObject);
        Destroy(transform.parent.gameObject);
    }
    public void ThrowingHasFinished()
    {
        canMove = true;
        anim.SetBool("isThrowing", false);
        
    }
    public void FinishBeingHitted()
    {
        canMove = true;
        anim.SetBool("isHitted", false);
    }

    public void ThrowingHat()
    {
        canMove = false;  
        var clone = Instantiate(hatPrefab, hatCannon.position, this.transform.rotation, null);
        clone.transform.parent = null;
        clone.GetComponent<Deadly_hat>().parentPos = hatCannon;
        clone.GetComponent<Deadly_hat>().playerTarget = playerTarget;
    }

    public Transform onionPrefab;

    public void Onion_appeared()
    {
        var clone = Instantiate(onionPrefab, hatCannon.position-new Vector3(0,-1f,-1f), this.transform.rotation, null);
    }
}
