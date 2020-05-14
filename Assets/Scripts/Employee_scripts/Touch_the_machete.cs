using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_the_machete : MonoBehaviour
{
    public Transform alcoholic;
    public Transform employee;

    GameObject player;
    private List<GameObject> displayedLives;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        displayedLives = GameObject.FindGameObjectWithTag("Lives").GetComponent<Life_display>().lives;
    }
    void Update()
    {
        if (employee != null)
        {
            transform.position = employee.position;
            transform.rotation = employee.rotation;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if(alcoholic != null)
        {
            if (collision.CompareTag("Cigarette"))
            {
                Destroy(collision.gameObject);

            }
            if (collision.gameObject.CompareTag("Machete"))
            {
                alcoholic.GetComponent<Animator>().SetBool("isAttackedWithMachete", true);
                player.GetComponent<Animator>().SetFloat("speed", 0);
                //dodaj odejmowanie jednego zycia
                Invoke("TakePlayersLife", 0.2f);
                player.GetComponent<Animator>().SetBool("isHitted", true);
                player.GetComponent<Character_controller>().Stunned();
            }
        }
        if(employee != null)
        {
            /*if (collision.gameObject.CompareTag("Machete"))
            {
                employee.GetComponent<Animator>().SetBool("CharacterHasBeenCaught", false);
                employee.GetComponent<Animator>().SetBool("isTouched", true);
                player.GetComponent<Animator>().SetFloat("speed", 0);
                player.GetComponent<Animator>().SetBool("isHitted", true);
                player.GetComponent<Character_controller>().Stunned();
            } else if (collision.gameObject.CompareTag("Cigarette"))
            {
                employee.GetComponent<Animator>().SetBool("CharacterHasBeenCaught", false);
                employee.GetComponent<Animator>().SetBool("isTouched", true);
                //cos ze cigareta nie zadziala
            }*/
        }
    }
    public void TakePlayersLife()
    {
        player.GetComponent<Character_controller>().throwing_cigarette_line.SetActive(false);
        player.GetComponent<Character_controller>().anim.SetBool("isCigaretteThrown", false);
        player.GetComponent<Character_controller>().lives--;
        Destroy(displayedLives[displayedLives.Count - 1]);
        displayedLives.RemoveAt(displayedLives.Count - 1);
        if (player.GetComponent<Character_controller>().lives < 1)
        {
            //TO DO CHYBA?
            player.GetComponent<Character_controller>().stunned = true;
            player.GetComponent<Character_controller>().anim.SetBool("isDead", true);
            StartCoroutine(player.GetComponent<Character_controller>().Defeated());
        }
    }
}
