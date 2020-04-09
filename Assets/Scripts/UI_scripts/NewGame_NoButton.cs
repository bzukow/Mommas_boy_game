using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewGame_NoButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] artistButtons;
    void Start()
    {
        artistButtons = GameObject.FindGameObjectsWithTag("ArtistButton");
    }
    public void SwitchOfPopup()
    {
        Button[] buttons = GameObject.FindGameObjectWithTag("Canvas").GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
        foreach (GameObject button in artistButtons)
        {
            button.GetComponent<Button>().interactable = true;
        }
        transform.parent.parent.GetComponent<Popup_NewGame_controller>().DeletePopup();
    }
}
