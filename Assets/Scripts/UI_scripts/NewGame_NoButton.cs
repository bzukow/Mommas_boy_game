using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewGame_NoButton : MonoBehaviour
{
    // Start is called before the first frame update
    public Button ArtistButtonOne;
    public Button ArtistButtonTwo;
    public void SwitchOfPopup()
    {
        Button[] buttons = GameObject.FindGameObjectWithTag("Canvas").GetComponentsInChildren<Button>();
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
        ArtistButtonOne.interactable = true;
        ArtistButtonTwo.interactable = true;
        transform.parent.parent.GetComponent<Popup_NewGame_controller>().DeletePopup();
    }
}
