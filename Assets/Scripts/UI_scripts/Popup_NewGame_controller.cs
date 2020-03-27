using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup_NewGame_controller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Popup_NewGame_prefab;

    GameObject Popup_NewGame;
    public void ShowPopup()
    {
        Popup_NewGame = Instantiate(Popup_NewGame_prefab, transform);
    }

    // Update is called once per frame
    public void DeletePopup()
    {
        Destroy(Popup_NewGame);
    }
}
