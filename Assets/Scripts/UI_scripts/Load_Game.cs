using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
public class Load_Game : MonoBehaviour
{
    public GameObject popup;
    public Button ArtistButtonOne;
    public Button ArtistButtonTwo;

    void Update()
    {
        if(popup.activeInHierarchy == true)
        {
            if (Input.anyKey)
            {
                popup.SetActive(false);
                Invoke("UnlockButtons", 0.2f);
                
            }
        }
        
    }
    void UnlockButtons()
    {
        Button[] buttons = GameObject.FindGameObjectWithTag("Canvas").GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
        ArtistButtonOne.interactable = true;
        ArtistButtonTwo.interactable = true;
    }
    public void InvokeLoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/Data.dat"))
        {
            StartCoroutine(LoadGame());
        } else
        {
            Button[] buttons = GameObject.FindGameObjectWithTag("Canvas").GetComponentsInChildren<Button>();
            foreach (Button button in buttons)
            {
                button.interactable = false;
            }
            ArtistButtonOne.interactable = false;
            ArtistButtonTwo.interactable = false;
            popup.SetActive(true);
        }
    }
    IEnumerator LoadGame()
    {
        float fadeTime = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("LoadingScene");
        //trzeba tu zaladowac to z jakims ogarem albo na levelu to sprawdzic
    }
}
