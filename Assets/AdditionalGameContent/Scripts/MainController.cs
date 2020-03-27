﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour
{
    public int counter;

    public List<Sprite> listOfImages;
    public CardController firstChosen;
    public CardController secondChosen;
    public CardController thirdChosen;
    public int numberOfPairs;
    public string playerName;
    public List<KeyValuePair<string, int>> playerAndValue = new List<KeyValuePair<string, int>>();
    public GameObject finalPopup;
    private AudioSource[] audios;
    private int enter;
    // Start is called before the first frame update

    void Start()
    {
        audios = transform.GetComponents<AudioSource>();
        foreach (Transform child in transform)
        {
            child.GetComponent<BoxCollider>().enabled = false;
        }
        Load();
        Fill();
        counter = 0;
        enter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(thirdChosen != null)
        {
            foreach (Transform child in transform)
            {
                if (!child.GetComponent<Animator>().GetBool("isPaired"))
                {
                    child.GetComponent<BoxCollider>().enabled = false;
                }
            }
            if (firstChosen.cardFace.Equals(secondChosen.cardFace) 
                && firstChosen.cardFace.Equals(thirdChosen.cardFace) 
                && enter == 0)
            {
                enter = 1;
                Invoke("PairFound", 0.5f);

            } else if(enter == 0)
            {
                enter = 1;
                Invoke("WrongPair", 1);
            }
        }
    }
    void PairFound()
    {
        audios[1].Play();
        firstChosen.animator.SetBool("isPaired", true);
        secondChosen.animator.SetBool("isPaired", true);
        thirdChosen.animator.SetBool("isPaired", true);
        numberOfPairs++;
        FinishGame();
        SwitchOnColliders();
        firstChosen.boxcollider.enabled = false;
        secondChosen.boxcollider.enabled = false;
        thirdChosen.boxcollider.enabled = false;

        firstChosen = null;
        secondChosen = null;
        thirdChosen = null;
        enter = 0;

    }

    void FinishGame()
    {
        if (numberOfPairs == 4)
        {
            audios[0].Play();
            numberOfPairs = 0;
            foreach (GameObject button in GameObject.FindGameObjectsWithTag("Button"))
            {
                button.GetComponent<Button>().interactable = false;
                button.GetComponentInChildren<Text>().color = Color.white;
            }
            finalPopup.SetActive(true);
            finalPopup.transform.GetChild(2).GetComponent<Text>().text = counter.ToString();
        }
    }
    void WrongPair()
    {
        firstChosen.animator.SetBool("isChosen", false);
        secondChosen.animator.SetBool("isChosen", false);
        thirdChosen.animator.SetBool("isChosen", false);

        SwitchOnColliders();
        firstChosen = null;
        secondChosen = null;
        thirdChosen = null;
        enter = 0;
    }
    void SwitchOnColliders()
    {
        foreach (Transform child in transform)
        {
            if (!child.GetComponent<Animator>().GetBool("isPaired"))
            {
                child.GetComponent<BoxCollider>().enabled = true;
            }
           
        }
    }
    public void Fill()
    {
        List<Sprite> tmpListOfImages = new List<Sprite>();
        foreach(Sprite image in listOfImages.ToList())
        {
            tmpListOfImages.Add(image);
            tmpListOfImages.Add(image);
            tmpListOfImages.Add(image);
        }

        foreach (Transform child in transform)
        {
            Sprite randomImage = tmpListOfImages.ElementAt(Random.Range(0, tmpListOfImages.Count));
            child.GetChild(0).GetComponent<SpriteRenderer>().sprite = randomImage;
            child.GetComponent<CardController>().cardFace = randomImage;

            tmpListOfImages.Remove(randomImage);
        }
    }

    public void Save()
    {
        var playerAndValueSorted = playerAndValue.ToList();
        playerAndValueSorted.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
        if(playerAndValueSorted.Count > 10)
        {
            playerAndValueSorted.Remove(playerAndValueSorted.Last());
        }
        File.WriteAllLines(Application.persistentDataPath + "/score.txt",
                    playerAndValueSorted.Select(e => string.Format("{0};{1}", e.Key, e.Value)));
        ShowScores();
    }

    public void Load()
    {
        if (!File.Exists(Application.persistentDataPath + "/score.txt"))
        {
            Debug.LogError("File not found");
            return;
        }

        string[] lines = File.ReadAllLines(Application.persistentDataPath + "/score.txt");
        foreach(string line in lines)
        {
            string[] pair = line.Split(';');
            playerAndValue.Add(new KeyValuePair<string, int>(pair[0], System.Convert.ToInt32(pair[1])));
        }

        ShowScores();
    }
    void ShowScores()
    {
        var playerAndValueSorted = playerAndValue.ToList();
        playerAndValueSorted.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));

        GameObject scoreboard = GameObject.FindGameObjectWithTag("Scoreboard");
        int childCount = 0;
        foreach (KeyValuePair<string, int> pair in playerAndValueSorted)
        {
            if (childCount < scoreboard.transform.childCount)
            {
                scoreboard.transform.GetChild(childCount).GetComponent<Text>().text = pair.Value +"  |  "+pair.Key;
                childCount++;
            }
        }
    }
}
