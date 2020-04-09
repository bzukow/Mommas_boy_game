using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
public class New_Game : MonoBehaviour
{
    public Popup_NewGame_controller popup;
    public Button ArtistButtonOne;
    public Button ArtistButtonTwo;
    public void InvokeNewGame()
    {
        if (File.Exists(Application.persistentDataPath + "/Data.dat"))
        {
            Button[] buttons = GameObject.FindGameObjectWithTag("Canvas").GetComponentsInChildren<Button>();
            foreach (Button button in buttons)
            {
                button.interactable = false;
            }
            ArtistButtonOne.interactable = false;
            ArtistButtonTwo.interactable = false;
            popup.ShowPopup();
        }
        else
        {
            StartCoroutine(NewGame());
        }
    }
    IEnumerator NewGame()
    {
        float fadeTime = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Fading>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene("LoadingScene");
    }
}
