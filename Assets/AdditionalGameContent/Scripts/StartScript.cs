using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartScript : MonoBehaviour
{
    public Transform resetButton;
    AudioSource audios;
    void Start()
    {
        audios = GetComponent<AudioSource>();
        resetButton.GetComponentInChildren<Text>().color = new Color(190.0f / 255.0f, 166.0f / 255.0f, 148.0f / 255.0f);
        transform.GetComponentInChildren<Text>().color = new Color(173.0f / 255.0f, 93.0f / 255.0f, 12.0f / 255.0f);
    }
    // Start is called before the first frame update
    public void StartGame()
    {
        audios.Play();
        foreach (Transform child in GameObject.FindGameObjectWithTag("GameController").transform)
        {
            child.GetComponent<BoxCollider>().enabled = true;
        }
        transform.GetComponent<Button>().interactable = false;
        transform.GetComponentInChildren<Text>().color = new Color(190.0f / 255.0f, 166.0f / 255.0f, 148.0f / 255.0f);
        resetButton.GetComponent<Button>().interactable = true;
        resetButton.GetComponentInChildren<Text>().color = new Color(173.0f / 255.0f, 93.0f / 255.0f, 12.0f / 255.0f);
    }
}
