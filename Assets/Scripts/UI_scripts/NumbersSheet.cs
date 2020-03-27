using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumbersSheet : MonoBehaviour
{
    public GameObject shrimps;
    public GameObject chilli;
    public GameObject chicken;
    public GameObject onions;
    public GameObject mushrooms;
    public GameObject limes;
    public GameObject coconut_milk;
    public GameObject toilet_paper;

    public GameObject onion_check;

    public GameObject player;
    public Character_controller playerScript;

    public void ActualiseSheet()
    {
        WaitforActualisation(playerScript.shrimps, playerScript.chilli, playerScript.chicken, playerScript.onions, playerScript.mushrooms, playerScript.limes, playerScript.coconut_milk, playerScript.toilet_paper);
    }

    public void WaitforActualisation(float shrimps, float chilli, float chicken, float onions, float mushrooms, float limes, float coconut_milk, float toilet_paper)
    {
        this.chilli.GetComponent<Text>().text = chilli.ToString();
        this.shrimps.GetComponent<Text>().text = shrimps.ToString();
        this.chicken.GetComponent<Text>().text = chicken.ToString();
        this.onions.GetComponent<Text>().text = onions.ToString();
        this.mushrooms.GetComponent<Text>().text = mushrooms.ToString();
        this.limes.GetComponent<Text>().text = limes.ToString();
        this.coconut_milk.GetComponent<Text>().text = coconut_milk.ToString();
        this.toilet_paper.GetComponent<Text>().text = toilet_paper.ToString();
        if (onions == 0)
        {
            onion_check.SetActive(true);
        }
    }
}
